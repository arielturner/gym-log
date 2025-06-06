import { Component, inject, ViewChild } from '@angular/core';
import { BodyPartsService } from '../body-parts.service';
import { BodyPart } from '../body-part.model';
import { MatTable, MatTableModule } from '@angular/material/table';
import { MatSortModule, Sort } from '@angular/material/sort';
import { MatIconModule } from '@angular/material/icon';
import { MatDialog } from '@angular/material/dialog';
import { AddEditBodyPartComponent } from '../add-edit-body-part/add-edit-body-part.component';

@Component({
  selector: 'app-body-parts',
  imports: [MatTableModule, MatSortModule, MatIconModule],
  templateUrl: './body-parts.component.html',
  styleUrl: './body-parts.component.scss'
})
export class BodyPartsComponent {
  private bodyPartsService = inject(BodyPartsService);
  readonly dialog = inject(MatDialog);

  displayedColumns: string[] = ['bodyPartId', 'bodyPartName', 'actions'];
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
  
  openEditBodyPartDialog(bodyPart: BodyPart) {
    const dialogRef = this.dialog.open(AddEditBodyPartComponent, {
      data: bodyPart,
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      if (result !== undefined) {
        console.log('New body part added:', result);
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
