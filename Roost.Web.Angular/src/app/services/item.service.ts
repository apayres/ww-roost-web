import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Item } from '../models/Item';

@Injectable({
  providedIn: 'root'
})

export class ItemService {

  constructor(private http: HttpClient) {

  }

  getMenuItems(completionCallback : Function, failureCallback: Function): void {    
    const data = this.http.get<Item[]>('items').subscribe(data => {
      completionCallback(data.filter((x) => {
        return x.parentCategory !== 'Retail';
      }));
    });
  }

  getRetailItems(completionCallback: Function, failureCallback: Function): void {
    const data = this.http.get<Item[]>('items').subscribe(data => {
      completionCallback(data.filter((x) => {
        return x.parentCategory === 'Retail';
      }));
    });
  }
}
