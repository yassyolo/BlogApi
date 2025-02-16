import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ForumCategory } from '../models/forum-category.model';
import { LastVisitedCommunities } from '../models/last-visited-communities.model';
import { MostPopularCommunities } from '../models/most-popular-communities.model';
import { CommunitiesForFeed } from '../models/communities-for-feed.model';
import { ForumPostsForFeed } from '../models/forum-posts-for-feed.model';
import { CreateForumPost } from '../models/create-forum-post.model';
import { ForumCommunity } from '../models/forum-community.model';
import { ForumPostDetails } from '../models/forum-post-details.model';

@Injectable({
  providedIn: 'root'
})
export class ForumService {


  private apiUrl = 'https://localhost:5001/Forum';
  constructor(private http: HttpClient) { }

  getAllcategories() : Observable<ForumCategory[]>{ 
    return this.http.get<ForumCategory[]>(`${this.apiUrl}/categories`);
  }

  getLastVisitedCommunities() : Observable<LastVisitedCommunities[]>{ 
    return this.http.get<LastVisitedCommunities[]>(`${this.apiUrl}/communities/last-visited`);
  }

  getMostPopularCommunities() : Observable<MostPopularCommunities[]>{
    return this.http.get<MostPopularCommunities[]>(`${this.apiUrl}/communities/most-popular`);
  }

  getCommunitiesForFeed() : Observable<CommunitiesForFeed[]>{
    return this.http.get<CommunitiesForFeed[]>(`${this.apiUrl}/communities/feed`);
  }

  getFeed(sorting?: string | null, forumId?: number | null, categoryId?: number | null): Observable<ForumPostsForFeed[]>{
    let params = new HttpParams();
    if(sorting){
      params = params.set('sorting', sorting);
    }
    if(forumId){
      params = params.set('forumId', forumId);
    }
    if(categoryId){
      params = params.set('categoryId', categoryId);
    }
    return this.http.get<ForumPostsForFeed[]>(`${this.apiUrl}/feed`, {params});
  }

  getForumCommunitiesAndPostsByCategory(categoryId: number) : Observable<any>{
    return this.http.get(`${this.apiUrl}/communities/${categoryId}`);
  }

  downvotePost(postId: number) : Observable<any>{
    return this.http.put(`${this.apiUrl}/posts/${postId}/downvote`, {});
  }
  upvotePost(postId: number) : Observable<any>{
    return this.http.put(`${this.apiUrl}/posts/${postId}/upvote`, {});
  }

  joinCommunity(id: number): Observable<any>{
    return this.http.post(`${this.apiUrl}/community/${id}/join`, {});
  }

  leaveCommunity(id: number): Observable<any>{
    return this.http.post(`${this.apiUrl}/community/${id}/leave`, {});

  }

  createForumPost(request: CreateForumPost) : Observable<any>{
    return this.http.post(`${this.apiUrl}/posts`, request);
  }

  deleteForumPost(id: number) : Observable<any>{
    return this.http.delete(`${this.apiUrl}/post/${id}`);
  }

  getForumCommunity(id: number) : Observable<ForumCommunity>{
    return this.http.get<ForumCommunity>(`${this.apiUrl}/community/${id}`);
  }

  getForumCategoryDetails(id: number) : Observable<ForumCategory>{
    return this.http.get<ForumCategory>(`${this.apiUrl}/category/${id}`);
  }

  getForumPostDetails(id: number) : Observable<ForumPostDetails>{
    return this.http.get<ForumPostDetails>(`${this.apiUrl}/posts/${id}`);
  }

  upVoteComment(id: number, commentId: number) : Observable<any>{
    return this.http.put(`${this.apiUrl}/post/${id}/comments/${commentId}/upvote`, {});
  }

  downVoteComment(id: number, commentId: number) : Observable<any>{
    return this.http.put(`${this.apiUrl}/post/${id}/comments/${commentId}/downvote`, {});
  }

  createForumComment(id: number, comment: string) : Observable<any>{
    return this.http.post(`${this.apiUrl}/post/${id}/comments`, JSON.stringify(comment), {
      headers: { 'Content-Type': 'application/json' }
    });
  }

  getForumCommunitiesByCategory(id: number) : Observable<MostPopularCommunities[]>{
    return this.http.get<MostPopularCommunities[]>(`${this.apiUrl}/category/${id}/communities`);
  }
}
