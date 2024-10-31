import { Component, Input } from '@angular/core';
import { NgIf } from '@angular/common';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

@Component({
  selector: 'shared-spinner',
  standalone: true,
  imports: [MatProgressSpinnerModule, NgIf],
  templateUrl: './spinner.component.html',
  styleUrl: './spinner.component.scss'
})
export class SpinnerComponent {
  @Input() showSpinner: boolean = false;
}
