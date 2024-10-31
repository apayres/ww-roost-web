import { Component, inject} from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import {
  MAT_DIALOG_DATA,
  MatDialog,
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
  MatDialogRef,
  MatDialogTitle,
} from '@angular/material/dialog';

@Component({
  selector: 'page-bag-components-confirmation',
  templateUrl: 'confirmation.component.html',
  standalone: true,
  imports: [MatDialogTitle, MatDialogContent, MatDialogActions, MatDialogClose, MatButtonModule]
})
export class ConfirmationComponent {
  data = inject(MAT_DIALOG_DATA);
  name: string = '';
  constructor() {
    this.name = this.data.name;
  }
}
