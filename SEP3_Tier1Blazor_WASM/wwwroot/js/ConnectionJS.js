let stompClient = null;
let Blazor;

function connect(dotnet, id) {
    Blazor = dotnet;
    console.log("User connected: " + id)
    var socket = new SockJS('http://localhost:8080/shapeapp');
    stompClient = Stomp.over(socket);
    stompClient.connect({}, function (frame) {
        stompClient.subscribe('/topic/notifications/' + id, function (notification) {
            showFriendRequest(notification.body);
        });
        stompClient.subscribe('/topic/filter_result/' + id, function (users){
            receivedUserSearchBarList(users.body);
        })
        stompClient.subscribe('/topic/errors/' + id, function (error){
            showGreeting(error.body);
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
}

function sendFriendRequest(userAction){
    console.log(stompClient)
    stompClient.send("/app/note", {}, userAction);
}

function sendSearchValue(value) {
    stompClient.send("/app/filter", {}, value);
}

function showFriendRequest(notification){
    console.log("RRRRRRRRRRRRRRRRRRRRRRR"+ notification)
    Blazor.invokeMethodAsync('ShowFriendRequest', notification)
}

function receivedUserSearchBarList(users){
    Blazor.invokeMethodAsync('ShowSearchbarUsers', users)
}