import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Item } from '../models/Item';
import { Order } from '../models/order';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class OrderService {

  private _order = new BehaviorSubject<Order>({
    orderItems: [],
    total: 0,
    subTotal: 0,
    salesTax: 0
  });

  order$ = this._order.asObservable();

  constructor(private http: HttpClient) {

  }

  addToOrder(item: Item, qty: number): void {
    try {
      
      const data = this.http.post<Order>('order', { item, quantity: qty }).subscribe(order => {
        this._order.next(order);
      });

    }
    catch {

    }
  }

  fetchOrder(): void {
    this.http.get<Order>('order').subscribe(data => {
      this._order.next(data);
    });
  }

  submitOrder(order : Order, successCallback: Function) {
    try {

      const data = this.http.post('order/submit', order).subscribe(response => {
        this._order.next({
          orderItems: [],
          total: 0,
          subTotal: 0,
          salesTax: 0
        });

        successCallback();
      });

    }
    catch {

    }
  }

  removeFromOrder(id: string) {
    const data = this.http.delete<Order>('order', { params: {id}}).subscribe(order => {
      this._order.next(order);
    });
  }
}
