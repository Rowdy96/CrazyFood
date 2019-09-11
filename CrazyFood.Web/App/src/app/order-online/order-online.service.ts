import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RestaurantAC } from '../Models/RestaurantAC';
import { Dish } from '../Models/Dish';
import { OrderMenuAC } from '../Models/OrderMenuAC';
import { OrderAC } from '../Models/OrderAC';

@Injectable({
  providedIn: 'root'
})
export class OrderOnlineService {
  
  constructor(private http : HttpClient) {}

  GetMenuListOfRestaurant(restaurantId: number): Observable<OrderMenuAC[]>{
    return this.http.get<OrderMenuAC[]>('https://localhost:44303/api/Menus/MenuList/'+restaurantId);
  }

  GetRestaurant(Id: number) :Observable<RestaurantAC>{
    return this.http.get<RestaurantAC>('https://localhost:44303/api/Restaurants/GetRestaurant/'+Id);
  }

  GetMenuById(dishId: number): Observable<Dish> {
    return this.http.get<Dish>('https://localhost:44303/api/Dishs/GetDish/' + dishId);
  }

  AddOrder(order: OrderAC): Observable<OrderAC> {
    
    return this.http.post<OrderAC>('https://localhost:44303/api/Orders/AddOrder', order);
  }

}
