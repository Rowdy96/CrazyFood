import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RestaurantRoutingModule } from './restaurant-routing.module';
import { CreateRestaurantComponent } from './create-restaurant/create-restaurant.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [CreateRestaurantComponent],
  imports: [
    CommonModule,
    RestaurantRoutingModule,
    ReactiveFormsModule,
  ]
})
export class RestaurantModule { }
