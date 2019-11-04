import { OrderItemAC } from './OrderItemAC';

export class OrderOfUserAC {
  OrderId: number;
  UserId: string;
  RestaurantId: number;
  RestaurantName: string
  OrderItem: OrderItemAC[]
}
