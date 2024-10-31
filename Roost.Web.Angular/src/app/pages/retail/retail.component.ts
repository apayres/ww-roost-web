import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { ItemService } from '../../services/item.service';
import { Item } from '../../models/Item';
import { NgFor, NgIf } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBar } from '@angular/material/snack-bar';
import { OrderService } from '../../services/order.service';
import { Order } from '../../models/order';
import { Option } from '../../models/option';
import { MatDialog } from '@angular/material/dialog';
import { MenuSection } from '../../models/menuSection';
import { OptionsComponent } from '../retail/components/options.component';
import { SpinnerComponent } from '../../shared/components/spinner/spinner.component';


@Component({
  selector: 'page-retail',
  standalone: true,
  imports: [SpinnerComponent, MatCardModule, MatButtonModule, NgFor, NgIf],
  templateUrl: './retail.component.html',
  styleUrl: './retail.component.scss'
})
export class RetailComponent {
  readonly dialog = inject(MatDialog);
  readonly snackBar = inject(MatSnackBar);

  menuSections: MenuSection[] = [];
  loading: boolean = true;

  constructor(private itemService: ItemService, private orderService: OrderService) {

  }

  ngOnInit(): void {
    this.itemService.getRetailItems((items: Item[]) => {
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
    }, () => { });
  }

  addToBag(item: Item): boolean {
    this.orderService.addToOrder(item, 1, []);

    this.snackBar.open('Item added to order', 'Ok', {
      duration: 3000
    });

    return false;
  }

  showOptionsDialog(item: Item): boolean {
    let optionsDialog = this.dialog.open(OptionsComponent, {
      data: {
        attributes: item.attributes
      }
    });

    optionsDialog.afterClosed().subscribe(result => {
      if (result) {
        this.orderService.addToOrder(item, 1, [
          { name: 'Size', value: result.size.toString() }
        ]);

        this.snackBar.open('Item added to order', 'Ok', {
          duration: 3000
        });
      }
    });

    return false;
  }

  requireOptions(item: Item): boolean {
    return item.category.trim() === 'Apparel';
  }
}
