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
  selector: 'page-menu-components-options',
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

  pigeonMilk: number = 0;
  sugars: number = 0;
  calories: number = 0;
  price: number = 0;
  baseCalories: number = 0;

  constructor(public dialogRef: MatDialogRef<OptionsComponent>) {    
    this.baseCalories = Number(this.data.attributes.calories);
    this.price = Number(this.data.attributes.price);

    this.calculateCalories();
  }

  calculateCalories() {
    const caloriesFromPigeonMilk = this.pigeonMilk * 10;
    const caloriesFromSugars = this.sugars * 5;
    this.calories = this.baseCalories + caloriesFromPigeonMilk + caloriesFromSugars;
  }

  saveSelection() {
    const self = this;

    this.dialogRef.close({
      pigeonMilk: self.pigeonMilk,
      sugars: self.sugars
    });
  }

  cancel() {
    this.dialogRef.close();
  }
}
