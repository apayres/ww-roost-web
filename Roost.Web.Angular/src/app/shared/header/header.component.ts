import { NgIf } from '@angular/common';
import { Component, Input } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDivider } from '@angular/material/divider';
import { MatIcon } from '@angular/material/icon';
import { RouterLinkActive, RouterLink } from '@angular/router';
import { OrderService } from '../../services/order.service';
import { Order } from '../../models/order';


@Component({
  selector: 'shared-header',
  standalone: true,
  imports: [MatIcon, MatButtonModule, MatDivider, NgIf, RouterLink, RouterLinkActive],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})

export class HeaderComponent {
  @Input() optimizeForSmallScreen = false;

  showSideMenu: boolean = false;
  itemsInBag: number = 0;

  constructor(private orderService: OrderService) {
    this.orderService.order$.subscribe(order => {
      this.itemsInBag = order.orderItems.length;
    });

    this.orderService.fetchOrder();
  }

  toggleSideMenu(): boolean {

    this.showSideMenu = !this.showSideMenu;

    return false;
  }
}
