import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap  } from '@angular/router';
import { CustomerServiceService } from '../customer-service.service';
import { OrderOfUserAC } from '../../Models/OrderOfUserAC';

@Component({
  selector: 'app-order-history',
  templateUrl: './order-history.component.html',
  styleUrls: ['./order-history.component.css']
})
export class OrderHistoryComponent implements OnInit {

  Orders: OrderOfUserAC[] = new Array();
  constructor(private route :ActivatedRoute,
              private customerService : CustomerServiceService) { }

  ngOnInit() {
    this.GetAllorder();
  }

  GetAllorder(){
    const customerId = this.route.parent.snapshot.paramMap.get('customerId');
    
    this.customerService.GetOrderHistory(customerId).subscribe(res=>{
      this.Orders = res;
      console.log(this.Orders);
      debugger;
    },
    err=>{
      console.log(err);
    });

  }
}
