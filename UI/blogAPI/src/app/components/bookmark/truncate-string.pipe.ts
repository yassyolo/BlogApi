import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'truncateString'
})
export class TruncateStringPipe implements PipeTransform {

  transform(value: string, limit: number = 300): string {
    if(value.length > limit){
      return value.substring(0, limit) + '...';
    }
    return value;
  }

}
