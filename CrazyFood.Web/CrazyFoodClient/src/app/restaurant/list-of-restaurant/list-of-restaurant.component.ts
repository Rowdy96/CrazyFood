import { Component, OnInit } from '@angular/core';
import { RestaurantAC } from 'src/app/shared/RestaurantAC';
import { RestaurantService } from '../restaurant.service';

@Component({
  selector: 'app-list-of-restaurant',
  templateUrl: './list-of-restaurant.component.html',
  styleUrls: ['./list-of-restaurant.component.css']
})
export class ListOfRestaurantComponent implements OnInit {

  RestaurantList: RestaurantAC[];
  constructor(private service : RestaurantService ) {

   }

  ngOnInit() {
    this.getRestaurants();
    debugger;
  }

  getRestaurants() : void{
    this.service.GetAllRestaurant().subscribe(res=>{
      this.RestaurantList = res;
    })
  }
}
