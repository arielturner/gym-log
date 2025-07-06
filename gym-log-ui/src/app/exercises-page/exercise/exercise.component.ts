import { Component, model } from '@angular/core';
import { Exercise } from '../exercise.model';

@Component({
  selector: 'app-exercise',
  imports: [],
  templateUrl: './exercise.component.html',
  styleUrl: './exercise.component.scss'
})
export class ExerciseComponent {
  exercise = model<Exercise>();
}
