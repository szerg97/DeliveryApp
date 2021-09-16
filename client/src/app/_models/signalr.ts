import { Predicate } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { Offer } from './offer';

export class Signalr{
    private hubConnection: signalR.HubConnection;

    constructor(uri: string) {
        this.hubConnection = new signalR.HubConnectionBuilder()
            .withUrl(uri)
            .build();
    }

    register(methodname: string, method: Predicate<any>){
        this.hubConnection.on(methodname, method);
    }

    start(){
        this.hubConnection
            .start()
            .then(() => console.log('Connection started'))
            .catch(err => console.log('Error while starting connection: ' + err));
    }
}