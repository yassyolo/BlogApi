import { Component, OnInit } from '@angular/core';
import { AchievementsService } from '../services/achievements.service';
import { Observable } from 'rxjs';
import { MyRanking } from '../models/my-ranking.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-my-ranking',
  imports: [CommonModule],
  standalone: true,
  templateUrl: './my-ranking.component.html',
  styleUrl: './my-ranking.component.css'
})
export class MyRankingComponent implements OnInit {
  myRanking$?: Observable<MyRanking>;
  constructor(private achievementsService: AchievementsService) { }

  ngOnInit(): void {
    this.myRanking$ = this.achievementsService.getMyRanking();
  }

}
