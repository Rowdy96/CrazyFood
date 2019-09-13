import { Component, OnInit } from '@angular/core';
import { RestuarantService } from '../restuarant.service';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-delete-restaurant',
  templateUrl: './delete-restaurant.component.html',
  styleUrls: ['./delete-restaurant.component.css']
})
export class DeleteRestaurantComponent implements OnInit {

  constructor(private restaurantService: RestuarantService,
    private route: ActivatedRoute,
    private location: Location) { }

  ngOnInit() {
  }

  Delete() {
    const id = +this.route.snapshot.paramMap.get('restaurantId');
    this.restaurantService.DeleteRestaurant(id).subscribe(res => {
      this.location.back();
    })
  }

  Back() {
    this.location.back();
  }

}
