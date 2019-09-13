import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { RestuarantService } from '../restuarant.service';
import { ActivatedRoute } from '@angular/router';
import { RestaurantDetailsService } from '../../restaurant-details/restaurant-details.service';
import { RestaurantAC } from '../../Models/RestaurantAC';
import { Location } from '@angular/common';

@Component({
  selector: 'app-update-restaurant',
  templateUrl: './update-restaurant.component.html',
  styleUrls: ['./update-restaurant.component.css']
})
export class UpdateRestaurantComponent implements OnInit {

  constructor(private restaurantDetails: RestaurantDetailsService,
              private restaurantService: RestuarantService,
              private route: ActivatedRoute,
              private location: Location) { }

  UpdateRestaurantForm = new FormGroup({
    Name: new FormControl(''),
    Email: new FormControl(''),
    Phone: new FormControl(''),
    City: new FormControl(''),
    OnlineBooking: new FormControl(''),
    Cost: new FormControl(''),
    Time: new FormControl(''),
    Address: new FormControl('')
  });

  Restaurant: RestaurantAC = new RestaurantAC();

  ngOnInit() {
    this.GetRestaurant();
  }

  GetRestaurant() {
    const id = +this.route.snapshot.paramMap.get('restaurantId');

    this.restaurantDetails.GetRestaurant(id).subscribe(res => {
      this.Restaurant = res;
      this.UpdateRestaurantForm.patchValue({
        Name: this.Restaurant.restaurant.name,
        Email: this.Restaurant.restaurant.emailId,
        Phone: this.Restaurant.restaurant.phoneNumber,
        City: this.Restaurant.restaurant.cityId,
        OnlineBooking: this.Restaurant.restaurant.hasOnlineBooking,
        Cost: this.Restaurant.restaurant.averageCost,
        Time: this.Restaurant.restaurant.openingHours,
        Address: this.Restaurant.restaurant.restaurantLocation,
      })

    });
  }

  UpdateRestaurant() {
    this.Restaurant.restaurant.name = this.UpdateRestaurantForm.value.Name
    this.Restaurant.restaurant.emailId = this.UpdateRestaurantForm.value.Email
    this.Restaurant.restaurant.phoneNumber = this.UpdateRestaurantForm.value.Phone
    this.Restaurant.restaurant.cityId = this.UpdateRestaurantForm.value.City
    this.Restaurant.restaurant.hasOnlineBooking = this.UpdateRestaurantForm.value.OnlineBooking
    this.Restaurant.restaurant.averageCost = this.UpdateRestaurantForm.value.Cost
    this.Restaurant.restaurant.openingHours = this.UpdateRestaurantForm.value.Time
    this.Restaurant.restaurant.restaurantLocation = this.UpdateRestaurantForm.value.Address

    this.restaurantService
      .UpdateRestaurant(this.Restaurant.restaurant.id, this.Restaurant.restaurant)
      .subscribe(
        res => {
        this.location.back();
        },
        err => {
          console.log(err);
       }
      )

  }

}
