import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Restaurant } from '../Models/Restaurant';

@Injectable({
  providedIn: 'root'
})
export class RestuarantService {

  rootUrl = 'https://localhost:44303/';
  constructor(private http: HttpClient) { }

  AddRestaurant(restaurant: Restaurant): Observable<Restaurant>{
    var url = this.rootUrl + 'api/Restaurants/CreateRestaurant';
    debugger;
    return this.http.post<Restaurant>(url, restaurant);
  }
}
