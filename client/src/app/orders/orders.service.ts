import { Injectable } from '@angular/core';
import { HttpClientModule, HttpClient, HttpParams } from '@angular/common/http';
import { IOrder } from '../shared/models/order';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getOrder(id: number){
    return this.http.get<IOrder>(this.baseUrl + 'orders/' + id);
  }

  getOrders() {
    return this.http.get<IOrder[]>(this.baseUrl + 'orders');
  }
}
