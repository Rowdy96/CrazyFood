import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListOfRestaurantRoutingModule } from './list-of-restaurant-routing.module';
import { ListOfRestaurantComponent } from './list-of-restaurant/list-of-restaurant.component';


@NgModule({
  declarations: [ListOfRestaurantComponent],
  imports: [
    CommonModule,
    ListOfRestaurantRoutingModule
  ]
})
export class ListOfRestaurantModule { }
