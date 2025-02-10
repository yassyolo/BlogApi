import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-sorting',
  imports: [FormsModule, CommonModule],
  templateUrl: './sorting.component.html',
  styleUrl: './sorting.component.css'
})
export class SortingComponent implements OnInit {
   @Output() sortingChanged = new EventEmitter<string>();
   sorting: string = '';

   constructor(private route: ActivatedRoute)
{}
   sortingOptions: {type: number, value: string, label: string}[] = [
    {type: 1, value: 'nameAsc', label: 'Name (A-Z)'},
    {type: 1, value: 'nameDesc', label: 'Name (Z-A)'},
    {type: 2, value: 'titleDesc', label: 'Title (A-Z)'},
    {type: 2, value: 'titleAsc', label: 'Title (Z-A)'},   
    {type: 2, value: 'authorAsc', label: 'Author (A-Z)'},
    {type: 2, value: 'authorDesc', label: 'Author (Z-A)'},
    {type: 2, value: 'authorDesc', label: 'Author (Z-A)'},  
    {type: 3, value: 'mostVoted', label: 'Votes'},
    {type: 3, value: 'mostCommented', label: 'Comments'},
    {type: 4, value: 'dateAsc', label: 'Date (Oldest first)'},
    {type: 4, value: 'dateDesc', label: 'Date (Newest first)'},
   ];

   ngOnInit(): void {
    this.route.url.subscribe(url => {
      const currentPath = url.map(segment => segment.path).join('/');

      if (currentPath.includes('bookmarks')) {
        this.sortingOptions = this.sortingOptions.filter(option => option.type === 1 || option.type === 4);
      } else if (currentPath.includes(':id')) {
        this.sortingOptions = this.sortingOptions.filter(option => option.type === 2 || option.type === 4);
      } else if(currentPath.includes('forum')) {
        this.sortingOptions = this.sortingOptions.filter(option => option.type === 3 || option.type === 4);
      }
    });
}


   onSortingChange() : void{
    this.sortingChanged.emit(this.sorting);
   }
}
