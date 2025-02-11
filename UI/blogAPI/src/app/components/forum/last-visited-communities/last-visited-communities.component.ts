import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { ForumService } from '../services/forum.service';
import { Observable } from 'rxjs';
import { LastVisitedCommunities } from '../models/last-visited-communities.model';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-last-visited-communities',
  imports: [CommonModule],
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './last-visited-communities.component.html',
  styleUrl: './last-visited-communities.component.css'
})
export class LastVisitedCommunitiesComponent implements OnInit {
  communities$?: Observable<LastVisitedCommunities[]>;
  constructor(private forumService: ForumService, private router: Router) { }

  ngOnInit(): void {
    this.communities$ = this.forumService.getLastVisitedCommunities();
  }

  onCommunityChange(forumId: number): void {
    this.router.navigate([`/forum/community/${forumId}`]);
  }

}
