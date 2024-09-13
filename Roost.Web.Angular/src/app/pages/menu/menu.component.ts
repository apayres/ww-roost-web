import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ItemService } from '../../services/item.service';
import { Item } from '../../models/Item';
import { NgFor, NgIf } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { OrderService } from '../../services/order.service';
import { Order } from '../../models/order';
import { MenuSection } from '../../models/menuSection';

@Component({
  selector: 'page-menu',
  standalone: true,
  imports: [MatProgressSpinnerModule, MatCardModule, MatButtonModule, NgFor, NgIf],
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.scss'
})

export class MenuComponent implements OnInit {

  menuSections: MenuSection[] = [];
  loading: boolean = true;

  constructor(private itemService: ItemService, private orderService : OrderService) {

  }

  ngOnInit(): void {
    this.itemService.getItems((items: Item[]) => {
      const categories: string[] = [];

      items.forEach((obj) => {
        if (categories.indexOf(obj.category) == -1) {
          categories.push(obj.category);
        }
      });

      categories.forEach((category) => {
        this.menuSections.push({
          category,
          items: items.filter((x) => { return x.category === category })
        });
      });

      this.loading = false;
    }, () => {});
  }

  addToBag(item: Item): boolean {

    this.orderService.addToOrder(item, 1);
    return false;
  }
}
