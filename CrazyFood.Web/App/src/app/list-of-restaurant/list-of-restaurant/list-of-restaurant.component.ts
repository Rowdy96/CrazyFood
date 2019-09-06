import { Component, OnInit } from '@angular/core';
import { RestaurantAC } from 'src/app/Models/RestaurantAC';
import { ListOfRestaurantService } from '../list-of-restaurant.service';
import { Restaurant } from '../../Models/Restaurant';
import { Route, Router } from '@angular/router';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-list-of-restaurant',
  templateUrl: './list-of-restaurant.component.html',
  styleUrls: ['./list-of-restaurant.component.css']
})
export class ListOfRestaurantComponent implements OnInit {

  RestaurantList: RestaurantAC[];
  restaurant = new Restaurant();
  cityId: number;

  cityForm = new FormGroup({
    city: new FormControl('')
  });

  constructor(private service: ListOfRestaurantService,
              private router: Router) { }

  ngOnInit() {
    this.GetRestaurants();
   
  }

  GetRestaurants(): void{

    this.service.GetAllRestaurants().subscribe(res => {
      this.RestaurantList = res;
      
    })
  }

  GetRestaurantOfCity(id: number): void {
    this.service.GetRestaurantsOfCity(id).subscribe(res => {
      this.RestaurantList = res;
    })
  }

  hasOnlineOrder(restaurant: RestaurantAC): boolean {

    this.restaurant = restaurant.restaurant;
    return this.restaurant.hasOnlineBooking;
  }

  GoToMenu(id: number) {
    this.router.navigateByUrl('/RestaurantDetails/'+id+'/Menu');
  }

  onSubmit(){
    this.cityId = this.cityForm.value.city;
    debugger;
    if (this.cityId == 0) {
      this.GetRestaurants();
    }
    else
    {
      this.GetRestaurantOfCity(this.cityId);
      debugger;
    }
  }
}
