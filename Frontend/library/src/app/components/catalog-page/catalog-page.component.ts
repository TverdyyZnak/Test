import { Component, inject, OnInit } from '@angular/core';
import { BooksServiceService } from '../../services/books/books-service.service';
import { CommonModule } from '@angular/common';
import { Book } from '../../entities/Book';
import { AuthorServiceService } from '../../services/author/author-service.service';
import { Author } from '../../entities/Author';
import { Router } from '@angular/router';


@Component({
  selector: 'app-catalog-page',
  imports: [CommonModule],
  templateUrl: './catalog-page.component.html',
  styleUrl: './catalog-page.component.css'
})
export class CatalogPageComponent implements OnInit {
  bookService = inject(BooksServiceService)
  authorService = inject(AuthorServiceService)
  
  constructor(private route: Router){}

  books: Book[] =[]
  book: Book[] =[]
  authors: Author[] = []
  inputValue: string = ''

  goToBookDetail(bookId: string): void {
    this.route.navigate(['/book-info', bookId]);
  }

  onSerchByISBN(isbn:string){
    this.book = this.books.filter(item => item.isbn.includes(isbn))
    if(isbn.length ===0){
      this.ngOnInit()
    }
  }

  onSerchByBookName(name: string){
    this.book = this.books.filter(item => item.bookName.toLowerCase().includes(name.toLowerCase()))
    if(name.length === 0){
      this.ngOnInit()
    }
  }

  onSelectByAuthor(event: Event){
    const authorId = (event.target as HTMLSelectElement).value;

    this.book = this.books.filter(item => item.bookAuthorId === authorId);

    if(authorId === ""){
      this.ngOnInit()
    }
  }

  onSerchByGenre(bookGenre: string){
    this.book = this.books.filter(item => item.genre.toLowerCase().includes(bookGenre.toLowerCase()))
    if(bookGenre.length === 0){
      this.ngOnInit()
    }
  }

  onSubmit(iE: HTMLInputElement): string{
    return iE.value
  }

  fromNameSerch(bookName: HTMLInputElement):string{
    return bookName.value
  }

  ngOnInit(): void {
    this.authors = []

    this.bookService.getBooks().subscribe({
      next:(responce) => {
        
       
        
        var j: number = 0
        for(var i:number = 0; i < responce.length; i++)
        {
          if(responce[i].bookTook == null && responce[i].bookReturned == null){
            this.books[j] = responce[i]
            j++
          }
        }


      
        this.book = this.books.sort((a:Book, b:Book) => {
          return a.bookName.localeCompare(b.bookName);  
        }
        

    )}
      ,
      error:(err)=>{
      }
    })
    
    this.authorService.getAllAuthors().subscribe({
      next:(response) => {
        this.authors = response
      }
    })

  }

  loadBookByISBN(isbn:string):void
  {
    this.books = []

    this.bookService.getBookByISBN(isbn).subscribe({
      next:(response) => {
        this.book = response
      }
    })
  }

  loadBooksByAuthor(name:string)
  {
    this.authorService.getAllAuthors().subscribe({
      next:(response) => {
        this.authors = response
      }
    })

    this.authors = this.authors.filter(a => a.name === name)

  }

  get length(): number{
    return this.book.length
  }

}
  



