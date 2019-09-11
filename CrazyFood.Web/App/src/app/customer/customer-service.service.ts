import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ReviewAC } from '../Models/ReviewAC';
import { OrderAC } from '../Models/OrderAC';

@Injectable({
  providedIn: 'root'
})
export class CustomerServiceService {

  constructor(private http:HttpClient) {

  }

  GetOrderHistory(userId:string):Observable<OrderAC[]>{

    return this.http.get<OrderAC[]>('https://localhost:44303/api/Orders/GetAllOrdersOfUser/' + userId);
  }
}
