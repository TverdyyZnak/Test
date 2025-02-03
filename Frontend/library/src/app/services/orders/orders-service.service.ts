import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Order } from '../../entities/Order';
import { PageOrder } from '../../entities/PageOrder';

@Injectable({
  providedIn: 'root'
})
export class OrdersServiceService {

  constructor(private http: HttpClient) { }
  private apiUrl = "https://localhost:7017/Orders"

  getOrders():Observable<Order[]>
  {
    return this.http.get<Order[]>(this.apiUrl)
  }

  getOrderskById(id: string):Observable<Order[]>
  {
    return this.http.get<Order[]>(`${this.apiUrl}/by-userId/${id}`)
  }

  getOrderskByBookId(id: string):Observable<Order[]>
  {
    return this.http.get<Order[]>(`${this.apiUrl}/by-bookId/${id}`)
  }
 
  postOrder(order: PageOrder):Observable<PageOrder>
  {
    return this.http.post<PageOrder>(this.apiUrl, order)
  }
  
  deleteOrder(id: string):Observable<void>
  {
    return this.http.delete<void>(`${this.apiUrl}/${id}`)
  }
}
