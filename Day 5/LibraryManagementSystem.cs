using System.Collections.Generic;  // so that we can use our namespace that we created
using LibrarySystem;

// using namespace LibrarySystem.Items;


//nested namespace organizes large projects logically
// aliases reduce long namespace references and improves readibility
using LibItems= LibrarySystem.Items;
namespace LibrarySystem
{
    public interface IReservable
    {
        void Reserved();
    }
    public interface INotifiable
    {
        void Notification(string message);
    }
}
// basically library items is a general category that we defined with defaults and then we are divding it based on books, magazines, etc
// it will call library items as We are using namepsace of libraryitems to get 
// the methods and we are adding a list 
    namespace LibrarySystem.Items
    {
        public class Book
        {
            public string Title;
        public class Magazine
        {
            public string Title;
        }
    }
    namespace LibrarySystem.Users
    {
        public class Member
        {
            public string Role;
        // UserRole role=UserRole.Admin;
        // Console.WriteLine($"Role : {role}")
            
        }
        // public class users{
        //     public string name { get ; set; }
            
    }
    // implementing bonus task thta is ebook 
    namespace LibrarySystem.Items
{
    public class Ebook : LibraryItem
    {
        public override void DisplayItem()
        {
            Console.WriteLine(" Item Type: eBook ");
            Console.WriteLine($"TItle : {Title}");
            Console.WriteLine($"Author : {Author} ");
            Console.WriteLine($"Item ID : {ItemId}");
        }
        public override double LateFees(int days)
        {
            return 0;
        }
        public void Download()
        {
            Console.WriteLine("ebook downloaded successfully.");
        }
    }
}

// interfaces to be called 
// task 2 to create 2 interfaces 

// task 6 partial class 
// partial class split 1 class into multiple files but it is joined by the compiler in last
//Static members store system-wide data shared across all objects
public partial class LibraryAnalytics
{
    public static int totalborroweditems;
}
public partial class LibraryAnalytics
{
    public static void DisplayAnalytics()
    {
        Console.WriteLine($"Total Items Borrowed: {totalborroweditems}");
    }
    
}

// task 7 enums for userrole and itemstatus
// enum is better than string cuz it is having defined fixed set of named value
enum UserRole
{
    Admin,
    Librarian,
    Member
}

enum ItemStatus{
    Available,
    Borrowed,
    Reserved,
    Lost
}
namespace LibrarySystem.Items
{
public abstract class LibraryItem
{
    public String Title;
    public String Author;
    public String ItemId;

    public abstract void DisplayItem();
    // {
    //     Console.WriteLine("Title :"+Title);
    //     Console.WriteLine("Author :"+Author);
    //     Console.WriteLine("Item ID :"+ItemId);
    // }
    public abstract double LateFees(int days);
    
    // {
    //     int latefees=0;
    //     if (days > 7)
    //     {
    //         latefees=(days-7)*10;
    //     }

    // }
    
}

namespace LibrarySystem.Items{
public class Book : LibraryItem, IReservable, INotifiable   
{
    public override void DisplayItem()
    {
        Console.WriteLine("Item Type: Book");
        Console.WriteLine("Title :"+Title);
        Console.WriteLine("Author :"+Author);
        Console.WriteLine("Item ID :"+ItemId);
    
    }
    public override double LateFees(int days)
    {
        return days*1.0;
    }
        void IReservable.Reserved()
        {
            Console.WriteLine("Book Reserved Successfully");
        }
        void INotifiable.Notification(string message)
        {

            Console.WriteLine($"Notification: {message}");
        }
        //task 4 was to implement explicit interface
        // we cant directly call this explicit interface 
        // we need to defined it like left hand inference name obj = class name object on right hand
}
}
namespace LibrarySystem.Items{
public class Magazine : LibraryItem
{
    public override void DisplayItem()
    {
        Console.WriteLine("Item Type: Magazine");
        Console.WriteLine("Title :"+Title);
        Console.WriteLine("Author :"+Author);
        Console.WriteLine("Item ID :"+ItemId);
    }
    public override double LateFees(int days)
    {
        return days*0.5;
    }
}
}}

//interface -> defines what a class can do 





class Program
{
    static void Main(string[] args)
    {
        
    //task 3
    // using LibrarySystem.Items
    // we are using libraryitems cuz we want this list to store both books magazine and and even ebooks
    // it gonna accept it as long as it is library item
    // we are using library items as abtract and we can not use it as object 
    List<LibraryItem> items =new List<LibraryItem>();
    items.Add(new LibItems.Book{
    Title= "Book1", 
    Author=" Author1", 
    ItemId=1});
    items.Add(new LibItems.Magazine{
        Title= "Magazine", 
        Author=" Author2", 
        ItemId=2});

    foreach(LibItems.LibraryItem item in items)  // item is libraryItem refernce pointing a real object
    {
        item.DisplayItem();
    }
    LibrarySystem.IReservable res= new LibItems.Book();
    res.Reserved();
    LibrarySystem.INotifiable noti= new LibItems.Book();
    noti.Notification("Please return on time");

    LibItems.Magazine mag= new LibItems.Magazine();
    Console.WriteLine("Late fees for magazine: "+mag.LateFees(3));
    LibItems.Book book= new LibItems.Book();
    Console.WriteLine("Late fees for Book: "+mag.LateFees(4));
    
    LibItems.Ebook ebook = new LibItems.Ebook();
    ebook.Download();
    LibraryAnalytics.totalborroweditems=5;
    LibraryAnalytics.DisplayAnalytics();

    UserRole adminRole=UserRole.Admin;
    UserRole memberRole=UserRole.Member;
    if (adminRole==UserRole.Admin)
        {
            Console.WriteLine("Admin Alert : System Alert");
        }
    else if (memberRole == UserRole.Member)
        {
            Console.WriteLine("Member Notification: Borrowed items is due tomorrow");
        }
    }
}