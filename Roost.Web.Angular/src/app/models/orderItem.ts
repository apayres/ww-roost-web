import { Item } from "./Item";

export interface OrderItem {
  orderItemId: string,
  item: Item,
  quantity: number,
  price: number
}
