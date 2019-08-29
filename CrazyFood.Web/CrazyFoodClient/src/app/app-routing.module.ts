import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  {
    path:'',
    loadChildren: ()=> import('./restaurant/restaurant.module').then(mod=>
      mod.RestaurantModule)
  },
  {
    path:'Restaurant/:restaurantId',
    loadChildren: ()=> import('./restaurant-details/restaurant-details.module').then(mod=>
      mod.RestaurantDetailsModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
