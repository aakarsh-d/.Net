using System;
using System.Collections.Generic;

class Program
{
    static List<dynamic> books = new List<dynamic>();
    static int idCounter = 1;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n1.Admin");
            Console.WriteLine("2.User");
            Console.WriteLine("3.Exit");
            Console.Write("Choice: ");
            int ch = int.Parse(Console.ReadLine());

            if (ch == 1) AdminMenu();
            else if (ch == 2) UserMenu();
            else break;
        }
    }

    static void AdminMenu()
    {
        Console.WriteLine("\n1.Add Book");
        Console.WriteLine("2.Update Book");
        Console.WriteLine("3.Delete Book");
        Console.WriteLine("4.View All Books");
        Console.Write("Choice: ");
        int ch = int.Parse(Console.ReadLine());

        if (ch == 1) AddBook();
        else if (ch == 2) UpdateBook();
        else if (ch == 3) DeleteBook();
        else if (ch == 4) ViewBooks();
    }

    static void UserMenu()
    {
        Console.WriteLine("\n1.Browse Books");
        Console.WriteLine("2.Search by Name");
        Console.WriteLine("3.Search by Publisher");
        Console.WriteLine("4.Highest Price Book");
        Console.WriteLine("5.Lowest Price Book");
        Console.Write("Choice: ");
        int ch = int.Parse(Console.ReadLine());

        if (ch == 1) ViewBooks();
        else if (ch == 2) SearchByName();
        else if (ch == 3) SearchByPublisher();
        else if (ch == 4) HighestPrice();
        else if (ch == 5) LowestPrice();
    }

    static void AddBook()
    {
        dynamic book = new System.Dynamic.ExpandoObject();

        book.Id = idCounter++;

        Console.Write("Name: ");
        book.Name = Console.ReadLine();

        Console.Write("Publisher: ");
        book.Publisher = Console.ReadLine();

        Console.Write("Price: ");
        book.Price = double.Parse(Console.ReadLine());

        books.Add(book);
        Console.WriteLine("Book Added");
    }

    static void UpdateBook()
    {
        Console.Write("Enter Book Id: ");
        int id = int.Parse(Console.ReadLine());

        foreach (dynamic b in books)
        {
            if (b.Id == id)
            {
                Console.Write("New Name: ");
                b.Name = Console.ReadLine();

                Console.Write("New Publisher: ");
                b.Publisher = Console.ReadLine();

                Console.Write("New Price: ");
                b.Price = double.Parse(Console.ReadLine());

                Console.WriteLine("Book Updated");
                return;
            }
        }

        Console.WriteLine("Book Not Found");
    }

    static void DeleteBook()
    {
        Console.Write("Enter Book Id: ");
        int id = int.Parse(Console.ReadLine());

        for (int i = 0; i < books.Count; i++)
        {
            if (books[i].Id == id)
            {
                books.RemoveAt(i);
                Console.WriteLine("Book Deleted");
                return;
            }
        }

        Console.WriteLine("Book Not Found");
    }

    static void ViewBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No Books Available");
            return;
        }

        foreach (dynamic b in books)
            Print(b);
    }

    static void SearchByName()
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        bool found = false;

        foreach (dynamic b in books)
        {
            if (b.Name.ToString().ToLower().Contains(name.ToLower()))
            {
                Print(b);
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("No Match Found");
    }

    static void SearchByPublisher()
    {
        Console.Write("Enter Publisher: ");
        string pub = Console.ReadLine();

        bool found = false;

        foreach (dynamic b in books)
        {
            if (b.Publisher.ToString().ToLower().Contains(pub.ToLower()))
            {
                Print(b);
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("No Match Found");
    }

    static void HighestPrice()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No Books");
            return;
        }

        dynamic max = books[0];

        foreach (dynamic b in books)
            if (b.Price > max.Price)
                max = b;

        Print(max);
    }

    static void LowestPrice()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No Books");
            return;
        }

        dynamic min = books[0];

        foreach (dynamic b in books)
            if (b.Price < min.Price)
                min = b;

        Print(min);
    }

    static void Print(dynamic b)
    {
        Console.WriteLine("Id: " + b.Id +
                          ", Name: " + b.Name +
                          ", Publisher: " + b.Publisher +
                          ", Price: " + b.Price);
    }
}
