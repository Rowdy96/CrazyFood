import { Component, OnInit } from '@angular/core';
import { RestaurantAC } from '../../Models/RestaurantAC';
import { RestaurantDetailsService } from '../restaurant-details.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-details-page',
  templateUrl: './details-page.component.html',
  styleUrls: ['./details-page.component.css']
})
export class DetailsPageComponent implements OnInit {

  RestaurantDetails: RestaurantAC;
  restaurantId: number;
  constructor(private service: RestaurantDetailsService,
    private route: ActivatedRoute) {
    this.RestaurantDetails = new RestaurantAC();
  }

  ngOnInit() {
    this.GetRestaurant();
  }

  GetRestaurant(): void {
    this.restaurantId = +this.route.snapshot.paramMap.get("restaurantId");
    this.service.GetRestaurant(this.restaurantId).subscribe(res => {
     
      this.RestaurantDetails = res;
      
    });
  }

}
