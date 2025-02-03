import { Component, inject } from '@angular/core';
import { AuthServiceService } from '../../services/auth/auth-service.service';
import { HttpClient } from '@angular/common/http';
import { Token } from '../../entities/Token';
import { jwtDecode } from 'jwt-decode'
import { Router } from '@angular/router';
import { firstValueFrom } from 'rxjs';

@Component({
  selector: 'app-login-page',
  imports: [],
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.css'
})
export class LoginPageComponent {
  
  authService = inject(AuthServiceService)
  constructor(private http: HttpClient, private route: Router){}
  
  aaa(event: Event, login: string, password: string){
    event.preventDefault()
    this.registration(login, password)
  }

  async registration(login:string, password: string){
    var root: Token | null = null    
    const data: Token = await firstValueFrom(this.authService.authAndGetToken(login, password))
    
    this.authService.clear()
    
    root = data
    this.authService.setToken(root.token)
    
    const decod: any = this.decoderToken(root.token)
    const role: string = decod["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]
    
    this.authService.setRole(role)
    this.authService.setUserId(decod.sub)
    
    if(role == "Admin" || role == "User"){
      this.route.navigate(['/home'])
    }
    else{
      alert("Неверный логин или пароль")
    }
    
  }


  routeControle(){
    if(this.authService.getRole() == "Admin" || this.authService.getRole() == "User"){
      this.route.navigate(['/home'])
    }
    else{
      alert("Неверный логин или пароль")
    }
  }

 
  onSubmit(iE: HTMLInputElement): string{
    return iE.value
  }

  decoderToken(token: string): any{
   return jwtDecode(token)
  }
  

}
