import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListOfRestaurantComponent } from './list-of-restaurant/list-of-restaurant.component';


const routes: Routes = [
  {
    path: '',
    component:ListOfRestaurantComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ListOfRestaurantRoutingModule { }
