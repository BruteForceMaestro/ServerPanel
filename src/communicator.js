var online = false;

function ToggleOnline(){
    online = !online;
    let toggleText = document.getElementById("toggle");
    toggleText.innerHTML = online ? "Online" : "Offline";
    toggleText.style.color = online ? "green" : "red";
}
