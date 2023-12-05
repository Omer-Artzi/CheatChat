// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

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
    newMessage.textContent = `${user}: ${message}`;
    chatMessages.appendChild(newMessage);
});


// Handle sending messages from browser to server Hub
function sendMessage() {
    const user = document.getElementById("user").value;
    const message = document.getElementById("message").value;

    // Send the message to the server
    connection.invoke("SendMessage", user, message).catch((err) => {
        console.error(err.toString());
    });
}
//public bool isConnected => connection.State == connection.Connected;

function returnBack() {
    const user = document.getElementById("user").value;
    //need to invoke the server method on Hub to return back to the home page
    connection.invoke("ReturnBack",user).catch((err) => {
        console.error(err.toString());
    });
}

connection.on("NavigateHome", function (user) {
    print("NavigateHome");
    // Navigate to the home view
    window.location.href = "/";///Views/Home/Index";
});