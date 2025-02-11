import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { BroadcastService } from '../service/broadcast.service';

@Component({
  selector: 'app-viewer',
  imports: [],
  templateUrl: './viewer.component.html',
  styleUrl: './viewer.component.css'
})
export class ViewerComponent implements OnInit{
@ViewChild('video') videoElement!: ElementRef;
private peerConnection = new RTCPeerConnection();
  constructor(private broadcastService:BroadcastService){}
  ngOnInit(): void {
    this.broadcastService.listen('broadcasterAnswer', async (answer:RTCSessionDescriptionInit) => {
      await this.peerConnection.setRemoteDescription(answer);
    });
  }
}
