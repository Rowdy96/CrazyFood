import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DishesOfRestaurantComponent } from './dishes-of-restaurant/dishes-of-restaurant.component';


const routes: Routes = [
  {
    path:'Order/:restaurantId',
    component:DishesOfRestaurantComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OrderOnlineRoutingModule { }
