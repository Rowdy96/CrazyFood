import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RestaurantDetailsComponent } from './restaurant-details/restaurant-details.component';
import { MenuComponent } from './menu/menu.component';
import { ReviewsComponent } from './reviews/reviews.component';


const routes: Routes = [
  {
    path:'',
    component:RestaurantDetailsComponent,
    children:[
      {
        path: '',
        children:[
        {path:'menu',component:MenuComponent},
        {path:'reviews',component:ReviewsComponent}
        ]
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RestaurantDetailsRoutingModule { }
