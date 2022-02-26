const { contextBridge, ipcRenderer } = require('electron');
const fs = require('fs');
const path = require('path');
const configPath = path.join(ipcRenderer.sendSync('getPath'), 'EXILED', 'Configs', 'ServerPanelData.json');

export const API = {
  getText: () => {
    let text = fs.readFileSync(configPath, 'utf8');
    return text;
  }
}

contextBridge.exposeInMainWorld('api', API)