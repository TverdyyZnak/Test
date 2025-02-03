import { Component, provideExperimentalCheckNoChangesForDebug } from '@angular/core';
import { AuthServiceService } from '../../services/auth/auth-service.service';
import { OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Order } from '../../entities/Order';
import { OrdersServiceService } from '../../services/orders/orders-service.service';
import { Router } from '@angular/router';
import { BooksServiceService } from '../../services/books/books-service.service';
import { Book } from '../../entities/Book';
import { firstValueFrom } from 'rxjs';
import { PageBook } from '../../entities/PageBook';


@Component({
  selector: 'app-account-page',
  imports: [CommonModule],
  templateUrl: './account-page.component.html',
  styleUrl: './account-page.component.css'
})
export class AccountPageComponent implements OnInit {
  constructor(private bookService: BooksServiceService, private router: Router, private authService: AuthServiceService, private orderService: OrdersServiceService) {  
  }

  
  orders: Order[]=[]
  books: Book[] = []
  role: string = ""
  ngOnInit(): void {
    this.books = []
    this.orders  = []
    console.log(this.authService.getUserId())
    this.getInfo(this.authService.getUserId())
    
  }
  

  isLog():boolean{
    if(this.authService.getRole() != null){
      return true
    }
    else{
      return false
    }
  }

  async getOrdersInfo(){
    for(let i: number = 0; i < this.orders.length; i++)
    {
      var b: Book[] = await firstValueFrom(this.bookService.getBookById(this.orders[i].bookId))
      this.books[i] = b[0]
      
    }
  }

  async getInfo(userId: string){

    this.orderService.getOrderskById(userId).subscribe({
      next:(response) => {
        this.orders = response
        this.getOrdersInfo()
      }
    })    

  }

  exit():void{
    this.orders = []
    this.authService.clear()
    this.router.navigate(['/home'])
  }

  roleToPage(): string{
    return this.authService.getRole()
  }

  delOrder(bookId:string){
    this.orderService.getOrderskByBookId(bookId).subscribe({
      next:(responce) => {
        var order: Order = responce[0]

        this.putNullDays(bookId)

        this.orderService.deleteOrder(order.id).subscribe({
          next:(resp) => {

            console.log("Успех!")
            location.reload()
          }
        })
      }
    })
  }

  putNullDays(bookId: string){
    
    this.bookService.getBookById(bookId).subscribe({
      next:(response) => {
        var book: Book = response[0]

        var newBook: PageBook = {
          isbn: book?.isbn ?? "",
          bookName: book?.bookName ?? "",
          genre: book?.genre ?? "",
          description: book?.description ?? "",
          bookAuthorId: book?.bookAuthorId ?? "",
          image: book?.image ?? "",
          bookTook: null,
          bookReturned: null
        }

        this.bookService.putBook(bookId, newBook).subscribe({
          next:(resp) => console.log("Дата изменина")
        })
      }
    })
  }

}
