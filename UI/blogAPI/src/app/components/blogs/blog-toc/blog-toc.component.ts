import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { BlogDetails } from '../models/blog-details.model';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { BehaviorSubject, map, Observable } from 'rxjs';

@Component({
  selector: 'app-blog-toc',
  imports: [CommonModule, RouterLink],
  standalone: true,
  templateUrl: './blog-toc.component.html',
  styleUrl: './blog-toc.component.css'
})
export class BlogTocComponent implements OnInit, OnChanges {
  @Input() set blogToc(value : {title: string; anchor: string, level: number}[]){
    this.blogTocSubject.next(value);
  }
  @Input() set id(value: number){
    this.idSubject.next(value);
  }
  isEmpty$?: Observable<boolean>;

  private blogTocSubject= new BehaviorSubject<{title: string; anchor: string, level: number}[]>([]);
  blogToc$ = this.blogTocSubject.asObservable();

  private idSubject = new BehaviorSubject<number>(0);
  id$ = this.idSubject.asObservable();

  constructor() { }
  ngOnChanges(changes: SimpleChanges): void {
    if(changes['blogToc']){
      this.blogTocSubject.next([...changes['blogToc'].currentValue]);
    }
    if(changes['id']){
      this.idSubject.next(changes['id'].currentValue);  
    }
  }

  ngOnInit(): void {
    this.isEmpty$  = this.blogToc$.pipe(
      map(toc => toc.length === 0)
    )
  } 
}
