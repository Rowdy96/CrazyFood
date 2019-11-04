import { Component, OnInit } from '@angular/core';
import { RestaurantAC } from 'src/app/Models/RestaurantAC';
import { ListOfRestaurantService } from '../list-of-restaurant.service';
import { Restaurant } from '../../Models/Restaurant';
import { Route, Router } from '@angular/router';
import { UserAC } from '../../Models/UserAC';
import { UserService } from '../../user.service';

@Component({
  selector: 'app-list-of-restaurant',
  templateUrl: './list-of-restaurant.component.html',
  styleUrls: ['./list-of-restaurant.component.css']
})
export class ListOfRestaurantComponent implements OnInit {

  RestaurantList: RestaurantAC[];
  Restaurant = new Restaurant();
  cityId: number;
  user: UserAC;

  constructor(private service: ListOfRestaurantService,
              private router: Router,
              private userService: UserService) { }

  ngOnInit() {
    this.GetRestaurants();
    this.GetCurrentUSer();
  }

  GetCurrentUSer() {
    this.userService.GetLoggedInUser().subscribe(res => {
      this.user = res
    },
      err => {
        console.log(err)
      });
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

    this.Restaurant = restaurant.Restaurant
    return this.Restaurant.HasOnlineBooking;
  }

  GoToMenu(id: number) {
    this.router.navigateByUrl('/RestaurantDetails/'+id+'/Menu');
  }
  GoToOrder(id: number) {
    this.router.navigateByUrl('/RestaurantDetails/' + id + '/Order/' + id);
  }

  onChange(deviceValue) {
    if (deviceValue == 0) {
      this.GetRestaurants();
    }
    else {
      this.GetRestaurantOfCity(deviceValue);
    }
  }
}
