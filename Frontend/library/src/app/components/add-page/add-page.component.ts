import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { AuthorServiceService } from '../../services/author/author-service.service';
import { BooksServiceService } from '../../services/books/books-service.service';
import { Author } from '../../entities/Author';
import { PageAuthor } from '../../entities/PageAuthor';
import { DatePipe } from '@angular/common';
import { OnInit } from '@angular/core';
import { PageBook } from '../../entities/PageBook';
import { firstValueFrom } from 'rxjs';

@Component({
  selector: 'app-add-page',
  imports: [CommonModule],
  templateUrl: './add-page.component.html',
  styleUrl: './add-page.component.css',
  providers: [DatePipe]
})
export class AddPageComponent implements OnInit {

  constructor(private datePipe: DatePipe, private bookService: BooksServiceService, private authorService: AuthorServiceService) {}

  title = '';
  isbn = '';
  description = '';
  genre = '';
  author = '';
  image: File | null = null;
  imagePreview: string | ArrayBuffer | null = null;
  maxImageSize = 5.9 * 1024 * 1024;
  isVisible: boolean = false
  authors: Author[] = []

  ngOnInit(): void {
    this.authorService.getAllAuthors().subscribe({
      next:(resp) => {
        this.authors = resp
      }    
    })
  }

  switchPanel(){
    this.isVisible = !this.isVisible
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

  async addBook(isbn: string, bookName: string, genre: string, description: string, authorName: string){
    var imageString
    if(this.image == null)
    {
      imageString = '' 
    }
    else
    {
      imageString = await this.convertFileToBase64(this.image);
    }
    
    alert(isbn)
    alert(bookName)
    alert(genre)
    alert(description)
    alert(authorName)
    alert(imageString)
      
    var newBook: PageBook = {
      isbn: isbn,
      bookName: bookName,
      genre: genre,
      description: description,
      bookAuthorId: authorName,
      image: imageString,
      bookTook: null,
      bookReturned: null
    }

    this.bookService.postBook(newBook).subscribe({
      next:(resp) => {
        console.log("Успех!")
        //location.reload()
      }
    })
  }

  convertFileToBase64(file: File): Promise<string> {
    return new Promise<string>((resolve, reject) => {
      const reader = new FileReader();
      
      reader.onloadend = () => {
        // Убираем префикс "data:image/png;base64," или аналогичный
        const base64String = (reader.result as string).replace(/^data:image\/[a-zA-Z]+;base64,/, "");
        resolve(base64String);  // возвращаем только строку Base64 без префикса
      };
      
      reader.onerror = (error) => {
        reject('Error converting file to Base64: ' + error);
      };
  
      // Читаем файл как строку Base64
      reader.readAsDataURL(file);
    });
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
