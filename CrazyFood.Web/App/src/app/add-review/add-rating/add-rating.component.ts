import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-add-rating',
  templateUrl: './add-rating.component.html',
  styleUrls: ['./add-rating.component.css']
})
export class AddRatingComponent implements OnInit {

  ratingForm = new FormGroup({
    rating : new FormControl('')
  })
  constructor() { }

  ngOnInit() {
  }
  onSubmit(){
    alert(this.ratingForm.value.rating);
  }
}
