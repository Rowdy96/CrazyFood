import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AddReviewRoutingModule } from './add-review-routing.module';
import { AddReviewComponent } from './add-review/add-review.component';
import { AddRatingComponent } from './add-rating/add-rating.component';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [AddReviewComponent, AddRatingComponent],
  imports: [
    CommonModule,
    AddReviewRoutingModule,
    ReactiveFormsModule
  ]
})
export class AddReviewModule { }
