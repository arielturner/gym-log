import { Component, inject } from '@angular/core';
import { BodyPartsComponent } from "./body-parts/body-parts.component";
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { AddEditBodyPartComponent } from './add-edit-body-part/add-edit-body-part.component';
import { BodyPart } from './body-part.model';

@Component({
  selector: 'app-body-parts-page',
  imports: [BodyPartsComponent, MatButtonModule, MatIconModule],
  templateUrl: './body-parts-page.component.html',
  styleUrl: './body-parts-page.component.scss'
})
export class BodyPartsPageComponent {
  readonly dialog = inject(MatDialog);
  
  openAddBodyPartDialog() {
    const dialogRef = this.dialog.open(AddEditBodyPartComponent, {
      data: null,
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      if (result !== undefined) {
        console.log('New body part added:', result);
      }
    });
  }
}
