import { Component, OnInit } from '@angular/core';
import { RestuarantService } from '../restuarant.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-delete-dish',
  templateUrl: './delete-dish.component.html',
  styleUrls: ['./delete-dish.component.css']
})
export class DeleteDishComponent implements OnInit {

  constructor(private restaurantService: RestuarantService,
              private route: ActivatedRoute,
              private location:Location) { }

  ngOnInit() {
  }

  Delete() {
    const id = +this.route.snapshot.paramMap.get('dishId');
    this.restaurantService.DeleteDish(id).subscribe(res => {
      this.location.back();
    })
  }

  Back() {
    this.location.back();
  }
}
