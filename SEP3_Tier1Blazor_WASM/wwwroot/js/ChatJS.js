let ChatBlazor

function connectChat(dotnet, id){
    ChatBlazor = dotnet;
    stompClient.connect({}, function (frame) {
        stompClient.subscribe('/topic/chat/' + id, function (message) {
            newMessageReceived(message.body);
        });

        stompClient.subscribe('/topic/chat/delete' + id, function (message) {
            messageDeleted(message.body);
        });
    });
}

function newMessageReceived(message){
    console.log(message)
    ChatBlazor.invokeMethodAsync('NewMessageReceived', message);
}

function sendMessage(message){
    stompClient.send("/app/chat", {}, message);
}

function deleteMessage(message){
    stompClient.send("/app/delete_message", {}, message)
}

function messageDeleted(message){
    ChatBlazor.invokeMethodAsync('MessageDeleted', message);
}