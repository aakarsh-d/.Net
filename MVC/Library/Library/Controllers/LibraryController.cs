using Library.Models;
using Library.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class LibraryController : Controller
    {
        private readonly IBookRepository repo;

        public LibraryController(IBookRepository bookRepository)
        {
            repo = bookRepository;
        }

        [HttpGet("books/price/{price}")]
        public IActionResult ListByPrice(int price)
        {
            var books = repo.ListByPrice(price);

            List<string> result = new List<string>();

            foreach (var b in books)
            {
                result.Add($"{b.Title} - {b.Price}");
            }

            return Content(string.Join("\n", result));
        }

        [HttpGet("books/name/{name}")]
        public IActionResult ListByName(string name)
        {
            var books = repo.ListByName(name);

            List<string> result = new List<string>();

            foreach (var b in books)
            {
                result.Add($"{b.Title} - {b.Price}");
            }

            return Content(string.Join("\n", result));
        }

        [HttpGet("books")]
        public IActionResult ListAllBooks()
        {
            var books = repo.ListAllBooks();

            List<string> result = new List<string>();

            foreach (var b in books)
            {
                result.Add($"{b.Title} - {b.Price}");
            }

            return Content(string.Join("\n", result));
        }
        [HttpGet("books/add")]
        public IActionResult AddBook()
        {
            Book b = new Book
            {
                Id = 4,
                Title = "Python",
                Price = 600,
                Author = "Mr. D"
            };

            repo.AddBook(b);

            return Content("Book Added Successfully");
        }
    }
}