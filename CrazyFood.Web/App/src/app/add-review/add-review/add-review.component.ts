import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-add-review',
  templateUrl: './add-review.component.html',
  styleUrls: ['./add-review.component.css']
})
export class AddReviewComponent implements OnInit {

  reviewForm = new FormGroup({
    rating : new FormControl(''),
    review : new FormControl('')
  })
  constructor() { }

  ngOnInit() {
  }

  onSubmit(){
    alert("Your Review : "+this.reviewForm.value.rating+"  "+this.reviewForm.value.review);
  }
}
