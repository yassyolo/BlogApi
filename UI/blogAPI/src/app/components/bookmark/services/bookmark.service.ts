import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BookmarkListSelect } from '../models/bookmark-list-select.model';
import { AddToExistingFolder } from '../models/add-to-existing-folder.model';
import { CreateNewFolder } from '../models/add-new-folder.model';
import { BookmarkFolderList } from '../models/bookmark-folder-list.model';
import { BookmarkIndex } from '../models/bookmark-index.model';

@Injectable({
  providedIn: 'root'
})
export class BookmarkService {

  private apiUrl = 'https://localhost:5001/Bookmark';
  constructor(private http: HttpClient) { }

  getAllBookMarksForAdding() : Observable<BookmarkListSelect[]>{
    return this.http.get<BookmarkListSelect[]>(`${this.apiUrl}/all-folders-for-adding`);
  }

  addToExistingFolder(request : AddToExistingFolder) : Observable<any>{
    return this.http.post(`${this.apiUrl}/add-to-existing-folder`, request);
  }

  createNewFolder(request: CreateNewFolder) : Observable<any>{
    return this.http.post(`${this.apiUrl}/create-new-folder`, request);
  }

  getAllBookmarkFolders(query?: string, sorting?: string) : Observable<BookmarkFolderList[]>{
    let formData = new FormData();
    if(query){
      formData.append('query', query);
    }
    if(sorting){
      formData.append('sorting', sorting);
    }
    return this.http.post<BookmarkFolderList[]>(`${this.apiUrl}/all-folders`, formData);
  }

  getBookmarksByFolderId(id: number | undefined, query?: string, sorting?: string) : Observable<BookmarkIndex[]>{ 
    let formData = new FormData();
    if(query){
      formData.append('query', query);
    }
    if(sorting){
      formData.append('sorting', sorting);
    }
    return this.http.post<BookmarkIndex[]>(`${this.apiUrl}/folder/${id}`, formData);
  }

  getBookmarkFolderForDelete(id: number) : Observable<BookmarkFolderList>{
    return this.http.get<BookmarkFolderList>(`${this.apiUrl}/folder/${id}/delete`);
  }

  deleteBookmarkFolder(id: number) : Observable<any>{
    return this.http.delete(`${this.apiUrl}/folder/${id}`);
  }
}
