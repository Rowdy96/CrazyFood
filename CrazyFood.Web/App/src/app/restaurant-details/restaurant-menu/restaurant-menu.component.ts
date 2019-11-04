import { Component, OnInit } from '@angular/core';
import { MenuAC } from '../../Models/MenuAc';
import { RestaurantDetailsService } from '../restaurant-details.service';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../../user.service';
import { UserAC } from '../../Models/UserAC';
import { FormGroup, FormControl } from '@angular/forms';
import { MenuCategory } from '../../Models/MenuCategory';
import { RestuarantService } from '../../restaurant/restuarant.service';
import { NewDish } from '../../Models/NewDish';

@Component({
  selector: 'app-restaurant-menu',
  templateUrl: './restaurant-menu.component.html',
  styleUrls: ['./restaurant-menu.component.css']
})
export class RestaurantMenuComponent implements OnInit {

  MenuOfRestaurant: MenuAC[];
  CurrentUser: UserAC = new UserAC();
  Id: number;
  NewCategory: MenuCategory = new MenuCategory();
  NewDish: NewDish = new NewDish();
  CategoryForm: FormGroup;
  dishForm: FormGroup;
  constructor(private service: RestaurantDetailsService,
              private route: ActivatedRoute,
              private userService: UserService,
              private restaurantService: RestuarantService,
             
              ){ }

  ngOnInit() {
    this.CategoryForm = new FormGroup({
      Category: new FormControl('')
    });

    this.dishForm = new FormGroup({
      Dish: new FormControl(''),
      price: new FormControl('')
    });
    this.GetMenu();
    this.CurrentUser = this.userService.currentUser;
  }

  GetMenu(): void {
    this.Id = +this.route.parent.snapshot.paramMap.get('restaurantId');
    this.service.GetMenuOfRestaurant(this.Id).subscribe(res => {
      this.MenuOfRestaurant = res;
      debugger;
    })
  }

  OnSubmit() {

    console.log(this.CategoryForm.value.Category);
    this.NewCategory.MenuCategoryName = this.CategoryForm.value.Category;
    this.NewCategory.TotalDishes = 0;
    this.NewCategory.RestaurantId = this.Id;
    this.NewCategory.Restaurant = null;
    
    this.restaurantService
      .AddCategory(this.Id, this.NewCategory)
      .subscribe(res => {
        this.ngOnInit();
        
      },
        err => {
          alert("error");
        });
  }

  

}
