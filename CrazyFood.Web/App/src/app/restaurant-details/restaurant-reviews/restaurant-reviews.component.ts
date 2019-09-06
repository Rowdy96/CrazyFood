import { Component, OnInit } from '@angular/core';
import { ReviewAC } from '../../Models/ReviewAC';
import { RestaurantDetailsService } from '../restaurant-details.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-restaurant-reviews',
  templateUrl: './restaurant-reviews.component.html',
  styleUrls: ['./restaurant-reviews.component.css']
})
export class RestaurantReviewsComponent implements OnInit {

  Show: boolean = false;
  ReviwList: ReviewAC[];

  constructor(private service: RestaurantDetailsService,
              private route: ActivatedRoute) { }

  ngOnInit() {
    this.GetReviews();
  }

  GetReviews() {
    const id = +this.route.snapshot.paramMap.get("restaurantId");
    this.service.GetReviewsOfRestaurant(1).subscribe(res => {
      this.ReviwList = res;
      
    });
  }

  toggle(review: ReviewAC) {
    if (!review.showComment) {
      review.showComment = true;
    } else {
      review.showComment = false;
    }
    
  }

   
}
