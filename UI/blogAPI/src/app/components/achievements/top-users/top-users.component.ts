import { Component, OnInit } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { TopUsers } from '../models/top-users.model';
import { AchievementsService } from '../services/achievements.service';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { MyRankingComponent } from "../my-ranking/my-ranking.component";

@Component({
  selector: 'app-top-users',
  imports: [CommonModule, RouterLink, MyRankingComponent],
  templateUrl: './top-users.component.html',
  styleUrl: './top-users.component.css',
  standalone: true
})
export class TopUsersComponent implements OnInit {

  topUsers$?: Observable<TopUsers[]>;
  top3Users: TopUsers[] = [];
  constructor(private achievementsService:AchievementsService) { }

  ngOnInit(): void {
    this.topUsers$ = this.achievementsService.topUsers().pipe(
      tap(users => {
        this.top3Users = users.slice(0, 3)
        console.log(this.top3Users)
  })
    );
    this.topUsers$.subscribe();
}

}
