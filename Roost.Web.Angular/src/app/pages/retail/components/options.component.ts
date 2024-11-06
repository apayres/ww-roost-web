import { Component, inject} from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import {
  MatDialog,
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
  MatDialogRef,
  MatDialogTitle,
  MAT_DIALOG_DATA
} from '@angular/material/dialog';

@Component({
  selector: 'page-retail-components-options',
  templateUrl: 'options.component.html',
  styleUrl: 'options.component.scss',
  standalone: true,
  imports: [
    MatFormFieldModule,
    FormsModule,
    MatButtonModule,
    MatSelectModule,
    MatDialogTitle,
    MatDialogContent,
    MatDialogActions,
    MatDialogClose],
})
export class OptionsComponent {
  data = inject(MAT_DIALOG_DATA);

  size: string = '';
  price: number = 0;

  constructor(public dialogRef: MatDialogRef<OptionsComponent>) {
    this.data.attributes.forEach((attr: any) => {
      if (attr.name === 'Price') {
        this.price = Number(attr.value);
      }
    });
  }

  saveSelection() {
    const self = this;

    this.dialogRef.close({
      size: self.size,
      price: self.price
    });
  }

  cancel() {
    this.dialogRef.close();
  }
}
