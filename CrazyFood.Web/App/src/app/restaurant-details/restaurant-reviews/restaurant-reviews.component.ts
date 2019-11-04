import { Component, OnInit } from '@angular/core';
import { ReviewAC } from '../../Models/ReviewAC';
import { RestaurantDetailsService } from '../restaurant-details.service';
import { ActivatedRoute } from '@angular/router';
import { ReviewService } from 'src/app/add-review/review.service';
import { FormGroup, FormControl } from '@angular/forms';
import { UserService } from '../../user.service';
import { UserAC } from '../../Models/UserAC';
import { Comment } from '../../Models/Comment';
import { ReviewLike } from '../../Models/ReviewLike';

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
    this.user = this.userService.currentUser;
    this.GetReviews();
  }

  GetReviews() {
    const restaurantId = +this.route.parent.snapshot.paramMap.get('restaurantId');
    this.service.GetReviewsOfRestaurant(restaurantId).subscribe(res => {
      this.ReviwList = res;
    });
  }

  toggle(review: ReviewAC) {
    if (!review.ShowComment) {
      review.ShowComment = true;
    } else {
      review.ShowComment = false;
    }
    
  }

  addLike(review: ReviewAC) {
    if (this.user == null) {
      alert("You are not Logged In");
    }
    else {
      var like = new ReviewLike()
      like.ReviewId = review.ReviewId;
      like.UserId = this.user.Id;
      this.reviewService.AddLike(like, like.ReviewId).subscribe(res => {

        alert("Like Added");
        window.location.reload();
      }, err => {
        alert("Error");
      }
      )
    }
  }

  addComment(reviewId: number) {
    if (this.user == null) {
      alert("You are not Logged In");
    }
    else
    {
      this.comment.CommentText = this.commentForm.value.commentText;
      this.comment.ReviewId = reviewId;
      this.comment.UserId = this.user.Id;
   
      this.reviewService.AddComment(this.comment, reviewId).subscribe(
        res => {
          console.log("success");
          window.location.reload();
        }
        , err => {
          console.log("error");
        }
      )
    }
    
    
  }

   
}
