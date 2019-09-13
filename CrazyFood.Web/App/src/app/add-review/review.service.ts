import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Review } from '../Models/Review';
import { Comment } from '../Models/Comment';


@Injectable({
  providedIn: 'root'
})
export class ReviewService {

  constructor(private http : HttpClient) { }

  rootUrl = "https://localhost:44303/";
  AddReview(review:Review,restaurantId:number):Observable<Review>{
    var url = this.rootUrl+"api/Reviews/AddReviw/"+restaurantId;
    debugger;
    return this.http.post<Review>(url,review);
    debugger;
  }

  AddComment(comment: Comment, reviewId: number): Observable<Comment> {
    var url = this.rootUrl + "api/Reviews/AddComment/" + reviewId;
    return this.http.post<Comment>(url, comment);
  }
}