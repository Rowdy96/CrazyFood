import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { RestaurantAC } from '../shared/RestaurantAC';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RestaurantDetailsService {

  constructor(private http : HttpClient) { }

  GetRestaurantById(retaurantId :number) :Observable<RestaurantAC>{
    
    return this.http.get<RestaurantAC>("https://localhost:44303/api/Restaurants/GetRestaurant/"+retaurantId);
    debugger;
  }

}
