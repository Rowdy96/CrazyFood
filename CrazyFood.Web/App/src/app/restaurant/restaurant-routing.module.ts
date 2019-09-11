import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateRestaurantComponent } from './create-restaurant/create-restaurant.component';

const routes: Routes = [
  {
    path: '',
    component: CreateRestaurantComponent
  },
  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RestaurantRoutingModule { }
