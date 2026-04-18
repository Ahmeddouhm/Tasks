using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management_System
{
        /*
        Properties/Attributes:

            name (string): Library name
            books (List/Array of Book objects): List of all books in the library
            members (List/Array of Member objects): List of all registered members

        Methods:

            Constructor to initialize the library
            addBook(book): Adds a book to the library
            registerMember(member): Registers a new member
            lendBook(member, isbn): Allows a member to borrow a book by ISBN
            receiveBook(member, isbn): Processes a book return
            displayAvailableBooks(): Shows all available books
        */
    internal class Library
    {
        public string LibraryName { get; set; }
        public List<Book> Books { get; set; }
        public List<Member> Members { get; set; }

        public Library(string name)
        {
            LibraryName = name;
            Books = new List<Book>();
            Members = new List<Member>();
        }

        public void AddBook(Book book) 
        {
            Books.Add(book);
        }

        public void RegisterMember(Member member) => Members.Add(member);

        public void LendBook(Member member , string isbn) 
        {
            if (member.BorrowedBooks.Count >= 3)
            {
                Console.WriteLine("[ERROR]You Can not Borrow more than 3 Books At a Time !");
                return;
            }
            else
            {
                foreach (var book in Books)
                {
                    if (book.ISBN == isbn)
                    {
                        if (!book.IsAvailable)
                        {
                            Console.WriteLine($"[ERROR]{book.Title} is not Available !");
                            return;
                        }

                        book.Borrow(member);
                        member.BorrowBook(book);
                        Console.WriteLine($"{member.Name} borrowed: {book.Title} at {book.BorrowedTime}");
                        return;
                    }
                }
                Console.WriteLine($"[ERROR]{isbn} Is Invaild ISBN !");
            }
            
        }

        public void ReceiveBook(Member member, string isbn) 
        {
            foreach (var book in Books)
            {
                if (book.ISBN == isbn)
                {

                    if (book.IsAvailable)
                    {
                        Console.WriteLine($"[ERROR]{book.Title} is Available Book !");
                        return;
                    }
                    else
                    {
                        book.ReturnBook();
                        member.ReturnBook(book);
                        Console.WriteLine($"{member.Name} returned: {book.Title} ");
                        return;
                    }
                }
            }
        }

        public void DisplayAvailableBooks() 
        {
            Console.WriteLine($"Available books in {LibraryName} : ");
            foreach (var book in Books)
            {
                if (book.IsAvailable)
                {
                    Console.WriteLine($"- {book.Title} by {book.Author} (ISBN: {book.ISBN})");
                }
            }
        }
        public void DisplayBorrowedBooks() 
        {
            Console.WriteLine($"Borrowed books in {LibraryName} : ");
            foreach (var book in Books)
            {
                if (!book.IsAvailable)
                {
                    Console.WriteLine($"- {book.Title} borrowed by {book.BorrowedBy.Name} at {book.BorrowedTime} (ISBN: {book.ISBN})");
                }
            }
        }

        public void SearchBooksByISBN(string isbn)
        {
            bool found = false;

            foreach (var item in Books)
            {
                if (item.ISBN == isbn)
                {
                    Console.WriteLine($"Book Found => [{item.Title} | {item.Author} | ({item.ISBN})]");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine($"Book Not Found !");
            }
        }
        public void SearchBooksByAuthor(string author)
        {
            bool found = false;

            foreach (var item in Books)
            {
                if (item.Author.Equals(author, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Book Found => [{item.Title} | {item.Author} | ({item.ISBN})]");
                }
            }

            if (!found)
            {
                Console.WriteLine($"Book Not Found !");
            }
        }
    }
}
