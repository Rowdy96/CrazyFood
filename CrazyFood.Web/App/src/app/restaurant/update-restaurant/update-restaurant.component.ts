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
        Name: this.Restaurant.Restaurant.Name,
        Email: this.Restaurant.Restaurant.EmailId,
        Phone: this.Restaurant.Restaurant.PhoneNumber,
        City: this.Restaurant.Restaurant.CityId,
        OnlineBooking: this.Restaurant.Restaurant.HasOnlineBooking,
        Cost: this.Restaurant.Restaurant.AverageCost,
        Time: this.Restaurant.Restaurant.OpeningHours,
        Address: this.Restaurant.Restaurant.RestaurantLocation,
      })

    });
  }

  UpdateRestaurant() {
    this.Restaurant.Restaurant.Name = this.UpdateRestaurantForm.value.Name
    this.Restaurant.Restaurant.EmailId = this.UpdateRestaurantForm.value.Email
    this.Restaurant.Restaurant.PhoneNumber = this.UpdateRestaurantForm.value.Phone
    this.Restaurant.Restaurant.CityId = this.UpdateRestaurantForm.value.City
    this.Restaurant.Restaurant.HasOnlineBooking = this.UpdateRestaurantForm.value.OnlineBooking
    this.Restaurant.Restaurant.AverageCost = this.UpdateRestaurantForm.value.Cost
    this.Restaurant.Restaurant.OpeningHours = this.UpdateRestaurantForm.value.Time
    this.Restaurant.Restaurant.RestaurantLocation = this.UpdateRestaurantForm.value.Address

    this.restaurantService
      .UpdateRestaurant(this.Restaurant.Restaurant.Id, this.Restaurant.Restaurant)
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
