import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TagIndex } from '../models/tag-index.model';

@Injectable({
  providedIn: 'root'
})
export class TagsService {

  private apiUrl = 'https://localhost:5001/Tags';
  constructor(private hhtp: HttpClient) { }

  getTags() : Observable<TagIndex[]>{
    return this.hhtp.get<TagIndex[]>(`${this.apiUrl}`);
  }
}
