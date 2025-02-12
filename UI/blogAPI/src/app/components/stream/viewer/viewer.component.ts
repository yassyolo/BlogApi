import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { BroadcastService } from '../service/broadcast.service';

@Component({
  selector: 'app-viewer',
  imports: [],
  templateUrl: './viewer.component.html',
  styleUrl: './viewer.component.css'
})
export class ViewerComponent{
  private socket = io('http://localhost:3000');
  private peerConnection: RTCPeerConnection;

  constructor() {
    this.peerConnection = new RTCPeerConnection();
  }

  async joinStream(): Promise<void> {
    const offer = await this.peerConnection.createOffer();
    await this.peerConnection.setLocalDescription(offer);
    
    this.socket.emit('viewer', offer);

    this.socket.on('broadcasterAnswer', async (answer: RTCSessionDescriptionInit) => {
      await this.peerConnection.setRemoteDescription(new RTCSessionDescription(answer));
    });

    this.peerConnection.ontrack = (event) => {
      const remoteStream = event.streams[0];
      const videoElement = document.getElementById('viewerVideo') as HTMLVideoElement;
      videoElement.srcObject = remoteStream;
    };
  }
}
