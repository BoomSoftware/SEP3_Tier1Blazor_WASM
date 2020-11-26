let stompClient = null;
let Blazor;

function connect(dotnet, id) {
    Blazor = dotnet;
    console.log("User connected: " + id)
    var socket = new SockJS('http://localhost:8080/shapeapp');
    stompClient = Stomp.over(socket);
    stompClient.connect({}, function (frame) {
        console.log('Connected: ' + frame);
        stompClient.subscribe('/topic/notifications/' + id, function (notification) {
            showFriendRequest(notification.body);
        });
        
        stompClient.subscribe('/topic/errors/' + id, function (error){
            showGreeting(error);
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

function sendFriendRequest(userAction){
    console.log(stompClient)
    stompClient.send("/app/note", {}, userAction);
    console.log("Friend request sent");
}

function showFriendRequest(notification){
    Blazor.invokeMethodAsync('ShowFriendRequest', notification)
    console.log("JS file"+ notification)
}

function showGreeting(message) {
    //console.log(message);
}
    