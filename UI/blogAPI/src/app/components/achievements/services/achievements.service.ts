import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Achievement } from '../models/achievement.model';
import { TopUsers } from '../models/top-users.model';
import { TopRankingBlog } from '../models/top-ranking-blog.model';
import { MyRanking } from '../models/my-ranking.model';

@Injectable({
  providedIn: 'root'
})
export class AchievementsService {

  private apiUrl = 'https://localhost:5001/Achievement';
  constructor(private http: HttpClient ) { }

  getAchievements() : Observable<Achievement[]>{
    return this.http.get<Achievement[]>(`${this.apiUrl}`);
  }

  topUsers() : Observable<TopUsers[]>{
    return this.http.get<TopUsers[]>(`${this.apiUrl}/top-users`);
  }

  topRankingBlogs(from?: string) : Observable<TopRankingBlog[]>{
    let params = new HttpParams();
    if(from){
      params = params.set('from', from);
    }
    return this.http.get<TopRankingBlog[]>(`${this.apiUrl}/top-blogs`, { params });
  }

  getMyRanking() : Observable<MyRanking>{
    return this.http.get<MyRanking>(`${this.apiUrl}/my-ranking`);
  }

}
