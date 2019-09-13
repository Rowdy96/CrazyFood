import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { OrderOnlineService } from '../order-online.service';
import { RestaurantAC } from 'src/app/Models/RestaurantAC';
import { OrderMenuAC } from '../../Models/OrderMenuAC';
import { Dish } from '../../Models/Dish';
import { OrderItem } from '../../Models/OrderItem';
import { Order } from '../../Models/Order';
import { OrderAC } from '../../Models/OrderAC';
import { UserService } from 'src/app/user.service';
import { UserAC } from 'src/app/Models/UserAC';
import { RestaurantDetailsService } from '../../restaurant-details/restaurant-details.service';


@Component({
  selector: 'app-dishes-of-restaurant',
  templateUrl: './dishes-of-restaurant.component.html',
  styleUrls: ['./dishes-of-restaurant.component.css']
})
export class DishesOfRestaurantComponent implements OnInit {

  Id: number = 0;
  OrderMenuList: OrderMenuAC[];
  RestaurantDetails: RestaurantAC;
  SelectedItemList: Dish[] = new Array();
  totalPrice: number = 0;
  user: UserAC = new UserAC();

  constructor(private service : OrderOnlineService
             ,private route: ActivatedRoute
             ,private userService: UserService
             , private restaurantService: RestaurantDetailsService) { }

  ngOnInit() {
    this.GetRestaurant();
    this.getMenuOfRestaurant();
    this.getCurrentUser();
  }

  getCurrentUser() {
    this.userService.GetLoggedInUser().subscribe(res => {
      this.user= res;
    });
  }

  getMenuOfRestaurant():void { 
    this.service.GetMenuListOfRestaurant(this.Id).subscribe(res=>{
      this.OrderMenuList = res;
      for (var menu of this.OrderMenuList) {
        for (var dish of menu.dishes) {
          dish.itemCount = 0;
        }
      }
    });
  }

  GetRestaurant(): void{
    this.Id = +this.route.snapshot.paramMap.get('restaurantId');
    this.service.GetRestaurant(this.Id).subscribe(res=>{
      this.RestaurantDetails = res;
    });
  }

  onAdd(dish: Dish) {
    dish.itemCount = dish.itemCount + 1;
  }

  onRemove(dish: Dish) {
    if (dish.itemCount == 0) {
      alert("To add Item Click + button")
    }

    dish.itemCount = dish.itemCount - 1;
  }

  addToOrder(dish: Dish) {

    if (dish.itemCount == 0) {
      alert("To add Item Click + button")
    }
    else {
      this.SelectedItemList.push(dish);
      console.log(this.SelectedItemList);
      this.totalPrice = this.totalPrice + dish.itemCount * dish.price;
    }
  }

  


}
