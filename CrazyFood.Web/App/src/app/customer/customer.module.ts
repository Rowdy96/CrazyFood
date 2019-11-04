import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CustomerRoutingModule } from './customer-routing.module';
import { CustomerComponent } from './customer/customer.component';
import { CustomerReviewComponent } from './customer-review/customer-review.component';
import { OrderHistoryComponent } from './order-history/order-history.component';
import { ReactiveFormsModule } from '@angular/forms';
import { CustomerFollowersComponent } from './customer-followers/customer-followers.component';


@NgModule({
  declarations: [CustomerComponent, CustomerReviewComponent, OrderHistoryComponent, CustomerFollowersComponent],
  imports: [
    CommonModule,
    CustomerRoutingModule,
    ReactiveFormsModule
  ]
})
export class CustomerModule { }
