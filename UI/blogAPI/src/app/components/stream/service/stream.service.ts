import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { StreamFeedComponent } from '../stream-feed/stream-feed.component';
import { Observable } from 'rxjs';
import { StreamForFeed } from '../models/stream-for-feed.model';
import { StreamDetails } from '../models/stream-details.model';

@Injectable({
  providedIn: 'root'
})
export class StreamService {
  


  private apiUrl = 'https://localhost:5001/Stream';
  constructor(private http: HttpClient) { }

  getStreamList(query? : string | null ,categoryId?: number | null) : Observable<StreamForFeed[]>{ 
    let params = new HttpParams();
    if(categoryId){
      params = params.set('categoryId', categoryId);
    }
    if(query){
      params = params.set('query', query);
    }
    return this.http.get<StreamForFeed[]>(`${this.apiUrl}/stream`, {params});
  }

  joinStream(streamId: number) : Observable<any>{
    return this.http.post(`${this.apiUrl}/stream/${streamId}/join`, {});
  }

  getStreamDetails(streamId: number) : Observable<StreamDetails>{
    return this.http.get<StreamDetails>(`${this.apiUrl}/stream/${streamId}`);
  }

  leaveStream(streamId: number)  : Observable<any>{
    return this.http.post(`${this.apiUrl}/stream/${streamId}/leave`, {});
  }
}
