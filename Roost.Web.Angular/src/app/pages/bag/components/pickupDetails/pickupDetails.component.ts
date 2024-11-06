import { Component, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { MatError, MatFormFieldModule } from '@angular/material/form-field';
import {
  MatDialog,
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
  MatDialogRef,
  MatDialogTitle
} from '@angular/material/dialog';
import { MatInput } from '@angular/material/input';
import { NgIf } from '@angular/common';

@Component({
  selector: 'bag-components-pickupDetails',
  templateUrl: 'pickupDetails.component.html',
  styleUrl: 'pickupDetails.component.scss',
  standalone: true,
  imports: [
    MatFormFieldModule,
    FormsModule,
    MatButtonModule,
    MatSelectModule,
    MatDialogTitle,
    MatDialogContent,
    MatDialogActions,
    MatDialogClose,
    MatInput,
    MatError,
    NgIf],
})
export class PickupDetailsComponent {
  
  name: string = '';
  showRequiredErrorMessage: boolean = false;
  constructor(public dialogRef: MatDialogRef<PickupDetailsComponent>) {
    
  }

  saveDetails(): boolean {
    const self = this;

    if (self.name.trim() === '') {
      self.showRequiredErrorMessage = true;
      return false;
    }

    this.dialogRef.close({
      name: self.name
    });

    return true;
  }

  cancel() {
    this.dialogRef.close();
  }
}
