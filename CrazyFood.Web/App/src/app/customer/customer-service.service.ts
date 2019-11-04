import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ReviewAC } from '../Models/ReviewAC';
import { OrderOfUserAC } from '../Models/OrderOfUserAC';
import { FollowAC } from '../Models/FollowAC';

@Injectable({
  providedIn: 'root'
})
export class CustomerServiceService {

  constructor(private http:HttpClient) {

  }

  GetOrderHistory(userId: string): Observable<OrderOfUserAC[]>{

    return this.http.get<OrderOfUserAC[]>('https://localhost:44303/api/Orders/GetAllOrdersOfUser/' + userId);
  }

  GetReviewsOfUser(userId: string): Observable<ReviewAC[]> {
    return this.http.get<ReviewAC[]>('https://localhost:44303/api/Reviews/GetReviewsOfUser/' + userId);
  }

  GetFollowersOfUser(userId: string): Observable<FollowAC[]> {
    return this.http.get<FollowAC[]>('https://localhost:44303/api/Follow/ListOfFollowersOfUser/' + userId);
  }

  IsFollowedByCurrentUser(followingId: string, followedId: string): Observable<boolean> {
    var url = 'https://localhost:44303/api/Follow/IsFollowing/' + followedId + '/' + followingId;
    debugger;
    return this.http.get<boolean>(url);
  }

  FollowUser(follow: FollowAC): Observable<FollowAC> {
    var url = "https://localhost:44303/api/Follow/FollowUser";
    return this.http.post<FollowAC>(url, follow);
  }

  UnFollowUser(follow: FollowAC): Observable<FollowAC> {

    var url = "https://localhost:44303/api/Follow/UnFollowUser";
    return this.http.put<FollowAC>(url, follow);

  }

  
}
