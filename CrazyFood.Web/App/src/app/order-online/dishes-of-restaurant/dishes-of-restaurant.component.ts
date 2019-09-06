import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { OrderOnlineService } from '../order-online.service';
import { RestaurantAC } from 'src/app/Models/RestaurantAC';
import { OrderMenuAC } from '../../Models/OrderMenuAC';
import { Dish } from '../../Models/Dish';
import { OrderItem } from '../../Models/OrderItem';
import { Order } from '../../Models/Order';
import { OrderAC } from '../../Models/OrderAC';


@Component({
  selector: 'app-dishes-of-restaurant',
  templateUrl: './dishes-of-restaurant.component.html',
  styleUrls: ['./dishes-of-restaurant.component.css']
})
export class DishesOfRestaurantComponent implements OnInit {

  Id: number = 0;
  OrderMenuList: OrderMenuAC[];
  UserId: string = "1";
  RestaurantDetails: RestaurantAC;
  SelectedItemList: Dish[] = new Array();

  Order: OrderAC = new OrderAC();
  OrderItemList: OrderItem[] = new Array();

  constructor(private service : OrderOnlineService
             ,private route: ActivatedRoute) { }

  ngOnInit() {
    this.GetRestaurant();
    this.getMenuOfRestaurant();
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
    debugger;
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
    }
  }

  proceed() {
    for (var selectedItem of this.SelectedItemList) {
      var item = new OrderItem();
      item.dishId = selectedItem.id;
      item.itemCount = selectedItem.itemCount;
      this.OrderItemList.push(item);
    }
    //this.Order.Order.userId = this.UserId;
    this.Order.OrderItems = this.OrderItemList

    console.log(this.Order);
  }


}
