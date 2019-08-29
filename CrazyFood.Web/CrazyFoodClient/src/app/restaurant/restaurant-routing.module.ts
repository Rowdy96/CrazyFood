import { NgModule, ViewChildren } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListOfRestaurantComponent } from './list-of-restaurant/list-of-restaurant.component';
import { RestaurantDetailsComponent } from '../restaurant-details/restaurant-details/restaurant-details.component';



const routes: Routes = [
  {
    path: '',
    component:ListOfRestaurantComponent
  },
  {
    path:'Restaurant/:restaurantId',
    component:RestaurantDetailsComponent
  }
  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RestaurantRoutingModule { }
