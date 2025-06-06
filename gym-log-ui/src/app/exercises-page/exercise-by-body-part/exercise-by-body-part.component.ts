import { Component, input } from '@angular/core';

@Component({
  selector: 'app-exercise-by-body-part',
  imports: [],
  templateUrl: './exercise-by-body-part.component.html',
  styleUrl: './exercise-by-body-part.component.scss'
})
export class ExerciseByBodyPartComponent {
  bodyPartId = input();

  constructor() {
    // This component is designed to be used with a specific bodyPartId input.
    // The bodyPartId will be used to filter or display exercises related to that body part.
    console.log('ExerciseByBodyPartComponent initialized with bodyPartId:', this.bodyPartId);
  }
}
