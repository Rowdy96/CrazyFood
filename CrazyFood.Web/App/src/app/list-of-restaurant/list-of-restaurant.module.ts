import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListOfRestaurantRoutingModule } from './list-of-restaurant-routing.module';
import { ListOfRestaurantComponent } from './list-of-restaurant/list-of-restaurant.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [ListOfRestaurantComponent],
  imports: [
    CommonModule,
    ListOfRestaurantRoutingModule,
    ReactiveFormsModule
  ]
})
export class ListOfRestaurantModule { }
