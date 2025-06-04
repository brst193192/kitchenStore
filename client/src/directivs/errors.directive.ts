import { Directive, ElementRef, Input } from '@angular/core';

@Directive({
  selector: '[appErrors]',
  standalone: true
})
export class ErrorsDirective {

  @Input() color="";
  constructor(private e:ElementRef) { }
  
  ngOnInit(){
    this.e.nativeElement.style.color=this.color;
  }

}
