import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { ItemService } from '../../services/item.service';
import { Item } from '../../models/Item';
import { NgFor, NgIf } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { OrderService } from '../../services/order.service';
import { Order } from '../../models/order';
import { Option } from '../../models/option';
import { MatDialog } from '@angular/material/dialog';
import { MenuSection } from '../../models/menuSection';
import { OptionsComponent } from '../menu/components/options.component';
import { SpinnerComponent } from '../../shared/components/spinner/spinner.component';

@Component({
  selector: 'page-menu',
  standalone: true,
  imports: [SpinnerComponent, MatCardModule, MatButtonModule, NgFor, NgIf],
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.scss'
})

export class MenuComponent implements OnInit {
  readonly dialog = inject(MatDialog);

  menuSections: MenuSection[] = [];
  loading: boolean = true;

  constructor(private itemService: ItemService, private orderService : OrderService) {

  }

  ngOnInit(): void {
    this.itemService.getMenuItems((items: Item[]) => {
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

    let optionsDialog = this.dialog.open(OptionsComponent, {
      data: {
        attributes: item.attributes
      }
    });

    optionsDialog.afterClosed().subscribe(result => {
      if (result) {
        this.orderService.addToOrder(item, 1, [
          { name: 'Pigeon Milk', value: result.pigeonMilk.toString() },
          { name: 'Sugars', value: result.sugars.toString() }
        ]);
      }
    });

    return false;
  }
}
