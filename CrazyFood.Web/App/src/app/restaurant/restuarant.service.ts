import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Restaurant } from '../Models/Restaurant';
import { MenuCategory } from '../Models/MenuCategory';
import { DishAC } from '../Models/DishAC';
import { Location } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class RestuarantService {

    
  rootUrl = 'https://localhost:44303/';
  constructor(private http: HttpClient,
    private location: Location) { }

  AddRestaurant(restaurant: Restaurant): Observable<Restaurant>{
    var url = this.rootUrl + 'api/Restaurants/CreateRestaurant';
    return this.http.post<Restaurant>(url, restaurant);
  }

  AddCategory(restaurantId: number, category: MenuCategory): Observable<MenuCategory> {
    var url = this.rootUrl + 'api/Menus/CreateMenuCategory/' + restaurantId;
    return this.http.post<MenuCategory>(url, category);
  }

  AddDish(categoryId: number, dish: DishAC): Observable<DishAC> {

    var url = this.rootUrl + 'api/Dishs/CreateDish/' + categoryId;
    return this.http.post<DishAC>(url, dish);
  }

  GetDish(dishId: number): Observable<DishAC> {
    var url = this.rootUrl + 'api/Dishs/GetDish/' + dishId;
    return this.http.get<DishAC>(url);
  }

  UpdateDish(dishId: number, upadtedDish: DishAC): Observable<DishAC> {
    var url = this.rootUrl + 'api/Dishs/UpdateDish/' + dishId;
    return this.http.put<DishAC>(url, upadtedDish);
  }

  DeleteDish(dishId: number): Observable<{}> {
    var url = this.rootUrl + 'api/Dishs/DeleteDish/' + dishId;
    return this.http.delete(url);
  }

  DeleteMenuCategory(menuId: number): Observable<{}> {
    var url = this.rootUrl + 'api/Menus/DeleteMenuCategory/' + menuId;
    return this.http.delete(url);
  }

  UpdateRestaurant(restaurantId: number, upadtedRestaurant: Restaurant): Observable<Restaurant> {
    var url = this.rootUrl + 'api/Restaurants/UpdateRestaurant/' + restaurantId;
    return this.http.put<Restaurant>(url, upadtedRestaurant);
  }

  DeleteRestaurant(restaurantId: number): Observable<{}> {
    var url = this.rootUrl + 'api/Restaurants/DeleteRestaurant/' + restaurantId;
    return this.http.delete(url);
  }

}
