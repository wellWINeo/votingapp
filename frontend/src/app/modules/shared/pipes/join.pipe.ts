import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'join' })
export class JoinPipe implements PipeTransform {
  transform(values: string[], arg: string): string {
    return values.join(arg);
  }
}
