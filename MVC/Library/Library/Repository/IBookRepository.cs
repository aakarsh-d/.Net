using Library.Models;

namespace Library.Repository
{
    public interface IBookRepository
    {
        public List<Book> ListByPrice(int price);
        public List<Book> ListByName(string name);
        public List<Book> ListAllBooks();

        void AddBook(Book book);


        //void AddBook(Book book);
    }
}
