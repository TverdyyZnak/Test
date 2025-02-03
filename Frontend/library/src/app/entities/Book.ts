export interface Book
{
    id:string
    isbn: string
    bookName: string
    genre: string
    description: string
    bookAuthorId: string,
    image: string,
    bookTook: Date
    bookReturned: Date
}