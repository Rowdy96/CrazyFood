import { Component, OnInit } from '@angular/core';
import { MenuAC } from '../../Models/MenuAc';
import { RestaurantDetailsService } from '../restaurant-details.service';
import { ActivatedRoute } from '@angular/router';
import { debug } from 'util';
import { UserService } from '../../user.service';
import { UserAC } from '../../Models/UserAC';

@Component({
  selector: 'app-restaurant-menu',
  templateUrl: './restaurant-menu.component.html',
  styleUrls: ['./restaurant-menu.component.css']
})
export class RestaurantMenuComponent implements OnInit {

  MenuOfRestaurant: MenuAC[];
  CurrentUser: UserAC = new UserAC()
  constructor(private service: RestaurantDetailsService,
              private route: ActivatedRoute,
              private userService: UserService
              ){ }

  ngOnInit() {

    this.GetMenu();
    this.userService.GetLoggedInUser().subscribe(
      res => {
        this.CurrentUser = res;
      },
      err => {
        this.CurrentUser = null;
      });
  }

  GetMenu(): void {
    const id = +this.route.snapshot.params['restaurantId'];
    const restaurantId = 1;
    this.service.GetMenuOfRestaurant(restaurantId).subscribe(res => {
      this.MenuOfRestaurant = res;
      
    })
  }

}
