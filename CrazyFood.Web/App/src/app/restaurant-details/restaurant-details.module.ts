import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RestaurantDetailsRoutingModule } from './restaurant-details-routing.module';
import { RestaurantDetailsComponent } from './restaurant-details/restaurant-details.component';
import { DetailsPageComponent } from './details-page/details-page.component';
import { RestaurantMenuComponent } from './restaurant-menu/restaurant-menu.component';
import { RestaurantReviewsComponent } from './restaurant-reviews/restaurant-reviews.component';
import { OrderOnlineModule } from '../order-online/order-online.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { RestaurantModule } from '../restaurant/restaurant.module';




@NgModule({
  declarations: [RestaurantDetailsComponent, DetailsPageComponent, RestaurantMenuComponent, RestaurantReviewsComponent],
  imports: [
    CommonModule,
    RestaurantDetailsRoutingModule,
    OrderOnlineModule,
    ReactiveFormsModule,
    RestaurantModule,
    FormsModule
  ]
})
export class RestaurantDetailsModule { }
