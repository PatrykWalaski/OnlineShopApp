import { Component, OnInit } from '@angular/core';
import { OrdersService } from '../orders.service';
import { IOrder } from 'src/app/shared/models/order';
import { ActivatedRoute } from '@angular/router';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'app-order-detailed',
  templateUrl: './order-detailed.component.html',
  styleUrls: ['./order-detailed.component.scss']
})
export class OrderDetailedComponent implements OnInit {
  order: IOrder;

  constructor(private ordersService: OrdersService, private activateRoute: ActivatedRoute,
              private bcService: BreadcrumbService){
      this.bcService.set('@OrderDetailed', '');
     }

  ngOnInit(): void {
    this.getOrder();
  }

  // tslint:disable-next-line: typedef
  getOrder() {
    this.ordersService.getOrder(+this.activateRoute.snapshot.paramMap.get('id')).subscribe(order => {
      this.order = order;
      this.bcService.set('@OrderDetailed', 'Order #' + order.id.toString() + ' - ' + order.status);
      console.log(order);
    }, error => {
      console.log(error);
    });
  }
}
