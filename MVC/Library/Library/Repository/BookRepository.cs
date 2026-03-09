using Library.Models;
//using Library.Repositories;

namespace Library.Repository
{
    public class BookRepository:IBookRepository
    {
        private Dictionary<int, Book> books = new Dictionary<int, Book>()
        {
            {1,new Book{Id=1,Title="Java",Price=500,Author="MR. A"} },
            {2,new Book{Id=2,Title="C++",Price=800,Author="MR. B"} },
            {3,new Book{Id=3,Title="C#",Price=700,Author="MR. C"} }

        };

        //public Dictionary<int, Book> GetBooks()
        //{
        //    return books;
        //}

        //public void AddBook(Book book)
        //{
        //    books.Add(book.Id, book);
        //}

        public List<Book> ListByPrice(int price)
        {
            List<Book> sortedBooks = books.Values.Where(b => b.Price == price).OrderBy(b => b.Price).ToList();
            return sortedBooks;
        }
         public List<Book> ListByName(string name)
         {
             List<Book>sortedBooks = books.Values.Where(b => b.Title.Contains(name)).OrderBy(b => b.Title).ToList();
            //foreach (var book in sortedBooks)
            //{
            //    Console.WriteLine($"Id: {book.Id}, Title: {book.Title}, Price: {book.Price}, Author: {book.Author}");
            //}
            return sortedBooks;
        }

        public List<Book> ListAllBooks()
        {
            //foreach (var book in books.Values)
            //{
            //    Console.WriteLine($"Id: {book.Id}, Title: {book.Title}, Price: {book.Price}, Author: {book.Author}");
            //}

            return books.Values.ToList();
        }
        public void AddBook(Book book)
        {
            books.Add(book.Id, book);
        }
        //{
        //    var sortedBooks = books.Values.OrderBy(b => b.Price);
        //    foreach (var book in sortedBooks)
        //    {
        //        Console.WriteLine($"Id: {book.Id}, Title: {book.Title}, Price: {book.Price}, Author: {book.Author}");
        //    }
        //}
        //public void ListByName()
        //{
        //    var sortedBooks = books.Values.OrderBy(b => b.Title);
        //    foreach (var book in sortedBooks)
        //    {
        //        Console.WriteLine($"Id: {book.Id}, Title: {book.Title}, Price: {book.Price}, Author: {book.Author}");
        //    }
        //}
    }
}
