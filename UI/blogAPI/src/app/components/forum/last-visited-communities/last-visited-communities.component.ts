import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { ForumService } from '../services/forum.service';
import { Observable } from 'rxjs';
import { LastVisitedCommunities } from '../models/last-visited-communities.model';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-last-visited-communities',
  imports: [CommonModule, RouterLink],
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './last-visited-communities.component.html',
  styleUrl: './last-visited-communities.component.css'
})
export class LastVisitedCommunitiesComponent implements OnInit {
  communities$?: Observable<LastVisitedCommunities[]>;
  constructor(private forumService: ForumService) { }

  ngOnInit(): void {
    this.communities$ = this.forumService.getLastVisitedCommunities();
  }

}
