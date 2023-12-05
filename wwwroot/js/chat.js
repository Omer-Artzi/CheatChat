
"use strict";

// Create a connection to the SignalR hub
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .withAutomaticReconnect()
    .build();

// Start the connection
connection.start().then(() => {
    console.log("Connection started");
}).catch((err) => {
    console.error(err.toString());
});

// Handle receiving messages event from server Hub
//connection.on("ReceiveMessage", (user, message) => {
connection.on("ReceiveMessage", (user, message) => {
    // Update the UI with the new message
    const chatMessages = document.getElementById("chat-messages");
    const newMessage = document.createElement("p");
    //TODO: use proper names("You" for current user and names for the rest)
    //TODO: list should have current user messages to the right and the rest to the left
    newMessage.textContent = `You:\n ${message}`;
    chatMessages.appendChild(newMessage);
});


// Handle sending messages from browser to server Hub
function sendMessage() {
    const user = document.getElementById("user").value;
    const message = document.getElementById("message").value;
    //Check if message is empty
    if (message === null || message.length === 0) {
        return;
    }

    // Send the message to the server
    connection.invoke("SendMessage", user, message).catch((err) => {
        console.error(err.toString());
    });
}
//public bool isConnected => connection.State == connection.Connected;

function logout() {
    // const user = document.getElementById("user").value;
    //need to invoke the server method on Hub to return back to the home page
    connection.invoke("logout").catch((err) => {
        console.error(err.toString());
    });
}

connection.on("NavigateHome", function () {
    // Navigate to the home view
    window.location.href = "/";///Views/Home/Index";
});

