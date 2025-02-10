import { Component, Input, OnInit } from '@angular/core';
import { BlogDetails } from '../models/blog-details.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-blog-toc',
  imports: [CommonModule],
  standalone: true,
  templateUrl: './blog-toc.component.html',
  styleUrl: './blog-toc.component.css'
})
export class BlogTocComponent implements OnInit {
  @Input() blogToc?: {title: string; anchor: string, level: number}[] = [];
  @Input() id: number = 0;
  isEmpty: boolean = true;
  constructor() { }

  ngOnInit(): void {
    if(this.blogToc && this.blogToc.length > 0){
      this.isEmpty = false;
    }
 
  } 
}
