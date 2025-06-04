import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { computer } from '../../class/computer';

@Component({
  selector: 'app-computers',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './computers.component.html',
  styleUrl: './computers.component.less'
})
export class ComputersComponent {
  computers:Array<computer>=[];
  ngOnInit(){
    this.computers.push(new computer("1","hp","i5",128));
    this.computers.push(new computer("2","lenovo","i7",512));
    this.computers.push(new computer("3","dell","i3",256));
    this.computers.push(new computer("4","acer","i5",512));
  }
  delete(id:string){
    this.computers=this.computers.filter(c=>c.id!=id);
  }
}
