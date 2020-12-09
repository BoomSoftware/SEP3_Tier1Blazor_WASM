let stompClient = null;
let Blazor;
let PostBlazor;

async function connect(dotnet, id) {
    Blazor = dotnet;
    console.log("User connected: " + id)
    var socket = new SockJS('https://localhost:8443/shapeapp');
    stompClient = Stomp.over(socket);
    
        stompClient.connect({}, function (frame) {
            stompClient.subscribe('/topic/notifications/' + id, function (notification) {
                showFriendRequest(notification.body);
            });
            stompClient.subscribe('/topic/filter_result/' + id, function (users){
                receivedUserSearchBarList(users.body);
            });
            stompClient.subscribe('/topic/new_online/' + id, function (user){
                newOnlineUser(user.body);
            });
            stompClient.subscribe('/topic/new_offline/' + id, function (user){
                newOfflineUser(user.body);
            });

            stompClient.subscribe('/topic/errors/' + id, function (error){
                showGreeting(error.body);
            });

            stompClient.send("/app/login",{}, id);
        });
     
}
function disconnect(userId) {
    if (stompClient !== null) {
        stompClient.send("/app/logout",{}, userId)
        stompClient.disconnect();
    }
    console.log("Disconnected");
}

function connectRequest(userId){
     stompClient.send("/app/login",{}, userId);
}

function sendFriendRequest(userAction){
    console.log(stompClient)
    stompClient.send("/app/note", {}, userAction);
}

function sendSearchValue(value) {
    stompClient.send("/app/filter", {}, value);
}

function showFriendRequest(notification){
    Blazor.invokeMethodAsync('ShowFriendRequest', notification)
}

function receivedUserSearchBarList(users){
    Blazor.invokeMethodAsync('ShowSearchbarUsers', users)
}

function newOnlineUser(user){
    if(PostBlazor != null)
        PostBlazor.invokeMethodAsync('AddOnlineUser', user)
}

function newOfflineUser(user){
    if(PostBlazor != null)
        PostBlazor.invokeMethodAsync('DeleteOnlineUser', user)
}