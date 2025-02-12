import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../services/category.service';
import { BlogService } from '../services/blog.service';
import { BlogRequest } from '../models/blog-request.model';
import { generate, Observable } from 'rxjs';
import { CategoryIndex } from '../models/category-index.model';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { QuillModule } from 'ngx-quill';
import { QuillModules } from 'ngx-quill';
import { CommonModule } from '@angular/common';
import { TagIndex } from '../models/tag-index.model';
import { TagsService } from '../services/tags.service';

@Component({
  selector: 'app-edit-blog',
  imports: [FormsModule, QuillModule, CommonModule],
  templateUrl: './edit-blog.component.html',
  styleUrl: './edit-blog.component.css'
})

  export class EditBlogComponent implements OnInit {
    blogRequest: BlogRequest = {
      id: 0,
      title: '',
      slug: '',
      content: '',
      categoryId: 0,
      newTags: [] as string[],
      tagIds: [] as number[],
      images: [] as File[],
      toc: [] as { title: string, anchor: string, level: number }[],
    };
  
    categories$: Observable<CategoryIndex[]> | undefined;
    tags$: Observable<TagIndex[]> | undefined;
    selectedTags: number[] = []; 
    newTags: string[] = [];
    newTagsInput: string = ''; 
    imagePreviews: string[] = [];
  
    constructor(
      private categoryService: CategoryService,
      private blogService: BlogService,
      private router: Router,
      private route: ActivatedRoute,
      private tagsService: TagsService
    ) {}
  
    ngOnInit(): void {
      this.categories$ = this.categoryService.getCategories();
      this.tags$ = this.tagsService.getTags();
  
      const blogId = parseInt(this.route.snapshot.paramMap.get('id') || '0');
      if (blogId) {
        this.loadBlog(blogId); 
      }
    }
    editorModules: QuillModules = {
      toolbar: [
        ['bold', 'italic', 'underline'],
        [{ list: 'ordered' }, { list: 'bullet' }],
        ['link', 'blockquote'],
        [{ header: '1' }, { header: '2' }],
      ],
    };
  
    loadBlog(blogId: number): void {
      this.blogService.getBlogBySlug(blogId).subscribe((blogData) => {
        this.blogRequest = { ...blogData };
        this.selectedTags = blogData.tagIds || [];
        this.newTags = blogData.newTags || [];
        //TODO: Add image preview
        //this.imagePreviews = blogData.images || [];
      });
    }
  
    onTagSelect(event: any): void {
      const tagId = +event.target.value;
      if(!this.selectedTags.includes(tagId)){
        this.selectedTags.push(tagId);
      } 
      this.updateTags();
    }
  
    onAddNewTags(): void {
      if (this.newTagsInput) {
        const customTags = this.newTagsInput.split(',').map(tag => tag.trim());
        customTags.forEach(tag => {
          if (!this.newTags.includes(tag)) {
            this.newTags.push(tag);
          }
        });
        this.newTagsInput = '';
        this.updateTags();
      }
    }
  
    updateTags(): void {
      this.blogRequest.tagIds = [...this.selectedTags];
      this.blogRequest.newTags =[...this.newTags];
    }

    generateToc(): { title: string, anchor: string, level: number }[] {
      const toc: { title: string, anchor: string, level: number }[] = [];
      const contentDelta = this.blogRequest.content;
      console.log(contentDelta);
      let currentLevel = 0;
  
      const parser = new DOMParser();
      const doc = parser.parseFromString(contentDelta, 'text/html');
  
      const headings = Array.from(doc.querySelectorAll('h1, h2'));
  
      headings.forEach((heading) => {
      const title = (heading as HTMLElement).textContent?.trim() || '';
      const level = heading.tagName === 'H1' ? 1 : heading.tagName === 'H2' ? 2 : 0;
      const anchor = title.toLowerCase().replace(/\s+/g, '-').replace(/[^\w-]+/g, '');
  
      toc.push({ title, anchor, level });
    });
    console.log(toc);
  
    return toc;
    }
  
    onSubmit(): void {
      if (this.isFormValid()) {
        this.blogRequest.slug = this.generateSlug(this.blogRequest.title);
        this.blogRequest.toc = this.generateToc();
        console.log(this.blogRequest);
  
        if (this.blogRequest.slug) {
          this.blogService.updateBlog(this.blogRequest).subscribe((response) => {
            this.router.navigate(['/blogs', response.slug]);
          }, (error) => {
            console.log(error);
          });
        }
      }
    }
  
    isFormValid(): boolean {
      return this.blogRequest.title && this.blogRequest.content && this.blogRequest.categoryId;
    }
  
    generateSlug(title: string): string {
      return title ? title.toLowerCase().replace(/\s+/g, '-').replace(/[^\w-]+/g, '') : '';
    }
  
    onImageChange(event: any): void {
      const files = event.target.files;
      if (files) {
        const currentImages: File[] = this.blogRequest.images || [];
        for (let i = 0; i < files.length; i++) {
          const file = files[i];
          const reader = new FileReader();
      
          reader.onload = () => {
            this.imagePreviews.push(reader.result as string);
          };
      
          reader.readAsDataURL(file);  
      
          currentImages.push(file);
        }
      
        this.blogRequest.images = currentImages;  
      }
    }
    
  }