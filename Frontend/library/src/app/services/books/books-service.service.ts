import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Book } from '../../entities/Book';
import { PageBook } from '../../entities/PageBook';

@Injectable({
  providedIn: 'root'
})
export class BooksServiceService {

  constructor(private http: HttpClient) { }
  private apiUrl = "https://localhost:7017/Books"

  getBooks=():Observable<Book[]>=> this.http.get<Book[]>(this.apiUrl)

  getBookById(id: string):Observable<Book[]>
  {
    return this.http.get<Book[]>(`${this.apiUrl}/by-id/${id}`)
  }

  getBookByISBN(isbn: string):Observable<Book[]>
  {
    return this.http.get<Book[]>(`${this.apiUrl}/by-isbn/${isbn}`)
  }
  
  getBookByAuthorId(authorId: string):Observable<Book[]>
  {
    return this.http.get<Book[]>(`${this.apiUrl}/by-author/${authorId}`)
  }

  postBook(book: PageBook):Observable<PageBook>
  {
    return this.http.post<PageBook>(this.apiUrl, book)
  }

  deleteBook(id: string):Observable<void>
  {
    return this.http.delete<void>(`${this.apiUrl}/${id}`)
  }

  putBook(id: string, newBook: PageBook):Observable<PageBook>
  {
    return this.http.put<PageBook>(`${this.apiUrl}/${id}`, newBook)
  }

  putPhoto(id: string, image:string):Observable<string>
  {
    return this.http.put<string>(`${this.apiUrl}/books/add-photo/${id}`, image)
  }
}

