import { Component, OnInit } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { Achievement } from '../models/achievement.model';
import { AchievementsService } from '../services/achievements.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-personal-achievements',
  imports: [CommonModule],
  standalone: true,
  templateUrl: './personal-achievements.component.html',
  styleUrl: './personal-achievements.component.css'
})
export class PersonalAchievementsComponent implements OnInit {

  achievemnts$?: Observable<Achievement[]>;

  achievementCategories = [
    { type: 1, title: '<i class="fa-solid fa-glasses" style="color: #FF4561;"></i> Reading' },
    { type: 2, title: '<i class="fa-solid fa-bookmark"></i> Bookmark' },
    { type: 3, title: '<i class="fa-solid fa-pen-nib"></i> Blogging' },
    { type: 4, title: '<i class="fa-brands fa-microblog"></i> Commenting' }
  ];
  constructor(private achievementsService: AchievementsService) { }

  ngOnInit(): void {
    this.achievemnts$ = this.achievementsService.getAchievements()
  }

}
