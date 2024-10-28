import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-tutorial-example4',
  standalone: true,
  imports: [FormsModule],
  template: `
    <button (click)="updateCount(-1)">-</button>
    <span>{{ count }}</span>
    <button (click)="updateCount(+1)">+</button>
    @if(a>b){
      Count greater than 25
    }
  `,
  styleUrl: './tutorial-example4.component.css'
})
export class TutorialExample4Component {
  a:number;
  @Input() count: number;
  @Output() countChange = new EventEmitter<number>();
  updateCount(amount: number): void {
    this.count += amount;
    this.countChange.emit(this.count);
    this.a=this.count;
  }
  b:number = 25;
}
