import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RestaurantDetailsRoutingModule } from './restaurant-details-routing.module';
import { RestaurantDetailsComponent } from './restaurant-details/restaurant-details.component';
import { MenuComponent } from './menu/menu.component';
import { ReviewsComponent } from './reviews/reviews.component';


@NgModule({
  declarations: [RestaurantDetailsComponent, MenuComponent, ReviewsComponent],
  imports: [
    CommonModule,
    RestaurantDetailsRoutingModule
  ]
})
export class RestaurantDetailsModule { }
