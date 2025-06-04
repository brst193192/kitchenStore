import { Directive, ElementRef, HostListener, Input } from '@angular/core';

@Directive({
  selector: '[appFont]',
  standalone: true
})
export class FontDirective {

  constructor(private e: ElementRef) { }
  @Input() fontFamily='Birzia Black'

  ngOnInit() {
    this.e.nativeElement.style.fontFamily = "Segoe UI";
  }

  @HostListener('dblclick') dblclick() {
    if (this.e.nativeElement.style.fontFamily == '"Segoe UI"')
      this.e.nativeElement.style.fontFamily = this.fontFamily;
    else
      this.e.nativeElement.style.fontFamily = 'Segoe UI';
  }

}
