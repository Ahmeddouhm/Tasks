
/* Bonus Challenge

    Add a limit to how many books a member can borrow at once (e.g., maximum 3 books) => DONE

    Add a method to search for books by title or author => DONE

    Keep track of borrowing history with dates => DONE

    Add error handling for cases like:

    Trying to borrow a book that's not available => DONE 
    Trying to return a book that wasn't borrowed => DONE
    Trying to borrow with an invalid ISBN => DONE

*/

// Create a library
using Library_Management_System;

Library library = new Library("City Central Library");

// Create books
Book book1 = new Book("Design Patterns", "Gang of Four", "978-0201633610");
Book book2 = new Book("Clean Code", "Robert Martin", "978-0132350884");
Book book3 = new Book("The Pragmatic Programmer", "Andy Hunt", "978-0135957059");

// Add books to library
library.AddBook(book1);
library.AddBook(book2);
library.AddBook(book3);

// Register members
Member member1 = new Member("Alice Johnson", "M001");
Member member2 = new Member("Bob Smith", "M002");

library.RegisterMember(member1);
library.RegisterMember(member2);

// Display available books
library.DisplayAvailableBooks();

Console.WriteLine("====================");
Console.WriteLine();

// Member borrows a book
library.LendBook(member1, "978-0201633610");
// [ERROR] Already Borrowed Book
library.LendBook(member2, "978-0201633610");
// [ERROR] Invalid ISBN
library.LendBook(member2, "978-0201633615");

Console.WriteLine("====================");
Console.WriteLine();

// Display available books again
library.DisplayAvailableBooks();

Console.WriteLine("====================");
Console.WriteLine();

// Display borrowed books again
library.DisplayBorrowedBooks();

Console.WriteLine("====================");
Console.WriteLine();

// Member returns a book
library.ReceiveBook(member1, "978-0201633610");
// [ERROR] Already Available Book
library.ReceiveBook(member1, "978-0201633610");

Console.WriteLine("====================");
Console.WriteLine();

// Test Search By ISBN
library.SearchBooksByISBN("978-0132350884");
// [ERROR] Not Found Book
library.SearchBooksByISBN("00000000000000");

Console.WriteLine("====================");
Console.WriteLine();

// Test Search By Author
library.SearchBooksByAuthor("Robert Martin");
// [ERROR] Not Found Book
library.SearchBooksByAuthor("Ahmed Mamdouh");

Console.WriteLine("====================");