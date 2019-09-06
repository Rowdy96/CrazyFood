import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OrderOnlineRoutingModule } from './order-online-routing.module';
import { DishesOfRestaurantComponent } from './dishes-of-restaurant/dishes-of-restaurant.component';
import { CustomerOrderComponent } from './customer-order/customer-order.component';


@NgModule({
  declarations: [DishesOfRestaurantComponent, CustomerOrderComponent],
  imports: [
    CommonModule,
    OrderOnlineRoutingModule
  ]
})
export class OrderOnlineModule { }
