import { Component, inject, ViewChild } from '@angular/core';
import { BodyPartsService } from '../services/body-parts.service';
import { BodyPart } from '../models/body-part.model';
import { MatTable, MatTableModule } from '@angular/material/table';

@Component({
  selector: 'app-body-parts-page',
  imports: [MatTableModule],
  templateUrl: './body-parts-page.component.html',
  styleUrl: './body-parts-page.component.scss'
})
export class BodyPartsPageComponent {
  private bodyPartsService = inject(BodyPartsService);

  displayedColumns: string[] = ['bodyPartId', 'bodyPartName'];
  dataSource: BodyPart[] = [];

  @ViewChild(MatTable)
  table!: MatTable<BodyPart>;

  constructor() {
    this.bodyPartsService.getBodyParts().subscribe({
      next: (bodyParts: BodyPart[]) => {
        this.dataSource = bodyParts;
      },
      error: (error) => {
        console.error('Error fetching body parts:', error);
      }
    });
  }
  
}
