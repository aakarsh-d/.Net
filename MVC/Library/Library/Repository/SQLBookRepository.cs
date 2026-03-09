using Library.Data;
using Library.Models;

namespace Library.Repository
{
    public class SQLBookRepository : IBookRepository
    {
        private readonly AppDbContext context;

        public SQLBookRepository(AppDbContext db)
        {
            context = db;
        }

        public List<Book> ListAllBooks()
        {
            return context.Books.ToList();
        }

        public List<Book> ListByName(string name)
        {
            return context.Books
                          .Where(b => b.Title.Contains(name))
                          .ToList();
        }

        public List<Book> ListByPrice(int price)
        {
            return context.Books
                          .Where(b => b.Price == price)
                          .ToList();
        }
        public void AddBook(Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
        }
    }
}