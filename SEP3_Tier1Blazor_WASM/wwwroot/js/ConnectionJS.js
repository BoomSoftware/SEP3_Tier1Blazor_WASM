﻿﻿let stompClient = null;
let Blazor;

function connect(dotnet) {
    Blazor = dotnet;
    console.log("Hello")
    var socket = new SockJS('http://localhost:8080/gs-guide-websocket/');
    stompClient = Stomp.over(socket);
    stompClient.connect({}, function (frame) {
        console.log('Connected: ' + frame);
        stompClient.subscribe('/topic/greetings', function (greeting) {
            showGreeting(JSON.parse(greeting.body).content);
        });
    });
}

function disconnect() {
    if (stompClient !== null) {
        stompClient.disconnect();
    }
    setConnected(false);
    console.log("Disconnected");
}

function sendName(name) {
    stompClient.send("/app/hello", {}, JSON.stringify({'name': name}));
    console.log("Message sent");
}

function showGreeting(message) {
    console.log(message);
    Blazor.invokeMethodAsync('AddText', message)
        .then(data => {
            console.log(data);
        });
}
    