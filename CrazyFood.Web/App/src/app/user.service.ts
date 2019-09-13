import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserAC } from './Models/UserAC';
import { Observable } from 'rxjs';
import { error } from 'protractor';
import { Window } from 'selenium-webdriver';
import { ActivatedRoute, Router } from '@angular/router';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  //currentUser: UserAC;
  rootUrl = "https://localhost:44303/";
  constructor(private http: HttpClient, private router: Router) { }

  GetLoggedInUser(): Observable<UserAC> {
    return this.http.get<UserAC>(this.rootUrl + "api/Users/GetLoggedInUSer");
  }



  Logout() {

    var url = this.rootUrl + "api/Users/Logout";
    this.http.post(url, null).subscribe(
      res => {
        this.router.navigateByUrl("/");
      },
      err => {
        console.log(err);
      });

  }
}
