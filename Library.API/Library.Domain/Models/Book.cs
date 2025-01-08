﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Models
{
    public class Book
    {
        public const int IMAGE_MAX_SIZE = 6291456;
        public Guid Id { get;}
        public Guid ISBN { get;}
        public string BookName { get;} = string.Empty;
        public string Genre { get; } = string.Empty;
        public string Description { get;} = string.Empty;
        public Guid BookAuthorId { get;}
        public DateTime BookTook { get;}
        public DateTime BookReturned { get;}
        public byte[] Image { get; } = [];
        
        private Book(Guid id, Guid isbn, string bookName, string genre, string description, Guid bookAuthorId, DateTime bookTook, DateTime bookReturn, byte[] image) 
        {
            Id = id;
            ISBN = isbn;
            BookName = bookName;
            Genre = genre;
            Description = description;
            BookAuthorId = bookAuthorId;
            BookTook = bookTook;
            BookReturned = bookReturn;
            Image = image;
        }


        public static (Book Book, string Error) BookCreate (Guid id, Guid isbn, string bookName, string genre, string description, Guid bookAuthorId, DateTime bookTook, DateTime bookReturn, byte[] image) 
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(bookName) || string.IsNullOrEmpty(genre) || string.IsNullOrEmpty(description)) 
            {
                error = "Book name cant be empty";
            }

            if(image.Length > IMAGE_MAX_SIZE) 
            {
                error = "Photo size is too big";
            }

            var book = new Book(id, isbn, bookName, genre, description, bookAuthorId, bookTook, bookReturn, image);


            return (book, error);
        }
    }
}
