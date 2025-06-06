import { Component, inject, input, OnInit } from '@angular/core';
import { ExercisesService } from '../exercises.service';

@Component({
  selector: 'app-exercise-by-body-part',
  imports: [],
  templateUrl: './exercise-by-body-part.component.html',
  styleUrl: './exercise-by-body-part.component.scss'
})
export class ExerciseByBodyPartComponent implements OnInit {
  bodyPartId = input.required<number>();

  private exercisesService = inject(ExercisesService);

  constructor() { }

  ngOnInit() {
    this.exercisesService.getExercisesByBodyPart(this.bodyPartId()).subscribe({
      next: (exercises) => {
        console.log('Exercises for body part:', exercises);
      },
      error: (error) => {
        console.error('Error fetching exercises:', error);
      }
    });
  }
}
