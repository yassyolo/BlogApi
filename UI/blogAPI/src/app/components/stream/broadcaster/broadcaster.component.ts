import { Component, ElementRef, ViewChild } from '@angular/core';
import { BroadcastService } from '../service/broadcast.service';
import io  from 'socket.io-client';


@Component({
  selector: 'app-broadcaster',
  imports: [],
  templateUrl: './broadcaster.component.html',
  styleUrl: './broadcaster.component.css'
})
export class BroadcasterComponent {
  private socket = io('http://localhost:3000');
  private peerConnection: RTCPeerConnection;

  constructor() {
    this.peerConnection = new RTCPeerConnection();
  }

  async startBroadcast(): Promise<void> {
    const stream = await navigator.mediaDevices.getUserMedia({ video: true, audio: true });

    stream.getTracks().forEach(track => {
      this.peerConnection.addTrack(track, stream);
    });

    const offer = await this.peerConnection.createOffer();
    await this.peerConnection.setLocalDescription(offer);
    
    this.socket.emit('broadcaster', offer);

    this.socket.on('viewerOffer', async ({ offer, viewerId }: { offer: RTCSessionDescriptionInit, viewerId: string }) => {
      await this.peerConnection.setRemoteDescription(new RTCSessionDescription(offer));
      const answer = await this.peerConnection.createAnswer();
      await this.peerConnection.setLocalDescription(answer);
      
      this.socket.emit('broadcasterAnswerViewer', { answer, viewerId });
    });
  }
}

