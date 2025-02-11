import { Component, OnInit } from '@angular/core';
import { CategorySelectorComponent } from '../../blogs/category-selector/category-selector.component';
import { SearchComponent } from '../../blogs/search/search.component';
import { StreamService } from '../service/stream.service';
import { BehaviorSubject, combineLatest, Observable, switchMap } from 'rxjs';
import { StreamForFeed } from '../models/stream-for-feed.model';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-stream-feed',
  imports: [CategorySelectorComponent, SearchComponent, CommonModule, RouterLink],
  templateUrl: './stream-feed.component.html',
  styleUrl: './stream-feed.component.css'
})
export class StreamFeedComponent implements OnInit{
  private _streams = new BehaviorSubject<StreamForFeed[]>([]);
  streamList$? = this._streams.asObservable();
  categorySelected= new BehaviorSubject<number>(0);
  query= new BehaviorSubject<string>('');
  constructor(private streamService: StreamService) {
  }
  ngOnInit(): void {
    this.streamList$ = combineLatest([this.categorySelected, this.query]).pipe(
      switchMap(([categoryId, query]) => this.streamService.getStreamList(query, categoryId))
    )}


  onCategoryChange(categoryId: number) : void{
     this.categorySelected.next(categoryId);
  }

  onSearchQueryChange(query: string) : void{
    this.query.next(query);
  }

  joinStream(streamId: number) : void{
    this.streamService.joinStream(streamId);
    this._streams.next(
      this._streams.getValue(). map(stream => stream.id === streamId ? {...stream, viewersCount: stream.viewersCount + 1} : stream)
    )
  }

}
