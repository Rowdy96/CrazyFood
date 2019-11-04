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
    this.NewDish.DishName = this.DishForm.value.DishName;
    this.NewDish.Price = this.DishForm.value.DishPrice;
    this.NewDish.MenuCategoryId = this.Id;
    this.NewDish.MenuCategory = null;
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
