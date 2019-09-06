import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddReviewComponent } from './add-review/add-review.component';
import { AddRatingComponent } from './add-rating/add-rating.component';


const routes: Routes = [
  {
    path:'Review',
    component:AddReviewComponent
  },
  {
    path:'Rating',
    component:AddRatingComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AddReviewRoutingModule { }
