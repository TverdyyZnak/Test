import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, retry } from 'rxjs';
import { LoginForm } from '../../entities/LoginForm';
import { HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs';
import { Token } from '../../entities/Token';

@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {
  
  constructor(private http: HttpClient) { }
  private apiUrl = "https://localhost:7017/api/Auth"
  
  authAndGetToken(userLogin: string, userPassword: string): Observable<Token>{
    const payload = { userLogin, userPassword };
    return this.http.post<Token>(this.apiUrl, payload)
  }



 
  clear(){
    localStorage.clear()
  }

  setRole(newRole: string): void {
    localStorage.setItem('role', newRole);
  }

  getRole():string{
    return localStorage.getItem('role')!
  }

  removeRolr():void{
    localStorage.removeItem('role')
  }

  setUserId(newId: string):void{
    localStorage.setItem('userId', newId)
  }

  getUserId():string{
    return localStorage.getItem('userId')!
  }

  removeUserId():void{
    localStorage.removeItem('userId')
  }

  setToken(token: string):void{
    localStorage.setItem('jwtToken', token)
  }

  getToken(): string{
    return localStorage.getItem('jwtToken')!
  }


  logout():void{
    localStorage.removeItem('jwtToken')
  }



  
}
