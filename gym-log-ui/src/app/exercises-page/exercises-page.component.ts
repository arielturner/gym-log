import { Component, inject } from '@angular/core';
import { BodyPartsService } from '../body-parts-page/body-parts.service';
import { BodyPart } from '../body-parts-page/body-part.model';
import { SortService } from '../sort.service';
import { MatExpansionModule } from '@angular/material/expansion';
import { ExerciseByBodyPartComponent } from './exercise-by-body-part/exercise-by-body-part.component';

@Component({
  selector: 'app-exercises-page',
  imports: [MatExpansionModule, ExerciseByBodyPartComponent],
  templateUrl: './exercises-page.component.html',
  styleUrl: './exercises-page.component.scss'
})
export class ExercisesPageComponent {
  private bodyPartService = inject(BodyPartsService);
  private sortService = inject(SortService);

  protected bodyParts: BodyPart[] = [];

  constructor() {
    this.bodyPartService.getBodyParts().subscribe({
      next: (bodyParts) => {
        this.bodyParts = this.sortService.sortBy(bodyParts, 'bodyPartName')
      },
      error: (error) => {
        console.error('Error fetching body parts:', error);
      }
    });
  }
}
