import { Component, inject } from '@angular/core';
import { OrderService } from '../../services/order.service';
import { Order } from '../../models/order';
import { NgFor, NgIf } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmationComponent } from './components/confirmation.component';

@Component({
  selector: 'page-bag',
  standalone: true,
  imports: [MatIcon, MatCardModule, MatButtonModule, NgFor, NgIf],
  templateUrl: './bag.component.html',
  styleUrl: './bag.component.scss'
})
export class BagComponent {
  readonly dialog = inject(MatDialog);

  order: Order = {
      orderItems: [],
      total: 0,
      subTotal: 0,
      salesTax: 0
  };

  constructor(private orderService: OrderService) {
    this.orderService.order$.subscribe(order => {
      this.order = order;
    });

    this.orderService.fetchOrder();
  }

  submitOrder(order: Order): void {
    this.orderService.submitOrder(order, () => {
      this.dialog.open(ConfirmationComponent)
    });
  }

  removeItem(id: string): void {
    this.orderService.removeFromOrder(id);
  }
}
