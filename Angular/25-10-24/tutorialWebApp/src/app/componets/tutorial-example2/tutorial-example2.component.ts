import { Component } from '@angular/core';

@Component({
  selector: 'app-tutorial-example2',
  standalone: true,
  imports: [],
  template: `
    <ul [style]="listStyles"> ... </ul>
    <section [style]="sectionStyles"> ... </section>
  `,
  styleUrl: './tutorial-example2.component.css'
})
export class TutorialExample2Component {
  listStyles = 'display: flex; padding: 8px';
  sectionStyles = {
    border: '1px solid black',
    'font-weight': 'bold',
  };
}
