import { HubConnection } from "@microsoft/signalr";

export type GameAction = {
    $type: string;
    action: any;
}

export class GameConnection {
    onUpdateState?: (arg: any) => void;
    notify?: (arg: any) => void;
    
    constructor(private _hub: HubConnection) {
        _hub.on('GameState', (args) => this.onUpdateState?.(args))  
        _hub.on('Notify', (args) => this.notify?.(args))  
    }
    
    public send(action: GameAction) {
        this._hub.send('GameAction', action)
    }
    
    public disconnect() {
        return this._hub.stop();
    }

    public connect() {
        return this._hub.start();
    }
}