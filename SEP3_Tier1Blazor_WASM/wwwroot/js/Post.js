let LastPostId;
let PostBlazor;

let postVisibility = false;

window.addEventListener("scroll", checkingLastPostVisibility)

function checkingLastPostVisibility(){
    if(LastPostId != null && !postVisibility){
        var post = document.getElementById(LastPostId);
        var position = post.getBoundingClientRect();

        if(position.top < window.innerHeight && position.bottom >= 0) {
            console.log("Last post is starting to be visible on the viewport");
            PostBlazor.invokeMethodAsync('LoadMorePosts');
            postVisibility = true;
        }
        else{
            postVisibility = false;
        }
    }
}

function setLastPostId(id){
    
    if(LastPostId !== id){
        console.log("last post id is set:" + id)
        LastPostId = id;
    }
  
}

function initializeComponent(dotnet){
    if(PostBlazor == null)
        PostBlazor = dotnet
}