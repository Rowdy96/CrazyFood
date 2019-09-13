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
import { ModalService } from '../../modal.service';

@Component({
  selector: 'app-restaurant-menu',
  templateUrl: './restaurant-menu.component.html',
  styleUrls: ['./restaurant-menu.component.css']
})
export class RestaurantMenuComponent implements OnInit {

  MenuOfRestaurant: MenuAC[];
  CurrentUser: UserAC = new UserAC();
  CategoryForm = new FormGroup({
    Category: new FormControl('')
  });

  dishForm = new FormGroup({
    Dish: new FormControl(''),
    price: new FormControl('')
  });

  Id: number;
  NewCategory: MenuCategory = new MenuCategory();
  NewDish: NewDish = new NewDish();

  constructor(private service: RestaurantDetailsService,
              private route: ActivatedRoute,
              private userService: UserService,
              private restaurantService: RestuarantService,
             
              ){ }

  ngOnInit() {

    this.GetMenu();
    this.userService.GetLoggedInUser().subscribe(
      res => {
        this.CurrentUser = res;
      },
      err => {
        this.CurrentUser = null;
      });
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
    this.NewCategory.menuCategoryName = this.CategoryForm.value.Category;
    this.NewCategory.totalDishes = 0;
    this.NewCategory.restaurantId = this.Id;
    this.NewCategory.restaurant = null;
    console.log(this.NewCategory);
    this.restaurantService
      .AddCategory(this.Id, this.NewCategory)
      .subscribe(res => {
        alert("New Category added Successfully");
        window.location.reload();
      },
        err => {
          alert("error");
        });
  }

  

}
