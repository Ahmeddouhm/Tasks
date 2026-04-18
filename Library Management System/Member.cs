using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management_System
{
    /*
    Properties/Attributes:

        name (string): Member's name
        memberId (string): Unique member ID
        borrowedBooks (List/Array of Book objects): List of books currently borrowed

    Methods:

        Constructor to initialize the member
        getInfo(): Returns member information
        borrowBook(book): Adds a book to borrowedBooks list
        returnBook(book): Removes a book from borrowedBooks list
     */
    internal class Member
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public List<Book>? BorrowedBooks { get; set; }

        public Member(string name , string id)
        {
            Name = name;
            ID = id;
            BorrowedBooks = new List<Book>();
        }

        public string GetInfo() 
        {
            StringBuilder sb = new StringBuilder();
            foreach (var book in BorrowedBooks)
            {
                sb.AppendFormat(book.Title, " | ");
            }
            return $"Name : {Name} | [{ID}] | Borrowed Books [{sb.ToString()}]";
        }

        public void BorrowBook(Book book) 
        {
            BorrowedBooks.Add(book);
        }

        public void ReturnBook(Book book) 
        {
            BorrowedBooks.Remove(book);
        }
    }
}
