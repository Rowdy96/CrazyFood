import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RestaurantRoutingModule } from './restaurant-routing.module';
import { CreateRestaurantComponent } from './create-restaurant/create-restaurant.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AddDishComponent } from './add-dish/add-dish.component';
import { EditDishComponent } from './edit-dish/edit-dish.component';
import { DeleteDishComponent } from './delete-dish/delete-dish.component';
import { DeleteCategoryComponent } from './delete-category/delete-category.component';
import { DeleteRestaurantComponent } from './delete-restaurant/delete-restaurant.component';
import { UpdateRestaurantComponent } from './update-restaurant/update-restaurant.component';


@NgModule({
  declarations: [CreateRestaurantComponent, AddDishComponent, EditDishComponent, DeleteDishComponent, DeleteCategoryComponent, DeleteRestaurantComponent, UpdateRestaurantComponent],
  imports: [
    CommonModule,
    RestaurantRoutingModule,
    ReactiveFormsModule,
  ],
  exports: [AddDishComponent]
})
export class RestaurantModule { }
