import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../../entities/User';

@Injectable({
  providedIn: 'root'
})
export class UsersServiceService {

  constructor(private http: HttpClient) { }
    private apiUrl = "https://localhost:7017/Users"
  
    getUsers():Observable<User[]>
    {
      return this.http.get<User[]>(this.apiUrl)
    }

    postUser(user: User):Observable<User>
    {
      return this.http.post<User>(this.apiUrl, user)
    }
}
