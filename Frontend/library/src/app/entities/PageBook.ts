export interface PageBook{
    isbn: string
    bookName: string
    genre: string
    description: string
    bookAuthorId: string,
    image: string,
    bookTook: Date | null
    bookReturned: Date | null
}