import { OrderItem } from "./orderItem";

export interface Order {
  name: string,
  orderItems: OrderItem[],
  total: number,
  subTotal: number,
  salesTax: number
}
