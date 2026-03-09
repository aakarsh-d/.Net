// public class Book
// {
// public string ISBN { get; set; }
// public string Title { get; set; }
// public string Author { get; set; }
// public string Genre { get; set; }
// public bool IsAvailable { get; set; }
// }
// // Generic catalog class
// public class Catalog<T> where T : Book
// {
// private List<T> _items = new List<T>(); // list for all books
// private HashSet<string> _isbnSet = new HashSet<string>(); // for tracking ISBN(uniqueness)
// private SortedDictionary<string, List<T>> _genreIndex = new
// SortedDictionary<string, List<T>>(); // to organize them by genre
// // Add item with genre indexing
// public bool AddItem(T item)
// {
// // TODO: Check ISBN uniqueness, add to list and genre index
// isbnSet.Add(item);
// }
// // Get books by genre using indexer
// public List<T> this[string genre]
// {
// get
// {
// // TODO: Return books by genre or empty list
// }
// }
// // Find books using LINQ and lambda expressions
// public IEnumerable<T> FindBooks(Func<T, bool> predicate)
// {
// // TODO: Use LINQ Where with predicate
// }
// }