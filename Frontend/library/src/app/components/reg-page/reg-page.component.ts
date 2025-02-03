import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { UsersServiceService } from '../../services/users/users-service.service';
import { User } from '../../entities/User';
import { response } from 'express';
import { Router } from '@angular/router';

@Component({
  selector: 'app-reg-page',
  imports: [CommonModule],
  templateUrl: './reg-page.component.html',
  styleUrl: './reg-page.component.css'
})
export class RegPageComponent {

  constructor(private router: Router, private userService: UsersServiceService) {}

  createAccount(login: string, password: string, email: string) {

    var user: User = {
      login: login,
      password: password,
      email: email,
      root: false
    }


    this.userService.postUser(user).subscribe({
      next:(response) => {
        console.log(response)
        this.router.navigate(['/account'])
      }
    })

    
  }

  onSubmit(iE: HTMLInputElement): string{
    return iE.value
  }
}
