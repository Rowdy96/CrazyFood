import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RestaurantRoutingModule } from './restaurant-routing.module';
import { ListOfRestaurantComponent } from './list-of-restaurant/list-of-restaurant.component';
import { RestaurantDetailsModule } from '../restaurant-details/restaurant-details.module';


@NgModule({
  declarations: [ListOfRestaurantComponent],
  imports: [
    CommonModule,
    RestaurantRoutingModule,
    RestaurantDetailsModule
  ]
})
export class RestaurantModule { }
