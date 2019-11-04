import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CustomerComponent } from './customer/customer.component';
import { CustomerReviewComponent } from './customer-review/customer-review.component';
import { OrderHistoryComponent } from './order-history/order-history.component';
import { CustomerFollowersComponent } from './customer-followers/customer-followers.component';


const routes: Routes = [
  {
    path:'',
    component:CustomerComponent,
    children:[
      {
        path:'',
        component:CustomerReviewComponent
      },
      {
        path: 'Reviews',
        component: CustomerReviewComponent
      },
      {
        path: 'Followers',
        component: CustomerFollowersComponent
      },
      {
        path:'OrderHistory',
        component:OrderHistoryComponent
      }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomerRoutingModule { }
