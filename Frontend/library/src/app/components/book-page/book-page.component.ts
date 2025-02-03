import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BooksServiceService } from '../../services/books/books-service.service';
import { Book } from '../../entities/Book';
import { AuthorServiceService } from '../../services/author/author-service.service';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { Author } from '../../entities/Author';
import { AuthServiceService } from '../../services/auth/auth-service.service';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { Order } from '../../entities/Order';
import { PageOrder } from '../../entities/PageOrder';
import { OrdersServiceService } from '../../services/orders/orders-service.service';
import { PageBook } from '../../entities/PageBook';
import { response } from 'express';


@Component({
  selector: 'app-book-info',
  imports: [CommonModule],
  templateUrl: './book-page.component.html',
  styleUrl: './book-page.component.css'
})
export class BookPageComponent implements OnInit {
  
  constructor(private authService: AuthServiceService, private router: Router, private route: ActivatedRoute, private orderService: OrdersServiceService, private authorService: AuthorServiceService , private bookService: BooksServiceService, private sanitizer: DomSanitizer){}
  
  book: Book | null = null
  authors: Author[] = []
  author: Author | null = null
  bookImage: string | null = ""
  globalBookId: string = ""
  role: string = ""
  isVisible: boolean = false

  switchPanel(){
    this.isVisible = !this.isVisible
  }

  delBook(){
    this.bookService.deleteBook(this.globalBookId).subscribe({
      next:(result) => {
        console.log(result)
      }
    })
    this.router.navigate(['/home'])
  }

  getRole(): string{
    return this.role
  }

  ngOnInit(): void {
    var bookId = this.route.snapshot.paramMap.get('id')!
    var authorId: string
    this.globalBookId = bookId
    this.role = this.authService.getRole()


    this.bookService.getBookById(bookId).subscribe({
      next:(responce) => {this.book = responce[0]
        this.bookImage = 'data:image/jpeg;base64,' + responce[0].image
        authorId = responce[0].bookAuthorId
        
        this.authorService.getAllAuthors().subscribe({
        next:(a)=>{
          var temp = a.filter(i => i.id === authorId)
          this.author = temp[0]
        }}
    )
      }
    })

  }


  createOrder():void{
    var order: PageOrder ={
      userId: this.authService.getUserId(),
      bookId: this.globalBookId
    }

    var newDate = new Date()
    newDate.setDate(newDate.getDate() + 30)
    var newBook: PageBook = {
      isbn: this.book?.isbn ?? "",
      bookName: this.book?.bookName ?? "",
      genre: this.book?.genre ?? "",
      description: this.book?.description ?? "",
      bookAuthorId: this.book?.bookAuthorId ?? "",
      image: this.book?.image ?? "",
      bookTook: new Date(),
      bookReturned: newDate
    }

    this.bookService.putBook(this.globalBookId, newBook).subscribe({
      next:(responce) => {
        console.log("Успех!")
      }
    })


    this.orderService.postOrder(order).subscribe({
      next:(resp) => {
        console.log("Успех 2.0!")
      }
    })
    this.router.navigate(['/home'])

  }

}
