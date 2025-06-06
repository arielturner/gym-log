import { Component, inject, ViewChild } from '@angular/core';
import { BodyPartsService } from '../body-parts.service';
import { BodyPart } from '../body-part.model';
import { MatTable, MatTableModule } from '@angular/material/table';
import { MatSortModule, Sort } from '@angular/material/sort';

@Component({
  selector: 'app-body-parts',
  imports: [MatTableModule, MatSortModule],
  templateUrl: './body-parts.component.html',
  styleUrl: './body-parts.component.scss'
})
export class BodyPartsComponent {
  private bodyPartsService = inject(BodyPartsService);

  displayedColumns: string[] = ['bodyPartId', 'bodyPartName'];
  dataSource: BodyPart[] = [];

  @ViewChild(MatTable)
  table!: MatTable<BodyPart>;

  constructor() {
    this.bodyPartsService.getBodyParts().subscribe({
      next: (bodyParts: BodyPart[]) => {
        this.dataSource = this.sortBy(bodyParts, 'bodyPartId');
      },
      error: (error) => {
        console.error('Error fetching body parts:', error);
      }
    });
  }

  onSortChange(sortState: Sort) {
    if (!sortState.direction) {
      this.dataSource = this.sortBy(this.dataSource, 'bodyPartId');
    } else {
      this.dataSource = this.sortBy(this.dataSource, sortState.active, sortState.direction === 'asc');
    }

    if (this.table) {
      this.table.renderRows();
    }
  }

  sortBy(data: BodyPart[], column: string, ascending: boolean = true): BodyPart[] {
    return data.sort((a, b) => {
      const valueA = (a as any)[column];
      const valueB = (b as any)[column];

      if (ascending) {
        return valueA > valueB ? 1 : -1;
      } else {
        return valueA > valueB ? -1 : 1;
      }
    });
  }
}
