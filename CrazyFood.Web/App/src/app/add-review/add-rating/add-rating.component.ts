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
      this.Review.rating = this.ratingForm.value.rating;
      this.Review.userId = this.user.id;
      this.Review.restaurantId = +this.route.parent.snapshot.paramMap.get('restaurantId');
      debugger;
      this.reviewService.AddReview(this.Review, this.Review.restaurantId).subscribe(res => {
        this.router.navigateByUrl("/RestaurantDetails/" + this.Review.restaurantId + "/Reviews");
      },
        err => {
          console.log("error");
      });
    }
  }
}
