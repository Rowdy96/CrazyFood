import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/user.service';
import { UserAC } from 'src/app/Models/UserAC';
import { ActivatedRoute } from '@angular/router';
import { FollowAC } from '../../Models/FollowAC';
import { CustomerServiceService } from '../customer-service.service';


@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {

  User: UserAC = new UserAC();
  customerId: string;
  loggedInUserId: string;
  IsFollowed: boolean;
  followUser: FollowAC  = new FollowAC();
  constructor(private userSerVice: UserService
    , private route: ActivatedRoute
    , private customerService: CustomerServiceService) { }

  ngOnInit() {
    this.customerId = this.route.snapshot.paramMap.get('customerId');

    
    if (this.userSerVice.currentUser == null)
    {
      this.GetUser();
      debugger;
    }
    else
    {

      this.loggedInUserId = this.userSerVice.currentUser.Id;
      if (this.loggedInUserId == this.customerId) {
        this.User = this.userSerVice.currentUser;

      }
      else {
        this.GetUser();
      }
    }

  
  }

  GetUser() {
    
    this.userSerVice.GetUserDetails(this.customerId).subscribe(res => {
      this.User = res;
      this.customerService
        .IsFollowedByCurrentUser(this.User.Id, this.userSerVice.currentUser.Id)
        .subscribe(res => { this.IsFollowed = res; },
          err => { alert("Error") });
    });

  }

  FollowUser(userId: string) {
   
    this.followUser.FollowingUserId = userId;
    this.followUser.FollowedUserId = this.loggedInUserId;
    this.customerService.FollowUser(this.followUser).subscribe(res => {
      this.followUser = res;
      this.ngOnInit();
    },
      err => {
        alert("Error");
      });
  }

  UnFollowUser(UserId: string) {
    var unfollow = new FollowAC();
    unfollow.FollowingUserId = this.loggedInUserId;
    unfollow.FollowedUserId = UserId;
    this.customerService.UnFollowUser(unfollow).subscribe(
      res => {
        this.ngOnInit();
      },
      err => {
        alert("Error");
      }
    ) 
  }

}
