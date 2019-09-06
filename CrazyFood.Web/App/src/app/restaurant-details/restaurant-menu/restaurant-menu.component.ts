import { Component, OnInit } from '@angular/core';
import { MenuAC } from '../../Models/MenuAc';
import { RestaurantDetailsService } from '../restaurant-details.service';
import { ActivatedRoute } from '@angular/router';
import { debug } from 'util';

@Component({
  selector: 'app-restaurant-menu',
  templateUrl: './restaurant-menu.component.html',
  styleUrls: ['./restaurant-menu.component.css']
})
export class RestaurantMenuComponent implements OnInit {

  MenuOfRestaurant: MenuAC[];
  constructor(private service: RestaurantDetailsService,
              private route: ActivatedRoute
              ){ }

  ngOnInit() {
    this.GetMenu();
  }

  GetMenu(): void {
    const id = +this.route.snapshot.params['restaurantId'];
    
    this.service.GetMenuOfRestaurant(1).subscribe(res => {
      this.MenuOfRestaurant = res;
      
    })
  }

}
