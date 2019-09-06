import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RestaurantAC } from '../Models/RestaurantAC';
@Injectable({
  providedIn: 'root'
})
export class ListOfRestaurantService {

  constructor(private http:HttpClient) { }

  GetAllRestaurants():Observable<RestaurantAC[]>{
   
    return this.http.get<RestaurantAC[]>("https://localhost:44303/api/Restaurants/GetAll");
  }


  GetRestaurantsOfCity(cityId: number): Observable<RestaurantAC[]> {
    return this.http.get<RestaurantAC[]>("https://localhost:44303/api/Restaurants/RestaurantsOfCity/" + cityId);
  }
}
