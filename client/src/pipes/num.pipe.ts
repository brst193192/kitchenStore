import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'num',
  standalone: true
})
export class NumPipe implements PipeTransform {

  transform(num: number, amountOfDigitsAfterPoint: number): number {
    return Math.floor(num*Math.pow(10, amountOfDigitsAfterPoint))/Math.pow(10, amountOfDigitsAfterPoint);
  }

}
