namespace Library.Domain.Models
{
    public class Author
    {
        public Guid Id { get;}
        public string Name { get;} = string.Empty;
        public string Surname { get;} = string.Empty;
        public DateOnly Birthday { get;}
        public string Country { get;} = string.Empty;
        

        private Author(Guid id, string name, string surname, DateOnly birthday, string country) 
        {
            Id = id;
            Name = name;
            Surname = surname;
            Birthday = birthday;
            Country = country;
        }

        public static (Author Author, string Error) AuthorCreate(Guid id, string name, string surname, DateOnly birthday, string country) 
        {
            string error = string.Empty;

            if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname) || string.IsNullOrEmpty(country)) 
            {
                error = "Not all fields are filled in";
            }

            var author = new Author(id, name, surname, birthday, country);

            return (author, error); 
        }
    }
}
