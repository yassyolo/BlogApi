import { Component, OnInit } from '@angular/core';
import { AuthorBlogDetailsComponent } from '../../blogs/author-blog-details/author-blog-details.component';
import { CommonModule } from '@angular/common';
import { CategorySelectorComponent } from '../../blogs/category-selector/category-selector.component';
import { StreamService } from '../service/stream.service';
import { Observable, switchMap } from 'rxjs';
import { StreamDetails } from '../models/stream-details.model';
import { ActivatedRoute } from '@angular/router';
import { BroadcastService } from '../service/broadcast.service';

@Component({
  selector: 'app-stream-details',
  imports: [AuthorBlogDetailsComponent, CommonModule, CategorySelectorComponent],
  templateUrl: './stream-details.component.html',
  styleUrl: './stream-details.component.css'
})
export class StreamDetailsComponent implements OnInit{
  stream$?: Observable<StreamDetails>;
  streamId?: number;
  isBroadcaster: boolean = false;
  constructor(private streamService: StreamService, private route: ActivatedRoute, private broadcastService: BroadcastService) { }

  ngOnInit(): void {
    this.stream$ = this.route.params.pipe(switchMap(params => {
      this.streamId = parseInt(params['id']);
      return this.streamService.getStreamDetails(this.streamId);
    }) )
  }

  onCategoryChange(categoryId: number) : void{
    this.streamService.getStreamList(null, categoryId);
  }

  joinStream(streamId: number) : void{
    this.streamService.joinStream(streamId);
  }

  leaveStream(streamId: number) : void{
    this.streamService.leaveStream(streamId);
  }






}
