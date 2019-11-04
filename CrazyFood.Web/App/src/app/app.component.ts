import { Component, OnInit } from '@angular/core';
import { UserAC } from './Models/UserAC';
import { UserService } from './user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
    
  title = 'CrazyFood Corner';

  user: UserAC;
  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.GetLoggedInUser();
  }

  GetLoggedInUser() {
    this.userService.GetLoggedInUser().subscribe(res => {
      this.user = res;
    }, err => {
        this.user = null;
    });
  }

  Logout() {   
    this.userService.Logout();
    this.GetLoggedInUser();
    debugger;
  }
}
