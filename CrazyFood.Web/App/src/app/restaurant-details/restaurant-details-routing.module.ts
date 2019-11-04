import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RestaurantDetailsComponent } from './restaurant-details/restaurant-details.component';
import { DetailsPageComponent } from './details-page/details-page.component';
import { RestaurantMenuComponent } from './restaurant-menu/restaurant-menu.component';
import { RestaurantReviewsComponent } from './restaurant-reviews/restaurant-reviews.component';
import { AddReviewComponent } from '../add-review/add-review/add-review.component';
import { AddReviewModule } from '../add-review/add-review.module';
import { AddRatingComponent } from '../add-review/add-rating/add-rating.component';


const routes: Routes = [
  {
    path:"",
    component:RestaurantDetailsComponent,
    children: [
      {
        path:'',
        component:DetailsPageComponent
      },
      {
        path:'Menu',
        component:RestaurantMenuComponent
      },
      {
        path:'Reviews',
        component:RestaurantReviewsComponent
      },
      {
        path:'AddReview',
        component:AddReviewComponent
      },
      {
        path:'AddRating',
        component:AddRatingComponent
      }
    ]
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes),
    AddReviewModule
  ],
  exports: [RouterModule]
})
export class RestaurantDetailsRoutingModule { }
