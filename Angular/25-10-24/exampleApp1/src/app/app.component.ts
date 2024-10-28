import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ListEmployeesComponent } from "./components/employees/list-employees.component";
import { TemplateTutorialComponent } from "./components/tutorial/template-tutorial.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ListEmployeesComponent, TemplateTutorialComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'exampleApp1';
}
