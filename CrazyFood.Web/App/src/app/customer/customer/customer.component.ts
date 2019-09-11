import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/user.service';
import { UserAC } from 'src/app/Models/UserAC';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {

  User : UserAC = new UserAC();
  constructor(private userSerVice : UserService) { }

  ngOnInit() {
    this.GetCurrentUser();
  }

  GetCurrentUser(){
    this.userSerVice.GetLoggedInUser().subscribe(res=>{
      this.User = res;
    },
    err =>{
        console.log(err);
    })
  }

}
