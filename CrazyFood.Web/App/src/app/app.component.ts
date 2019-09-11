import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { UserAC } from './Models/UserAC';
import { UserService } from './user.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Route } from '@angular/compiler/src/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'CrazyFood Corner';

  user: UserAC;
  constructor(private userService: UserService
            , private router: Router)
  {
    
    this.GetLoggedInUser();
    //this.CheckUserRole();
  }

  GetLoggedInUser() {
    
    this.userService.GetLoggedInUser().subscribe(res => {
      this.user = res;
      debugger;
    });
  }

  //CheckUserRole() {
  //  if (this.user.roles.includes('Admin')) {
  //    this.router.navigateByUrl('/Admin');
  //  }
  //}

  Logout() {
    
    this.userService.Logout();
    this.user = null;
   
    debugger;
  }
}
