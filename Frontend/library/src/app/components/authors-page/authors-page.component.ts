import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthorServiceService } from '../../services/author/author-service.service';
import { Author } from '../../entities/Author';
import { BooksServiceService } from '../../services/books/books-service.service';
import { Observable } from 'rxjs';
import { Book } from '../../entities/Book';
import { Router } from '@angular/router';



@Component({
  selector: 'app-authors-page',
  imports: [CommonModule],
  templateUrl: './authors-page.component.html',
  styleUrl: './authors-page.component.css'
})
export class AuthorsPageComponent implements OnInit {

  constructor(private authorService: AuthorServiceService) {}
  
  authors: Author[] = []


  ngOnInit(): void {
    this.authorService.getAllAuthors().subscribe(
      (a) => this.authors = a
    )
  }


}
