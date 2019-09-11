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
  },
  {
    path: 'Customer/:customerId',
    loadChildren:()=> import('./customer/customer.module').then(mod=>mod.CustomerModule)
  },
  {
    path: 'Admin',
    loadChildren: () => import('./restaurant/restaurant.module').then(mod => mod.RestaurantModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
