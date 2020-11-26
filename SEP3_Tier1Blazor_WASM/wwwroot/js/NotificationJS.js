const PAGE_TITLE = "ShapeApp";

function playNotificationSound() {
    document.getElementById('notificationSound').play();
}

function updatePageTitle(notificationNumber){
    if(notificationNumber > 0){
        document.title = "("+notificationNumber+") " + PAGE_TITLE;
    }
    else
        document.title = PAGE_TITLE;
}

