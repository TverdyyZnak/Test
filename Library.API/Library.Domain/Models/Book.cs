using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Models
{
    public class Book
    {
        public Guid Id { get; }
        public Guid ISBN { get; }
        public string BookName { get; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Description { get; } = string.Empty;
        public Guid BookAuthorId { get; }
        public DateTime? BookTook { get; }
        public DateTime? BookReturned { get; }
        
        private Book(Guid id, Guid isbn, string bookName, string genre, string description, Guid bookAuthorId, DateTime bookTook, DateTime bookReturn) 
        {
            Id = id;
            ISBN = isbn;
            BookName = bookName;
            Genre = genre;
            Description = description;
            BookAuthorId = bookAuthorId;
            BookTook = bookTook;
            BookReturned = bookReturn;
        }


        public static (Book Book, string Error) BookCreate (Guid id, Guid isbn, string bookName, string genre, string description, Guid bookAuthorId, DateTime bookTook, DateTime bookReturn) 
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(bookName) || string.IsNullOrEmpty(genre) || string.IsNullOrEmpty(description)) 
            {
                error = "Book name cant be empty";
            }

            var book = new Book(id, isbn, bookName, genre, description, bookAuthorId, bookTook, bookReturn);


            return (book, error);
        }
    }
}
