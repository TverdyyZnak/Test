import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Author } from '../../entities/Author';
import { PageAuthor } from '../../entities/PageAuthor';

@Injectable({
  providedIn: 'root'
})
export class AuthorServiceService {
  constructor(private http: HttpClient) { }
  private apiUrl: string = "https://localhost:7017/Authors"

  getAllAuthors():Observable<Author[]>
  {
    return this.http.get<Author[]>(this.apiUrl)
  }

  getAuthorById(id: string):Observable<Author[]>
  {
    return this.http.get<Author[]>(`https://localhost:7017/Authors/${id}`)
  }

  postAuthor(author:PageAuthor):Observable<PageAuthor>
  {
    return this.http.post<PageAuthor>(this.apiUrl, author)
  }

  deleteAuthor(id: string):Observable<void>
  {
    return this.http.delete<void>(`${this.apiUrl}/${id}`)
  }

  putAuthor(id: string, author:Author):Observable<Author>
  {
    return this.http.put<Author>(`${this.apiUrl}/${id}`, author)
  }

}
