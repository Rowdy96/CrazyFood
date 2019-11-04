import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { UserAC } from 'src/app/Models/UserAC';
import { Review } from 'src/app/Models/Review';
import { UserService } from 'src/app/user.service';
import { ReviewService } from '../review.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-add-rating',
  templateUrl: './add-rating.component.html',
  styleUrls: ['./add-rating.component.css']
})
export class AddRatingComponent implements OnInit {

  user: UserAC;
  Review: Review = new Review();

  ratingForm = new FormGroup({
    rating : new FormControl('')
  })
  constructor(private userService:UserService,
              private reviewService : ReviewService,
              private router: Router,
              private route: ActivatedRoute) { }

  ngOnInit() {
    this.userService.GetLoggedInUser().subscribe(res => {
      this.user = res;
      debugger;
    });
  }
  onSubmit(){
    alert(this.ratingForm.value.rating);
    if (this.user == undefined)
    {
      alert("You are not Logged In");
    }
    else
    {
      this.Review.Rating = this.ratingForm.value.rating;
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
