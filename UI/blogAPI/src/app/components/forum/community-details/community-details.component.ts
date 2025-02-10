import { Component, Input, OnInit } from '@angular/core';
import { ForumService } from '../services/forum.service';
import { Observable } from 'rxjs';
import { ForumCommunity } from '../models/forum-community.model';
import { ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-community-details',
  imports: [CommonModule],
  templateUrl: './community-details.component.html',
  styleUrl: './community-details.component.css'
})
export class CommunityDetailsComponent {
  @Input() communityDetails$?: Observable<ForumCommunity>;
  forumId?: number;
  constructor(private forumService:ForumService, private route: ActivatedRoute) {}
  ngOnInit(): void {
    this.forumId = parseInt(this.route.snapshot.paramMap.get('id') || '');
  }

}
