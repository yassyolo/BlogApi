import { Component, OnInit } from '@angular/core';
import { BlogRequest } from '../models/blog-request.model';
import { FormsModule } from '@angular/forms';
import { QuillModule, QuillModules } from 'ngx-quill';
import { CategoryService } from '../services/category.service';
import { Observable } from 'rxjs';
import { CategoryIndex } from '../models/category-index.model';
import { BlogService } from '../services/blog.service';
import { Router } from '@angular/router';
import { TagIndex } from '../models/tag-index.model';
import { TagsService } from '../services/tags.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-blog-write',
  imports: [FormsModule, QuillModule, CommonModule],
  templateUrl: './blog-write.component.html',
  styleUrls: ['./blog-write.component.css'],
  standalone: true
})
export class BlogWriteComponent implements OnInit {
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
  imagePreviews: string[] = [];
  selectedTags: {id: number, name: string}[] = [];
  newTags: string[] = [];
  newTagsInput: string = '';
  isPreview: boolean = false;

  constructor(private categoryService: CategoryService, 
    private blogService: BlogService, 
    private router: Router,
    private tagsService: TagsService) {}

  ngOnInit(): void {
    this.categories$ = this.categoryService.getCategories();
    this.tags$ = this.tagsService.getTags();
  }

  editorModules: QuillModules = {
    toolbar: [
      ['bold', 'italic', 'underline'],
      [{ list: 'ordered' }, { list: 'bullet' }],
      ['link', 'blockquote'],
      [{ header: '1' }, { header: '2' }],
    ],
  };

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

      this.blogService.createBlog(this.blogRequest).subscribe((response) => {
        this.router.navigate(['/blogs', response.slug]);
      }, (error) => {
        console.log(error);
      });
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
      const currentImages = this.blogRequest.images || [];
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

  onTagSelect(event: any): void{
    const selectedTag = event.target as HTMLSelectElement;
    const selectedTagId = Number(selectedTag.value);
    const selectedName = selectedTag.options[selectedTag.selectedIndex].text;  
    if(!this.selectedTags.some(x => x.id === selectedTagId)){
      this.selectedTags.push({id: selectedTagId, name: selectedName});
    }
    this.blogRequest.tagIds = this.selectedTags.map(tag => tag.id);
  }

  onRemoveSelectedTag(tagId: number): void{
    this.selectedTags = this.selectedTags.filter(tag => tag.id !== tagId);
    this.blogRequest.tagIds = this.selectedTags.map(tag => tag.id);
  }

  onAddNewTags(): void {
    console.log('New Tags:', this.newTagsInput);

    if(this.newTagsInput.trim()){
      const newTags = this.newTagsInput.split(',').map((tag) => tag.trim());
      newTags.forEach((tag) => {
        if(!this.newTags.includes(tag)){
        this.newTags.push(tag);
        }
      });
      this.newTagsInput = '';
      this.blogRequest.newTags = [...this.newTags];
    }
  }

  onRemoveNewTag(tag: string): void {
    this.newTags = this.newTags.filter((t) => t !== tag);
    this.blogRequest.newTags = [...this.newTags];
  }

  showPreview() : void {
    this.isPreview = true;
  }
}