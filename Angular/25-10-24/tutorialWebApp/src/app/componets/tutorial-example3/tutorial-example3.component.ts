import { Component } from '@angular/core';

@Component({
  selector: 'app-tutorial-example3',
  standalone: true,
  imports: [],
  template: `
    <input type="text" (keyup)="updateField($event)" />
    <h1>the event key is {{eventKey}} </h1>
  `,
  styleUrl: './tutorial-example3.component.css'
})
export class TutorialExample3Component {
eventKey:any;
updateField(event:KeyboardEvent):void{
  this.eventKey = event.key;
  if (event.key==='Enter') {
    this.eventKey = 'You pressed Enter.🥳🥳🥳'
  }
}
}
