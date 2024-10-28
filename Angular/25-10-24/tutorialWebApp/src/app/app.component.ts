import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TutorialExample1Component } from "./componets/tutorial-example1/tutorial-example1.component";
import { TutorialExample2Component } from "./componets/tutorial-example2/tutorial-example2.component";
import { TutorialExample3Component } from "./componets/tutorial-example3/tutorial-example3.component";
import { TutorialExample4Component } from "./componets/tutorial-example4/tutorial-example4.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, TutorialExample1Component, TutorialExample2Component, TutorialExample3Component, TutorialExample4Component],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'tutorialWebApp';
  initialCount = 18;
}
