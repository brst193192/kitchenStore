import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
  selector: '[appButtonDesighn]',
  standalone: true
})

export class ButtonDesighnDirective {

  constructor(private e: ElementRef) { }

  @HostListener('click') click(){
    this.e.nativeElement.style.color="black";
  }
}