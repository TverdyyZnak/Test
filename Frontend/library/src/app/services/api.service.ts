import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Book } from '../entities/Book';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  constructor(private http:HttpClient) { }
  private apiUrl = 'https://localhost:7017/api/books';

  getBooks=():Observable<Book[]>=> this.http.get<Book[]>("https://localhost:7017/Books");

}
