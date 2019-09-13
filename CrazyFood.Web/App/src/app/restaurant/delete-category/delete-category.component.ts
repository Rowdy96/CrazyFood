import { Component, OnInit } from '@angular/core';
import { RestuarantService } from '../restuarant.service';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-delete-category',
  templateUrl: './delete-category.component.html',
  styleUrls: ['./delete-category.component.css']
})
export class DeleteCategoryComponent implements OnInit {

  constructor(private restaurantService: RestuarantService,
    private route: ActivatedRoute,
    private location: Location) { }

  ngOnInit() {
  }

  Delete() {
    const id = +this.route.snapshot.paramMap.get('menuCategoryId');
    this.restaurantService.DeleteMenuCategory(id).subscribe(res => {
      this.location.back();
    })
  }

  Back() {
    this.location.back();
  }
}
