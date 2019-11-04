import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { UserService } from '../../user.service';
import { UserAC } from '../../Models/UserAC';
import { log } from 'util';
import { Review } from '../../Models/Review';
import { ReviewService } from '../review.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-add-review',
  templateUrl: './add-review.component.html',
  styleUrls: ['./add-review.component.css']
})
export class AddReviewComponent implements OnInit {

  reviewForm = new FormGroup({
    rating: new FormControl(''),
    review: new FormControl('')
  });

  user: UserAC;
  Review: Review = new Review();

  constructor(private router : Router,
              private userService: UserService,
              private reviewService: ReviewService,
              private route: ActivatedRoute) { }

  ngOnInit() {
    this.userService.GetLoggedInUser().subscribe(res => {
      this.user = res;
      debugger;
    });
  }

  onSubmit() {

    if (this.user == undefined)
    {
      alert("You are not Logged In");
    }
    else
    {
      this.Review.Rating = this.reviewForm.value.rating;
      this.Review.ReviewText = this.reviewForm.value.review;
      this.Review.UserId = this.user.Id;
      this.Review.RestaurantId = +this.route.parent.snapshot.paramMap.get('restaurantId');
      debugger;
      this.reviewService.AddReview(this.Review, this.Review.RestaurantId).subscribe(res => {
        this.router.navigateByUrl("/RestaurantDetails/" + this.Review.RestaurantId + "/Reviews");
      },
        err => {
          console.log("error");
      });
    }
    
  }
}
