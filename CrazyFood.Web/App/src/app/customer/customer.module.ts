import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CustomerRoutingModule } from './customer-routing.module';
import { CustomerComponent } from './customer/customer.component';
import { CustomerReviewComponent } from './customer-review/customer-review.component';
import { OrderHistoryComponent } from './order-history/order-history.component';


@NgModule({
  declarations: [CustomerComponent, CustomerReviewComponent, OrderHistoryComponent],
  imports: [
    CommonModule,
    CustomerRoutingModule
  ]
})
export class CustomerModule { }
