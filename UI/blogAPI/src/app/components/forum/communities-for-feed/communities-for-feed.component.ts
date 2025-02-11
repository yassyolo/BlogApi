import { Component, OnInit } from '@angular/core';
import { ForumService } from '../services/forum.service';
import { Observable, tap } from 'rxjs';
import { CommonModule } from '@angular/common';
import { RouterLink, RouterModule } from '@angular/router';
import { CommunitiesForFeed } from '../models/communities-for-feed.model';
import { TruncateStringPipe } from '../../bookmark/truncate-string.pipe';

@Component({
  selector: 'app-communities-for-feed',
  imports: [CommonModule, RouterLink, TruncateStringPipe, RouterModule],
  standalone: true,
  templateUrl: './communities-for-feed.component.html',
  styleUrl: './communities-for-feed.component.css'
})
export class CommunitiesForFeedComponent implements OnInit {
  communities$?: Observable<CommunitiesForFeed[]>;
  currentIndex: number = 0;
  communitiesPerPage: number = 5;
  constructor(private forumService: ForumService) { }

  ngOnInit(): void {
    this.communities$ = this.forumService.getCommunitiesForFeed().pipe(
      tap(communities => this.communitiesPerPage = communities.length)
    );
  }

  prevSlide() : void{
    if(this.currentIndex > 0){
      this.currentIndex--;
    }
  }

  nextSlide() : void{
    if(this.currentIndex < this.communitiesPerPage - 1){
      this.currentIndex++;
    }
  }



}
