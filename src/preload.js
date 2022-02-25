const fs = require('fs');
const ipc = require('electron').ipcRenderer;
const path = require('path');
const configPath = path.join(ipc.sendSync('getPath'), 'EXILED', 'Configs', 'ServerPanelData.json');

ipc.once('startListener', (evt) => JSONListener());

function timeout(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}

JSONListener = async function(){
    while (true){
        try {
            await timeout(3000);
            let doc = JSON.parse(fs.readFileSync(configPath))
            let table = document.getElementById("list").getElementsByTagName('tbody')[0];
            let count = 0;
            for (var key in doc.Ply){ // do refactoring later
                let text = document.createTextNode(doc.Ply[key].Nickname);
                if (count < table.rows.length) {
                    table.rows[count].cells[0].children[0] = text;
                } else {
                    table.insertRow(count).insertCell().appendChild(text);
                }
                count++;
            }
        }
        catch (e){
            console.log(e);
        }
    }
}