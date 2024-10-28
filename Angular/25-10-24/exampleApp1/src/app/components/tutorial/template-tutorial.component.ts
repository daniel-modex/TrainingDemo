import { Component } from '@angular/core';

@Component({
  selector: 'app-template-tutorial',
  standalone: true,
  imports: [],
  template:`
   <ul [style]="listStyles"> ... </ul>
    <section [style]="sectionStyles"> ... </section>
  `,
  styleUrl: './template-tutorial.component.css'
})
export class TemplateTutorialComponent {
  listStyles = 'display: flex; padding: 8px';
  sectionStyles = {
    border: '1px solid black',
    width: '50%',
  };
}
