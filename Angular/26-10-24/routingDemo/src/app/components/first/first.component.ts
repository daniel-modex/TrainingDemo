import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { ChildAComponent } from './child-a/child-a.component';
import { ChildBComponent } from './child-b/child-b.component';

@Component({
  selector: 'app-first',
  standalone: true,
  imports: [RouterOutlet,RouterLink,RouterLinkActive,ChildAComponent,ChildBComponent],
  templateUrl: './first.component.html',
  styleUrl: './first.component.css'
})
export class FirstComponent {

}
