import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CustomerServiceService } from '../customer-service.service';
import { FollowAC } from '../../Models/FollowAC';
import { UserService } from '../../user.service';

@Component({
  selector: 'app-customer-followers',
  templateUrl: './customer-followers.component.html',
  styleUrls: ['./customer-followers.component.css']
})
export class CustomerFollowersComponent implements OnInit {

  AllFollowers: FollowAC[];
  constructor(private route: ActivatedRoute,
    private service: CustomerServiceService,
    private userService: UserService) { }

  ngOnInit() {
    this.GetAllFollowers();
  }

  GetAllFollowers() {
    const customerId = this.route.parent.snapshot.paramMap.get('customerId');
    this.service.GetFollowersOfUser(customerId).subscribe(
      res => {
        this.AllFollowers = res;
        console.log(res);
      }
      ,err => {
        alert("Error")
      });
  }

  OnClick(userId: string) {
    var unfollow = new FollowAC();
    unfollow.FollowingUserId = this.userService.currentUser.Id;
    unfollow.FollowedUserId = userId;
    this.service.UnFollowUser(unfollow).subscribe(
      res => {
        this.ngOnInit();
        alert("Success");
      },
      err => {
        alert("Error");
      }
    ) 
  }
}
