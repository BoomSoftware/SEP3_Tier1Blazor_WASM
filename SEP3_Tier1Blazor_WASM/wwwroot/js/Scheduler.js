
function getElementTop(elementId){
    return document.getElementById(elementId).getBoundingClientRect().top
}

function getElementLeft(elementId){
    return document.getElementById(elementId).getBoundingClientRect().left;
}

function getElementWidth(elementId){
    return document.getElementById(elementId).offsetWidth;
}

function getWindowWidth(){
    return window.innerWidth;
}
function getWindowHeight(){
    return window.innerHeight;
}




