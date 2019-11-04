import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateRestaurantComponent } from './create-restaurant/create-restaurant.component';
import { AddDishComponent } from './add-dish/add-dish.component';
import { EditDishComponent } from './edit-dish/edit-dish.component';
import { DeleteDishComponent } from './delete-dish/delete-dish.component';
import { UpdateRestaurantComponent } from './update-restaurant/update-restaurant.component';
import { DeleteRestaurantComponent } from './delete-restaurant/delete-restaurant.component';
import { DeleteCategoryComponent } from './delete-category/delete-category.component';

const routes: Routes = [
  {
    path: '',
    component: CreateRestaurantComponent
  },
  {
    path: 'UpdateRestaurant/:restaurantId',
    component: UpdateRestaurantComponent
  },
  {
    path: 'DeleteRestaurant/:restaurantId',
    component: DeleteRestaurantComponent
  },
  {
    path: 'DeleteMenuCategory/:menuCategoryId',
    component: DeleteCategoryComponent
  },
  {
    path: 'CreateDish/:menuId',
    component: AddDishComponent
  },
  {
    path: 'UpdateDish/:dishId',
    component: EditDishComponent
  },
  {
    path: 'DeleteDish/:dishId',
    component: DeleteDishComponent
  }
  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RestaurantRoutingModule { }
