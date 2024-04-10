using System.Collections.Generic;

class Program
{
    static List<Book> books = new List<Book>();
    static List<User> users = new List<User>();

    public static void Main()
    {
        Console.WriteLine("Library Management System");

        while (true)
        {
            // Management System Menu
            Console.WriteLine("\n1. Add Book");
            Console.WriteLine("2. Update Book");
            Console.WriteLine("3. Remove Book");
            Console.WriteLine("4. Add User");
            Console.WriteLine("5. Display All Books");
            Console.WriteLine("6. Display All Users");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your choice: ");

            // Read user input
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            // Perform action based on user choice
            switch (choice)
            {
                case 1:
                    AddBook();
                    break;
                case 2:
                    UpdateBook();
                    break;
                case 3:
                    RemoveBook();
                    break;
                case 4:
                    AddUser();
                    break;
                case 5:
                    DisplayAllBooks();
                    break;
                case 6:
                    DisplayAllUsers();
                    break;
                case 7:
                    Console.WriteLine("Exiting Program...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 7.");
                    break;
            }
        }
    }

    static void AddBook()
    {
        Console.WriteLine("\nEnter book details:");
        Console.Write("Book ID: ");
        int bookId;
        if (!int.TryParse(Console.ReadLine(), out bookId))
        {
            Console.WriteLine("Invalid input for Book ID. Please enter a valid number.");
            return;
        }

        Console.Write("Title: ");
        string? newTitle = Console.ReadLine() ?? "";
        Console.Write("Author: ");
        string? newAuthor = Console.ReadLine() ?? "";
        Console.Write("Year: ");
        int newYear;
        if (!int.TryParse(Console.ReadLine(), out newYear))
        {
            Console.WriteLine("Invalid input for Year. Please enter a valid number.");
            return;
        }

        Book newBook = new Book(bookId, newTitle, newAuthor, newYear);
        books.Add(newBook);

        Console.WriteLine("Book added successfully.");
    }

    static void UpdateBook()
    {
        Console.WriteLine("\nEnter the ID of the book to update: ");
        int bookIdToUpdate;
        if (!int.TryParse(Console.ReadLine(), out bookIdToUpdate))
        {
            Console.WriteLine("Invalid input. Please enter a valid book ID.");
            return;
        }

        // Find the book in the list
        Book bookToUpdate = books.Find(book => book.BookId == bookIdToUpdate);
        if (bookToUpdate == null)
        {
            Console.WriteLine("Book not found.");
            return;
        }

        // Prompt for new details
        Console.WriteLine("Enter new details for the book:");
        Console.Write("Title: ");
        string newTitle = Console.ReadLine() ?? "";
        Console.Write("Author: ");
        string newAuthor = Console.ReadLine() ?? "";
        Console.Write("Year: ");
        int newYear;
        if (!int.TryParse(Console.ReadLine(), out newYear))
        {
            Console.WriteLine("Invalid input for Year. Please enter a valid number.");
            return;
        }

        // Update the book properties
        bookToUpdate.Title = newTitle;
        bookToUpdate.Author = newAuthor;
        bookToUpdate.Year = newYear;

        Console.WriteLine("Book updated successfully.");
    }

    static void RemoveBook()
    {
        Console.WriteLine("\nEnter the ID of the book to remove: ");
        int bookIdToRemove;
        if (!int.TryParse(Console.ReadLine(), out bookIdToRemove))
        {
            Console.WriteLine("Invalid input. Please enter a valid book ID.");
            return;
        }

        // Find the book in the list
        Book bookToRemove = books.Find(book => book.BookId == bookIdToRemove);
        if (bookToRemove == null)
        {
            Console.WriteLine("Book not found.");
            return;
        }

        // Remove the book
        books.Remove(bookToRemove);
        Console.WriteLine("Book removed successfully.");
    }

    static void AddUser()
    {
        Console.WriteLine("\nEnter user details:");
        Console.Write("User Name: ");
        string userName = Console.ReadLine() ?? "";
        Console.Write("User ID: ");
        int userId;
        if (!int.TryParse(Console.ReadLine(), out userId))
        {
            Console.WriteLine("Invalid input for User ID. Please enter a valid number.");
            return;
        }

        Console.Write("Email: ");
        string userEmail = Console.ReadLine() ?? "";

        User newUser = new User(userName, userId, userEmail);
        users.Add(newUser);

        Console.WriteLine("User added successfully.");
    }

    static void DisplayAllBooks()
    {
        Console.WriteLine("\nAll Books:");
        foreach (Book book in books)
        {
            Console.WriteLine(book);
        }
    }

    static void DisplayAllUsers()
    {
        Console.WriteLine("\nAll Users:");
        foreach (User user in users)
        {
            Console.WriteLine(user);
        }
    }
}

class Book
{
    // Properties
    public int BookId { get; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }

    // Constructor
    public Book(int bookId, string title, string author, int year)
    {
        BookId = bookId;
        Title = title;
        Author = author;
        Year = year;
    }

    // Display book details
    public override string ToString()
    {
        return $"Book ID: {BookId}\nTitle: {Title}\nAuthor: {Author}\nYear: {Year}";
    }
}

class User
{
    // Properties
    public int UserId { get; }
    public string UserName { get; }
    public string Email { get; }

    // Constructor
    public User(string userName, int userId, string email)
    {
        UserId = userId;
        UserName = userName;
        Email = email;
    }

    // Display user details
    public override string ToString()
    {
        return $"User ID: {UserId}\nName: {UserName}\nEmail: {Email}";
    }
}
