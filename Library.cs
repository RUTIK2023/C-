//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;
using System.Collections.Generic;

// Part 1: Book Class
public class Book
{
    // Attributes
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public bool Available { get; set; }

    // Constructor
    public Book(string title, string author, string isbn, bool available = true)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        Available = available;
    }

    // Override ToString method
    public override string ToString()
    {
        return $"Title: {Title}, Author: {Author}, ISBN: {ISBN}, Available: {(Available ? "Yes" : "No")}";
    }
}

// Part 2: EBook Subclass
public class EBook : Book
{
    // Additional attribute
    public int FileSize { get; set; } // File size in MB

    // Constructor
    public EBook(string title, string author, string isbn, int fileSize, bool available = true)
        : base(title, author, isbn, available)
    {
        FileSize = fileSize;
    }

    // Override ToString method to include file size
    public override string ToString()
    {
        return base.ToString() + $", File Size: {FileSize} MB";
    }
}

// Part 3: Library Class
public class Library
{
    private List<Book> books;

    // Constructor
    public Library()
    {
        books = new List<Book>();
    }

    // Add a book to the library
    public void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine($"Book added: {book.Title}");
    }

    // Remove a book by ISBN
    public void RemoveBook(string isbn)
    {
        bool found = false;
        for (int i = 0; i < books.Count; i++)
        {
            if (books[i].ISBN == isbn)
            {
                Console.WriteLine($"Book removed: {books[i].Title}");
                books.RemoveAt(i);
                found = true;
                break;
            }
        }
        if (!found)
        {
            Console.WriteLine($"Book with ISBN {isbn} not found.");
        }
    }

    // Search for a book by title
    public void SearchByTitle(string title)
    {
        bool found = false;
        for (int i = 0; i < books.Count; i++)
        {
            if (books[i].Title.ToLower().Contains(title.ToLower()))
            {
                Console.WriteLine(books[i]);
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine($"No books found with title containing '{title}'.");
        }
    }

    // List all available books in the library
    public void ListAllAvailableBooks()
    {
        bool availableBooksExist = false;
        Console.WriteLine("Listing all available books in the library:");
        for (int i = 0; i < books.Count; i++)
        {
            if (books[i].Available)
            {
                Console.WriteLine(books[i]);
                availableBooksExist = true;
            }
        }
        if (!availableBooksExist)
        {
            Console.WriteLine("No available books in the library.");
        }
    }

    // Display download size for eBooks
    public void DisplayEBookDownloadSizes()
    {
        bool eBooksExist = false;
        Console.WriteLine("Displaying download sizes for eBooks:");
        for (int i = 0; i < books.Count; i++)
        {
            if (books[i] is EBook)
            {
                EBook eBook = (EBook)books[i];
                Console.WriteLine($"Title: {eBook.Title}, File Size: {eBook.FileSize} MB");
                eBooksExist = true;
            }
        }
        if (!eBooksExist)
        {
            Console.WriteLine("No eBooks found in the library.");
        }
    }
}

// Demonstration
class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nLibrary Management System");
            Console.WriteLine("1. Add a Book");
            Console.WriteLine("2. Add an EBook");
            Console.WriteLine("3. Remove a Book by ISBN");
            Console.WriteLine("4. Search for a Book by Title");
            Console.WriteLine("5. List All Available Books");
            Console.WriteLine("6. Display eBook Download Sizes");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": // Add a Book
                    Console.Write("Enter Title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter Author: ");
                    string author = Console.ReadLine();
                    Console.Write("Enter ISBN: ");
                    string isbn = Console.ReadLine();
                    library.AddBook(new Book(title, author, isbn));
                    break;

                case "2": // Add an EBook
                    Console.Write("Enter Title: ");
                    string ebookTitle = Console.ReadLine();
                    Console.Write("Enter Author: ");
                    string ebookAuthor = Console.ReadLine();
                    Console.Write("Enter ISBN: ");
                    string ebookIsbn = Console.ReadLine();
                    Console.Write("Enter File Size (MB): ");
                    if (int.TryParse(Console.ReadLine(), out int fileSize))
                    {
                        library.AddBook(new EBook(ebookTitle, ebookAuthor, ebookIsbn, fileSize));
                    }
                    else
                    {
                        Console.WriteLine("Invalid file size. Please enter a valid number.");
                    }
                    break;

                case "3": // Remove a Book by ISBN
                    Console.Write("Enter ISBN of the book to remove: ");
                    string removeIsbn = Console.ReadLine();
                    library.RemoveBook(removeIsbn);
                    break;

                case "4": // Search for a Book by Title
                    Console.Write("Enter Title to search: ");
                    string searchTitle = Console.ReadLine();
                    library.SearchByTitle(searchTitle);
                    break;

                case "5": // List All Available Books
                    library.ListAllAvailableBooks();
                    break;

                case "6": // Display eBook Download Sizes
                    library.DisplayEBookDownloadSizes();
                    break;

                case "7": // Exit
                    running = false;
                    Console.WriteLine("Exiting the system. Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}