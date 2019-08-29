import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RestaurantAC } from '../shared/RestaurantAC';

@Injectable({
  providedIn: 'root'
})
export class RestaurantService {

  private _http : HttpClient;

  constructor(http:HttpClient) {
    this._http = http;
  }

   httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  GetAllRestaurant() : Observable<RestaurantAC[]>{
    return this._http.get<RestaurantAC[]>("https://localhost:44303/api/Restaurants/GetAll");
  }

 
}
