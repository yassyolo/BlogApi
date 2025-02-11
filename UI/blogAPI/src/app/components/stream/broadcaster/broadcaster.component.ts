import { Component, ElementRef, ViewChild } from '@angular/core';
import { BroadcastService } from '../service/broadcast.service';

@Component({
  selector: 'app-broadcaster',
  imports: [],
  templateUrl: './broadcaster.component.html',
  styleUrl: './broadcaster.component.css'
})
export class BroadcasterComponent {
  @ViewChild('video') videoElement!: ElementRef;
  private peerConnection = new RTCPeerConnection();

  constructor(private broadcastService:BroadcastService){}

  async startBroadcast(){
    const stream = await navigator.mediaDevices.getUserMedia({video: true, audio: true});
    this.videoElement.nativeElement.srcObject = stream;
    stream.getTracks().forEach(track => this.peerConnection.addTrack(track, stream));

    const offer = await this.peerConnection.createOffer();
    await this.peerConnection.setLocalDescription(offer);
    this.broadcastService.sendMessage('broadcaster', offer);
  }

}
