import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ForumService } from '../services/forum.service';
import { Observable } from 'rxjs';
import { MostPopularCommunities } from '../models/most-popular-communities.model';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-most-popular-communities',
  imports: [CommonModule, RouterLink],
  standalone: true,
  templateUrl: './most-popular-communities.component.html',
  styleUrl: './most-popular-communities.component.css'
})
export class MostPopularCommunitiesComponent implements OnInit {
  communities$?: Observable<MostPopularCommunities[]> 
  constructor(private forumService: ForumService) { }

  ngOnInit(): void {
    this.communities$ = this.forumService.getMostPopularCommunities();
  }

}
