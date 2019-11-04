import { Component, OnInit } from '@angular/core';
import { ReviewAC } from '../../Models/ReviewAC';
import { ActivatedRoute } from '@angular/router';
import { CustomerServiceService } from '../customer-service.service';
import { UserService } from '../../user.service';
import { ReviewLike } from '../../Models/ReviewLike';
import { UserAC } from '../../Models/UserAC';
import { ReviewService } from '../../add-review/review.service';
import { Comment } from '../../Models/Comment';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-customer-review',
  templateUrl: './customer-review.component.html',
  styleUrls: ['./customer-review.component.css']
})
export class CustomerReviewComponent implements OnInit {

  ReviewList: ReviewAC[];
  user: UserAC = new UserAC();
  comment: Comment = new Comment();
  commentForm = new FormGroup({
    commentText: new FormControl('')
  });
  constructor(private route: ActivatedRoute,
    private customerService: CustomerServiceService,
    private userService: UserService,
    private reviewService: ReviewService) { }

  ngOnInit() {
    this.GetReview();
    this.user = this.userService.currentUser;
  }

  GetReview() {
    const customerId = this.route.parent.snapshot.paramMap.get('customerId');
    this.customerService.GetReviewsOfUser(customerId).subscribe(res => {
      this.ReviewList = res;
      console.log(this.ReviewList);
    },
    err => {
        alert("Error");
      })
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
    else {
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
