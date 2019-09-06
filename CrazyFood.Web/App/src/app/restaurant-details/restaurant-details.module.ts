import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RestaurantDetailsRoutingModule } from './restaurant-details-routing.module';
import { RestaurantDetailsComponent } from './restaurant-details/restaurant-details.component';
import { DetailsPageComponent } from './details-page/details-page.component';
import { RestaurantMenuComponent } from './restaurant-menu/restaurant-menu.component';
import { RestaurantReviewsComponent } from './restaurant-reviews/restaurant-reviews.component';
import { OrderOnlineModule } from '../order-online/order-online.module';


@NgModule({
  declarations: [RestaurantDetailsComponent, DetailsPageComponent, RestaurantMenuComponent, RestaurantReviewsComponent],
  imports: [
    CommonModule,
    RestaurantDetailsRoutingModule,
    OrderOnlineModule
  ]
})
export class RestaurantDetailsModule { }
