import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'CrazyFood Corner';

  constructor(private http: HttpClient) {

  }
  loginUrl: string = "https://localhost:44303/Account/Login";
}
