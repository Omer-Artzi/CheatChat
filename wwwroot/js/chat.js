// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//document.getElementById("sendButton").addEventListener("click", function (event) {
//    //this method will update the view screen with the message that was sent for all users in the chat in real time using MVC.without using webAPI:


//}
//function send_message()
//{
//    var message = document.getElementById("messageInput").value;
//    //var user = document.getElementById("user").value;
//    //var chat = document.getElementById("chat").value;
//    var xhr = new XMLHttpRequest();
//    //xhr.open("POST", "/api/chat", true);
//    xhr.open("POST", "~/Controllers/ChatController.cs", true);
//    xhr.setRequestHeader('Content-Type', 'application/json');
//    //xhr.send(JSON.stringify({ "message": message, "user": user, "chat": chat }));
//    xhr.send(JSON.stringify({ "message": message }));
//    document.getElementById("message").value = "";
//    }



"use strict";

// Create a connection to the SignalR hub
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .build();

// Start the connection
connection.start().then(() => {
    console.log("Connection started");
}).catch((err) => {
    console.error(err.toString());
});

// Handle receiving messages
//connection.on("ReceiveMessage", (user, message) => {
connection.on("ReceiveMessage", (user, message) => {
    // Update the UI with the new message
    const chatMessages = document.getElementById("chat-messages");
    const newMessage = document.createElement("p");
    newMessage.textContent = `${user}: ${message}`;
    chatMessages.appendChild(newMessage);
});

// Handle sending messages
function sendMessage() {
    const user = document.getElementById("user").value;
    const message = document.getElementById("message").value;

    // Send the message to the server
    connection.invoke("SendMessage", user, message).catch((err) => {
    //connection.invoke("SendMessage", message).catch((err) => {
        console.error(err.toString());
    });
}