import { Component, OnInit } from '@angular/core';
import { RestuarantService } from '../restuarant.service';
import { DishAC } from '../../Models/DishAC';
import { ActivatedRoute } from '@angular/router';
import { FormGroup, FormControl } from '@angular/forms';
import { Location } from '@angular/common';

@Component({
  selector: 'app-edit-dish',
  templateUrl: './edit-dish.component.html',
  styleUrls: ['./edit-dish.component.css']
})
export class EditDishComponent implements OnInit {

  constructor(private restaurantService: RestuarantService,
              private route: ActivatedRoute,
              private location: Location) { }

  Dish: DishAC = new DishAC();
  ngOnInit() {
    this.GetDish();
  }

  UpdateDishForm = new FormGroup({
    DishName: new FormControl(''),
    DishPrice: new FormControl('')
  })

  GetDish(): void {
    const id = +this.route.snapshot.paramMap.get('dishId');
    this.restaurantService.GetDish(id).subscribe(res => {
      this.Dish = res;
      this.UpdateDishForm.patchValue({
        DishName: this.Dish.dishName,
        DishPrice: this.Dish.price
      })
      debugger;
    },
    err => {
      alert("loading error");
    })
  }

  onSubmit() {
    this.Dish.dishName = this.UpdateDishForm.value.DishName
    this.Dish.price = this.UpdateDishForm.value.DishPrice;
    console.log(this.Dish);
    this.restaurantService.UpdateDish(this.Dish.id, this.Dish).subscribe(res =>
    {
          this.location.back();
    },
      error => {
          alert("Error");
      }
    )
  }

  Back() {
    this.location.back();
  }
}
