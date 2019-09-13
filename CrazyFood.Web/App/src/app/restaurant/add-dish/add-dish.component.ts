import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NewDish } from '../../Models/NewDish';
import { RestuarantService } from '../restuarant.service';
import { Location } from '@angular/common';
import { DishAC } from '../../Models/DishAC';

@Component({
  selector: 'app-add-dish',
  templateUrl: './add-dish.component.html',
  styleUrls: ['./add-dish.component.css']
})
export class AddDishComponent implements OnInit {

  constructor(private route: ActivatedRoute,
              private location: Location,
              private restaurantService: RestuarantService) { }
  Id: number;

  DishForm = new FormGroup({
    DishName: new FormControl(''),
    DishPrice: new FormControl('')
  })

  NewDish: DishAC = new DishAC();
  ngOnInit() {
    this.Id = +this.route.snapshot.paramMap.get('menuId');
  }
  onSubmit() {
    this.NewDish.dishName = this.DishForm.value.DishName;
    this.NewDish.price = this.DishForm.value.DishPrice;
    this.NewDish.menuCategoryId = this.Id;
    this.NewDish.menuCategory = null;
    this.restaurantService.AddDish(this.Id, this.NewDish).subscribe(
      res =>{
          this.location.back();
      },
      err => {
        alert("eRROR");
      }
    )
    
  }
}
