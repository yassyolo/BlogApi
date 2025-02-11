import { Injectable } from '@angular/core';
import io from 'socket.io-client'; 

@Injectable({
  providedIn: 'root'
})
export class BroadcastService {
  private socket: any;

  constructor() { 
    this.socket = io('http://localhost:3000'); }

  sendMessage(event: string, data: any): void {
    this.socket.emit(event, data);
  }

  listen(event: string, callback: (data: any) => void): void {
    this.socket.on(event, callback);
  }
}