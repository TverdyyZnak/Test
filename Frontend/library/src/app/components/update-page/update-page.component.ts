import { CommonModule, DatePipe } from '@angular/common';
import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { AuthServiceService } from '../../services/auth/auth-service.service';
import { Author } from '../../entities/Author';
import { AuthorServiceService } from '../../services/author/author-service.service';
import { PageAuthor } from '../../entities/PageAuthor';
import { ActivatedRoute, Router } from '@angular/router';
import { Book } from '../../entities/Book';
import { BooksServiceService } from '../../services/books/books-service.service';
import { PageBook } from '../../entities/PageBook';
import { NEVER } from 'rxjs';

@Component({
  selector: 'app-update-page',
  imports: [CommonModule],
  templateUrl: './update-page.component.html',
  styleUrl: './update-page.component.css',
  providers: [DatePipe]

})
export class UpdatePageComponent  implements OnInit
{
  constructor(private bookService: BooksServiceService, private datePipe: DatePipe, private authorService: AuthorServiceService, private authService: AuthServiceService, private router: Router, private route: ActivatedRoute) {}

  bookId: string = ""
  authors: Author[] = []
  book: Book | null = null
  isVisible: boolean = false
  image: File | null = null;
  imagePreview: string | ArrayBuffer | null = null;
  maxImageSize = 5.9 * 1024 * 1024;
  
  @ViewChild('title') bookNameInput!: ElementRef<HTMLInputElement>
  @ViewChild('isbn') bookISBNInput!: ElementRef<HTMLInputElement>
  @ViewChild('description') bookDescriptionInput!: ElementRef<HTMLTextAreaElement>
  @ViewChild('genre') bookGenreInput!: ElementRef<HTMLInputElement>
  @ViewChild('bookAuthor') bookAuthorInput!: ElementRef<HTMLSelectElement>
  

  ngOnInit(): void {
    if(this.authService.getRole() != "Admin"){
      this.router.navigate(['/home'])
    }

    this.authorService.getAllAuthors().subscribe({
      next:(resp) => {
        this.authors = resp
      }    
    })

    this.bookId = this.route.snapshot.paramMap.get('id')!

    this.bookService.getBookById(this.bookId).subscribe({
      next:(res) => {
        this.book = res[0]

        this.bookNameInput.nativeElement.value = this.book.bookName
        this.bookISBNInput.nativeElement.value = this.book.isbn
        this.bookDescriptionInput.nativeElement.value = this.book.description
        this.bookGenreInput.nativeElement.value = this.book.genre
        this.bookAuthorInput.nativeElement.value = this.book.bookAuthorId
        this.imagePreview = 'data:image/jpeg;base64,' + this.book.image
      }
    })

     
  }
 

  async updateBook(newISBN: string, newBookName: string, newDescription: string, newGenre: string, newAuthorId: string){
    var imageString: string = this.book?.image!
    if(this.image != null){
      imageString = await this.convertFileToBase64(this.image)
    }
    
    

    
    var newBook: PageBook = {
      isbn: newISBN,
      bookName: newBookName,
      genre: newGenre,
      description: newDescription,
      bookAuthorId: newAuthorId,
      image: imageString,
      bookTook: null,
      bookReturned: null
    }

    newBook.bookTook = null
    newBook.bookReturned = null

    this.bookService.putBook(this.bookId, newBook).subscribe({
      next:(resp) => {
        console.log(resp)
      }
    })
    
    this.router.navigate(['/catalog'])
  }

  convertFileToBase64(file: File): Promise<string> {
    return new Promise<string>((resolve, reject) => {
      const reader = new FileReader();
      
      reader.onloadend = () => {
        const base64String = (reader.result as string).replace(/^data:image\/[a-zA-Z]+;base64,/, "");
        resolve(base64String);
      };
      
      reader.onerror = (error) => {
        reject('Error converting file to Base64: ' + error);
      };
  
      reader.readAsDataURL(file);
    });
  }

  onImageChange(event: any) {
    const file = event.target.files[0];
    if (file) {
      if (file.size > this.maxImageSize) {
        alert('Размер изображения не должен превышать 5.9MB');
        return;
      }
      const reader = new FileReader();
      reader.onload = () => {
        this.imagePreview = reader.result;
      };
      reader.readAsDataURL(file);
      this.image = file;
    }
  }

  switchPanel(){
    this.isVisible = !this.isVisible
  }

  addAuthor(name: string, surname: string, birthday: string, country: string){
      if(name == '' || surname == '' || birthday == null || country == ''){
        alert("Не все поля для добавления автора заполнены")
      }
      else{
        var author: PageAuthor = {
          name: name,
          surname: surname,
          birthday: this.datePipe.transform(birthday, 'yyyy-MM-dd') ?? '',
          country: country
        }
  
        console.log(new Date(birthday))
  
        this.authorService.postAuthor(author).subscribe({
          next:(resp) => {
            console.log("Успех!")
            this.switchPanel()
            location.reload()
          }
        })
      }
    }

  onSubmitText(iE: HTMLTextAreaElement) :string{
    return iE.value
  }

  onSubmitSelect(iE: HTMLSelectElement): string{
    return iE.value
  }

  onSubmit(iE: HTMLInputElement): string{
    return iE.value
  }
}
  

