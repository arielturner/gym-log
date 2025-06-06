import { Component, inject } from '@angular/core';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogActions, MatDialogContent, MatDialogRef, MatDialogTitle } from '@angular/material/dialog';
import { BodyPart } from '../body-part.model';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-add-edit-body-part',
  imports: [
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatDialogTitle,
    MatDialogContent,
    MatDialogActions,
  ],
  templateUrl: './add-edit-body-part.component.html',
  styleUrl: './add-edit-body-part.component.scss'
})
export class AddEditBodyPartComponent {
  bodyPartForm = new FormGroup({
    bodyPartId: new FormControl<number>(0),
    bodyPartName: new FormControl<string>('', Validators.required),
  });

  protected isAddMode: boolean = true;
  dialogRef = inject(MatDialogRef<AddEditBodyPartComponent>);
  data: BodyPart = inject(MAT_DIALOG_DATA);

  constructor() {
    if (this.data) {
      this.bodyPartForm.setValue({
        bodyPartId: this.data.bodyPartId,
        bodyPartName: this.data.bodyPartName,
      });

      this.isAddMode = false;
    }
  }

  onSubmit() {
    if (this.bodyPartForm.valid) {
      const newBodyPart = this.bodyPartForm.value;
      console.log('New body part added:', newBodyPart);
      this.dialogRef.close();
    } else {
      this.bodyPartForm.markAllAsTouched();
    }
  }
}
