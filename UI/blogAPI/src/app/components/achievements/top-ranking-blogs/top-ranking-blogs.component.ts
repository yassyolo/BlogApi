import { Component, OnInit } from '@angular/core';
import { from, Observable, tap, map } from 'rxjs';
import { TopRankingBlog } from '../models/top-ranking-blog.model';
import { AchievementsService } from '../services/achievements.service';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-top-ranking-blogs',
  imports: [CommonModule, RouterLink],
  templateUrl: './top-ranking-blogs.component.html',
  styleUrl: './top-ranking-blogs.component.css',
  standalone: true
})
export class TopRankingBlogsComponent implements OnInit {
  topRankingBlogs$?: Observable<TopRankingBlog[]>;
  top3RankingBlogs?:TopRankingBlog[];
  from?: string;
  constructor(private achievementService: AchievementsService) { }

  ngOnInit(): void {
    this.topRankingBlogs$ = this.achievementService.topRankingBlogs(this.from).pipe(
      map(blogs => blogs.slice(0, 3)),
      tap(top3Blogs => this.top3RankingBlogs = top3Blogs)
    );
  }

}
