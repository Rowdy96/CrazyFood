import { Component, OnInit } from '@angular/core';
import { ReviewAC } from '../../Models/ReviewAC';
import { RestaurantDetailsService } from '../restaurant-details.service';
import { ActivatedRoute } from '@angular/router';
import { ReviewService } from 'src/app/add-review/review.service';
import { FormGroup, FormControl } from '@angular/forms';
import { UserService } from '../../user.service';
import { UserAC } from '../../Models/UserAC';
import { Comment } from '../../Models/Comment';

@Component({
  selector: 'app-restaurant-reviews',
  templateUrl: './restaurant-reviews.component.html',
  styleUrls: ['./restaurant-reviews.component.css']
})
export class RestaurantReviewsComponent implements OnInit {

  Show: boolean = false;
  ReviwList: ReviewAC[];
  user: UserAC;
  comment: Comment = new Comment();

  commentForm = new FormGroup({
    commentText : new FormControl('')
  });

  constructor(private service: RestaurantDetailsService,
              private userService: UserService,
              private reviewService : ReviewService,
              private route: ActivatedRoute) { }

  ngOnInit() {
    this.userService.GetLoggedInUser().subscribe(res => {
      this.user = res;
      debugger;
    });
    this.GetReviews();
  }

  GetReviews() {
    const restaurantId = +this.route.parent.snapshot.paramMap.get('restaurantId');
    console.log(">>>> "+restaurantId);
    this.service.GetReviewsOfRestaurant(restaurantId).subscribe(res => {
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

  addComment(reviewId: number) {
    debugger;
    if (this.user == null) {
      debugger;
      alert("You are not Logged In");
    }
    else
    {
      debugger;
      console.log(this.user.email + reviewId + "  " + this.commentForm.value.commentText);
      this.comment.commentText = this.commentForm.value.commentText;
      this.comment.reviewId = reviewId;
      this.comment.userId = this.user.id;
      this.reviewService.AddComment(this.comment, reviewId).subscribe(
        res => {
          console.log("success");
        }
        , err => {
          console.log("error");
        }
      )
    }
    
    
  }

   
}
