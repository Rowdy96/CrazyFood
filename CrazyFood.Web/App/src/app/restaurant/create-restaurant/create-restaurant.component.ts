import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { RestuarantService } from '../restuarant.service';
import { City } from 'src/app/Models/City';
import { Restaurant } from 'src/app/Models/Restaurant';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-restaurant',
  templateUrl: './create-restaurant.component.html',
  styleUrls: ['./create-restaurant.component.css']
})
export class CreateRestaurantComponent implements OnInit {

  constructor(private service: RestuarantService,
              private router: Router) { }
  restaurantForm = new FormGroup({
    Name: new FormControl(),
    Email: new FormControl(),
    Phone: new FormControl(),
    City: new FormControl(),
    OnlineBooking: new FormControl(),
    Cost: new FormControl(),
    Time: new FormControl(),
    Address: new FormControl()
  });

 
  ngOnInit() {
  }

  onSubmit() {

    var restaurant = new Restaurant();
    restaurant.name = this.restaurantForm.value.Name;
    restaurant.emailId = this.restaurantForm.value.Email;
    restaurant.phoneNumber = this.restaurantForm.value.Phone;
    restaurant.cityId =this.restaurantForm.value.City;
    restaurant.averageCost = this.restaurantForm.value.Cost;
    restaurant.openingHours = this.restaurantForm.value.Time;
    restaurant.hasOnlineBooking = this.restaurantForm.value.OnlineBooking;
    restaurant.restaurantLocation = this.restaurantForm.value.Address;
    console.log(restaurant);

    this.service.AddRestaurant(restaurant).subscribe(
      res => {
        this.router.navigateByUrl('');
      },
      err => {
        alert("Failed");
      }
    )
    
    
  }

}
