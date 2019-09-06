import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./list-of-restaurant/list-of-restaurant.module').then(mod => mod.ListOfRestaurantModule)
  },
  {
    path: 'RestaurantDetails/:restaurantId',
    loadChildren: ()=> import('./restaurant-details/restaurant-details.module').then(mod => mod.RestaurantDetailsModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
