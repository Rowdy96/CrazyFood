import { Component, OnInit, Input } from '@angular/core';
import { OrderAC } from '../../Models/OrderAC';
import { Dish } from '../../Models/Dish';
import { OrderItem } from '../../Models/OrderItem';
import { UserAC } from '../../Models/UserAC';
import { Order } from '../../Models/Order';
import { OrderOnlineService } from '../order-online.service';

@Component({
  selector: 'app-customer-order',
  templateUrl: './customer-order.component.html',
  styleUrls: ['./customer-order.component.css']
})
export class CustomerOrderComponent implements OnInit {

  @Input() ItemList: Dish[];
  @Input() totalOrderPrice: number;
  @Input() CurrentUser: UserAC;
  order: Order = new Order();
  OrderAC: OrderAC = new OrderAC();
  OrderItemList: OrderItem[] = new Array();
  constructor(private orderService: OrderOnlineService) { }

  ngOnInit() {

  }

  

  proceed() {
    if (this.ItemList==null) {
      alert("Add Item"); 
    }
    else
    {
      this.order.UserId = this.CurrentUser.Id;
      this.order.IsOnTheWay = false;
      this.order.IsOderPreparing = false;
      this.order.IsOrderDelivered = false;

      for (var selectedItem of this.ItemList) {
        var item = new OrderItem();
        item.DishId = selectedItem.Id;
        item.ItemCount = selectedItem.ItemCount;
        this.OrderItemList.push(item);
      }

      this.OrderAC.Order = this.order;
      this.OrderAC.OrderItem = this.OrderItemList;

      console.log(this.OrderAC);
      this.orderService.AddOrder(this.OrderAC).subscribe(res => {
        alert("order Added successfully");
      },

        err => {
          console.log(err);
        });
    }

    }
   

}
