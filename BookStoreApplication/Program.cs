using System;

namespace BookStoreApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO:
            // 1. Read initial input
            // Format: BookID Title Price Stock
            string data=Console.ReadLine();
            char sep=' ';
            string[] Data=data.Split(sep);
            string id=Data[0];
            string title=Data[1];
            int price=int.Parse(Data[2]);
            int stock=int.Parse(Data[3]);

            Book book = new Book()
            {
                Id=id,
                Title=title,
                Stock=stock,
                Price=price
                
            };



            BookUtility utility = new BookUtility(book);

            int choice; // TODO: Read user choice
            while (true)
            {
                // TODO:
                // Display menu:
                // 1 -> Display book details
                // 2 -> Update book price
                // 3 -> Update book stock
                // 4 -> Exit
                Console.WriteLine("Choice 1: Display Book Details");
                Console.WriteLine("Choice 2: Update Book Price");
                Console.WriteLine("Choice 3: Update Book Stock");
                Console.WriteLine("Choice 4: Exit");

                choice=int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        utility.GetBookDetails();
                        break;

                    case 2:
                        // TODO:
                        // Read new price
                        // Call UpdateBookPrice()
                        int newPrice=Convert.ToInt32(Console.ReadLine());
                        utility.UpdateBookPrice(newPrice);

                        break;

                    case 3:
                        // TODO:
                        // Read new stock
                        // Call UpdateBookStock()
                        int updatestock=Convert.ToInt32(Console.ReadLine());
                        utility.UpdateBookStock(updatestock);
                        break;

                    case 4:
                        Console.WriteLine("Thank You");
                        return;

                    default:
                        // TODO: Handle invalid choice
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
    }
}
