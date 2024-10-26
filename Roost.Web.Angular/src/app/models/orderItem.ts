import { Item } from "./Item";
import {Option } from './option'

export interface OrderItem {
  orderItemId: string,
  item: Item,
  quantity: number,
  price: number,
  options: Option[]
}
