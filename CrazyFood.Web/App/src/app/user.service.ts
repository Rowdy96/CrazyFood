import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserAC } from './Models/UserAC';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';



@Injectable({
  providedIn: 'root'
})
export class UserService {

  currentUser: UserAC = new UserAC();
  rootUrl = "https://localhost:44303/";

  constructor(private http: HttpClient, private router: Router) {
    this.GetLoggedInUser().subscribe(res => {
      this.currentUser = res;
    },
      err => {
        this.currentUser = null;
      });
  }

  GetLoggedInUser(): Observable<UserAC> {
    return this.http.get<UserAC>(this.rootUrl + "api/Users/GetLoggedInUSer");
  }

  GetUserDetails(userId: string): Observable<UserAC> {
   
    return this.http.get<UserAC>(this.rootUrl + "api/Users/GetUserDetails/" + userId);
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
