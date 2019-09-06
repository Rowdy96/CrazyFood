import { Component, OnInit } from '@angular/core';
import { Restaurant } from 'src/app/Models/Restaurant';
import { RestaurantAC } from 'src/app/Models/RestaurantAC';
import { RestaurantDetailsService } from '../restaurant-details.service';
import { Route, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-restaurant-details',
  templateUrl: './restaurant-details.component.html',
  styleUrls: ['./restaurant-details.component.css']
})
export class RestaurantDetailsComponent implements OnInit {

  RestaurantDetails : RestaurantAC;
  restaurantId : number;
  constructor(private service: RestaurantDetailsService , 
              private route : ActivatedRoute) { 
      this.RestaurantDetails = new RestaurantAC();              
  }

  ngOnInit() {
    this.GetRestaurant();
  }

  GetRestaurant(): void{
    this.restaurantId = +this.route.snapshot.paramMap.get("restaurantId");
    this.service.GetRestaurant(this.restaurantId).subscribe(res=>{
      this.RestaurantDetails = res;
     
    });
  }

}
