using System;
using System.Collections.Generic;

class Book
{
    public int BookID { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public bool IsAvailable { get; set; }

    public Book(int bookID, string title, string author)
    {
        BookID = bookID;
        Title = title;
        Author = author;
        IsAvailable = true;
    }

    public void DisplayBookDetails()
    {
        Console.WriteLine($"BookID: {BookID}, Title: {Title}, Author: {Author}");
    }

    public void DisplayBookDetails(bool showAvailability)
    {
        Console.WriteLine($"BookID: {BookID}, Title: {Title}, Author: {Author}, Available: {IsAvailable}");
    }
}

class User
{
    public int UserID { get; set; }
    public string Name { get; set; }
    public int BorrowedBookID { get; set; }

    public User(int userID, string name)
    {
        UserID = userID;
        Name = name;
        BorrowedBookID = -1; // -1 means no book borrowed
    }

    public virtual void DisplayUserDetails()
    {
        Console.WriteLine($"UserID: {UserID}, Name: {Name}, Borrowed Book ID: {(BorrowedBookID == -1 ? "None" : BorrowedBookID.ToString())}");
    }
}

class PremiumUser : User
{
    public string MembershipLevel { get; set; }

    public PremiumUser(int userID, string name, string membershipLevel) : base(userID, name)
    {
        MembershipLevel = membershipLevel;
    }

    public override void DisplayUserDetails()
    {
        Console.WriteLine($"UserID: {UserID}, Name: {Name}, Membership Level: {MembershipLevel}, Borrowed Book ID: {(BorrowedBookID == -1 ? "None" : BorrowedBookID.ToString())}");
    }
}

class Library
{
    public List<Book> Books { get; set; } = new List<Book>();
    public List<User> Users { get; set; } = new List<User>();

    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    public void AddUser(User user)
    {
        Users.Add(user);
    }

    public void BorrowBook(int userID, int bookID)
    {
        User user = Users.Find(u => u.UserID == userID);
        Book book = Books.Find(b => b.BookID == bookID);

        if (user != null && book != null && book.IsAvailable)
        {
            user.BorrowedBookID = bookID;
            book.IsAvailable = false;
            Console.WriteLine($"{user.Name} borrowed {book.Title}.");
        }
        else
        {
            Console.WriteLine("Book not available or invalid details.");
        }
    }

    public void ReturnBook(int userID)
    {
        User user = Users.Find(u => u.UserID == userID);
        if (user != null && user.BorrowedBookID != -1)
        {
            Book book = Books.Find(b => b.BookID == user.BorrowedBookID);
            if (book != null)
            {
                book.IsAvailable = true;
                Console.WriteLine($"{user.Name} returned {book.Title}.");
                user.BorrowedBookID = -1;
            }
        }
        else
        {
            Console.WriteLine("No book to return.");
        }
    }
}

class Program
{
    static void Main()
    {
        Library library = new Library();

        library.AddBook(new Book(1, "The Great Gatsby", "F. Scott Fitzgerald"));
        library.AddBook(new Book(2, "1984", "George Orwell"));
        library.AddBook(new Book(3, "To Kill a Mockingbird", "Harper Lee"));

        library.AddUser(new User(101, "Alice"));
        library.AddUser(new PremiumUser(102, "Bob", "Gold"));

        Console.WriteLine("--- Books Before Borrowing ---");
        foreach (var book in library.Books)
            book.DisplayBookDetails(true);

        Console.WriteLine("\n--- Users Before Borrowing ---");
        foreach (var user in library.Users)
            user.DisplayUserDetails();

        Console.WriteLine("\n--- Borrowing Book ---");
        library.BorrowBook(101, 1);
        library.BorrowBook(102, 2);

        Console.WriteLine("\n--- Books After Borrowing ---");
        foreach (var book in library.Books)
            book.DisplayBookDetails(true);

        Console.WriteLine("\n--- Users After Borrowing ---");
        foreach (var user in library.Users)
            user.DisplayUserDetails();

        Console.WriteLine("\n--- Returning Book ---");
        library.ReturnBook(101);
        library.ReturnBook(102);

        Console.WriteLine("\n--- Books After Returning ---");
        foreach (var book in library.Books)
            book.DisplayBookDetails(true);

        Console.WriteLine("\n--- Users After Returning ---");
        foreach (var user in library.Users)
            user.DisplayUserDetails();
    }
}
