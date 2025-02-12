import { Component, Input, OnInit } from '@angular/core';
import { ForumService } from '../services/forum.service';
import { catchError, distinctUntilChanged, Observable, of, switchMap } from 'rxjs';
import { ForumCommunity } from '../models/forum-community.model';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-community-details',
  imports: [CommonModule],
  templateUrl: './community-details.component.html',
  styleUrl: './community-details.component.css'
})
export class CommunityDetailsComponent {
  @Input() showRules?: boolean;
  @Input() communityDetails$?: Observable<ForumCommunity>;
  
  constructor(private forumService:ForumService, private route: ActivatedRoute) {}
  
  ngOnInit(): void {
    this.communityDetails$ = this.route.paramMap.pipe(
      distinctUntilChanged((prev: ParamMap, curr: ParamMap) => prev.get('id') === curr.get('id')), 
      switchMap(params => {
        const forumId = parseInt(params.get('id') || '0', 10);
        return this.forumService.getForumCommunity(forumId).pipe(
          catchError(error => {
            console.error('Error fetching community details:', error);
            return of(); 
          })
        );
      })
    );
  }

}
