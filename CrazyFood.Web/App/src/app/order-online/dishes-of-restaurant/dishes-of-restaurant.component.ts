import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { OrderOnlineService } from '../order-online.service';
import { RestaurantAC } from 'src/app/Models/RestaurantAC';
import { OrderMenuAC } from '../../Models/OrderMenuAC';
import { Dish } from '../../Models/Dish';
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
             ,private userService: UserService) { }

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
    if (this.SelectedItemList.includes(dish)) {
      dish.itemCount = dish.itemCount + 1;
      this.totalPrice = this.totalPrice + dish.price * 1;
    }
    else {
      dish.itemCount = dish.itemCount + 1;
      this.totalPrice = this.totalPrice + dish.price * 1;
      this.SelectedItemList.push(dish);
    }
    
  }

  onRemove(dish: Dish) {
    if (!this.SelectedItemList.includes(dish)) {
      alert("To add Item Click + button")
    }
    else {
      if (this.SelectedItemList.includes(dish)) {
        dish.itemCount = dish.itemCount - 1;
        this.totalPrice = this.totalPrice - dish.price * 1;
        if (dish.itemCount == 0) {
          var index = this.SelectedItemList.indexOf(dish);
          this.SelectedItemList.splice(index, 1);
        }
      }
      
    } 
  }

}
