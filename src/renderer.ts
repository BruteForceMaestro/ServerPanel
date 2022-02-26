var selectedCell: HTMLTableCellElement;

function timeout(ms: number) {
    return new Promise(resolve => setTimeout(resolve, ms));
}

function anim(cell:any, enter: boolean){
    let name = '';
    if (selectedCell != cell){
        let version = enter ? 'preview ' : 'regular ';
        name += version;
    }
    else {
        name += 'selected '
    }
    let anim = enter ? 'anim' : 'animrev';
    cell.className = name + anim;
}

function onclicked(cell: any){
    if (selectedCell != undefined && selectedCell != cell){
        selectedCell.className = 'regular';
    }
    selectedCell = cell;
    cell.className = 'animrev selected';
}

async function JSONListener(){
    while (true){
        try {
            await timeout(3000);
            let doc = JSON.parse(window.api.getText());
            PlayerHandler(doc);
        }
        catch (e){
            console.log(e);
        }
    }
}

function PlayerHandler(doc: any){
    let table = document.getElementById("list")!.getElementsByTagName('tbody')[0];
    let count = 0;
    for (var key in doc.Ply){ // do refactoring later
        let text = document.createTextNode(doc.Ply[key].Nickname);
        if (count < table.rows.length) {
            if (count == doc.Ply.length - 1){
                for (let idx = 0; idx < table.rows.length; idx++){
                    if (idx <= count){
                        continue;
                    }
                    table.deleteRow(idx);
                }
            }
            let parent = table.rows[count].cells[0];
            let child = parent.childNodes[0];
            parent.replaceChild(text, child)
        } else {
            let cell = table.insertRow().insertCell();
            cell.addEventListener('mouseenter', (event) => anim(event.target, true))
            cell.addEventListener('mouseleave', (event) => anim(event.target, false))
            cell.addEventListener('click', (event) => onclicked(event.target))
            cell.appendChild(text);
        }
        count++;
    }
}

function ToggleOnline(online: boolean){
    let toggleText = document.getElementById("toggle");
    toggleText!.innerHTML = online ? "Online" : "Offline";
    toggleText!.style.color = online ? "green" : "red";
}

JSONListener();
