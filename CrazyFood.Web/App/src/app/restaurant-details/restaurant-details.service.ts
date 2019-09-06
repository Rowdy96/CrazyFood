import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RestaurantAC } from '../Models/RestaurantAC';
import { HttpClient } from '@angular/common/http';
import { MenuAC } from '../Models/MenuAc';
import { ReviewAC } from '../Models/ReviewAC';

@Injectable({
  providedIn: 'root'
})
export class RestaurantDetailsService {
   
  constructor(private http : HttpClient) { }

  GetRestaurant(restaurantId : number): Observable<RestaurantAC>{
    
    return this.http.get<RestaurantAC>("https://localhost:44303/api/Restaurants/GetRestaurant/"+restaurantId);
  }

  GetMenuOfRestaurant(restaurantId: number): Observable<MenuAC[]> {
    return this.http.get<MenuAC[]>("https://localhost:44303/api/Menus/MenuList/" + restaurantId);
  }

  GetReviewsOfRestaurant(restaurantId: number): Observable<ReviewAC[]> {
    return this.http.get<ReviewAC[]>("https://localhost:44303/api/Reviews/GetReviewsOfRestaurant/" + restaurantId);
  }

  GetReviewByID(id: number): Observable<ReviewAC> {
    return this.http.get<ReviewAC>("https://localhost:44303/api/Reviews/GetReview/" + id);
  }

}
