import { Component, OnInit } from '@angular/core';
import { RestaurantDetailsService } from '../restaurant-details.service';
import { ActivatedRoute } from '@angular/router';
import { RestaurantAC } from 'src/app/shared/RestaurantAC';

@Component({
  selector: 'app-restaurant-details',
  templateUrl: './restaurant-details.component.html',
  styleUrls: ['./restaurant-details.component.css']
})
export class RestaurantDetailsComponent implements OnInit {

  public Restaurant : RestaurantAC = new RestaurantAC();
  constructor(private service: RestaurantDetailsService , private route: ActivatedRoute) { 
   
  };
  ngOnInit() {
    this.GetRestaurant();
  }

  GetRestaurant():void{
    const id = +this.route.snapshot.paramMap.get("restaurantId");
    this.service.GetRestaurantById(id).subscribe(res=>
      {
        this.Restaurant = res;
        debugger;
      });
  }

}
