import { Component, inject } from '@angular/core';
import { OrderService } from '../../services/order.service';
import { Order } from '../../models/order';
import { NgFor, NgIf } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmationComponent } from './components/confirmation/confirmation.component';
import { PickupDetailsComponent } from './components/pickupDetails/pickupDetails.component';

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
      name: '',
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
    let pickupDetails = this.dialog.open(PickupDetailsComponent);

    pickupDetails.afterClosed().subscribe(result => {
      if (result) {
        order.name = result.name;

        this.orderService.submitOrder(order, () => {
          this.dialog.open(ConfirmationComponent, {
            data: {
              name: order.name
            }
          });
        });
      }
    });
  }

  removeItem(id: string): void {
    this.orderService.removeFromOrder(id);
  }
}
