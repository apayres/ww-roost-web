import { NgIf } from '@angular/common';
import { Component, Input } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDivider } from '@angular/material/divider';
import { MatIcon } from '@angular/material/icon';
import { RouterLinkActive, RouterLink, Router, NavigationEnd } from '@angular/router';
import { OrderService } from '../../services/order.service';
import { Order } from '../../models/order';
import { filter } from 'rxjs';


@Component({
  selector: 'shared-header',
  standalone: true,
  imports: [MatIcon, MatButtonModule, MatDivider, NgIf, RouterLink, RouterLinkActive],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})

export class HeaderComponent {

  showSideMenu: boolean = false;
  itemsInBag: number = 0;

  constructor(private orderService: OrderService, private router: Router) {
    this.orderService.order$.subscribe(order => {
      this.itemsInBag = order.orderItems.length;
    });

    this.orderService.fetchOrder();

    router.events.pipe(filter(e => e instanceof NavigationEnd)).subscribe((x) => {
      this.showSideMenu = false;
    });
  }

  toggleSideMenu(): boolean {
    this.showSideMenu = !this.showSideMenu;

    return false;
  }
}
