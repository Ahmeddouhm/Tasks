using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management_System
{
        /*
        Properties/Attributes:
        
            title (string): The book's title
            author (string): The book's author
            isbn (string): The book's ISBN number
            isAvailable (boolean): Whether the book is available for borrowing
        
        Methods:

            Constructor to initialize the book
            getInfo(): Returns a formatted string with book details
            borrow(): Marks the book as borrowed (not available)
            returnBook(): Marks the book as returned (available)
         */
    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsAvailable { get; set; }

        public DateTime BorrowedTime { get; set; }

        public Member BorrowedBy { get; set; }

        public Book(string title , string author , string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            IsAvailable = true;
        }

        public string GetInfo() => $"Book => {Title} for {Author} | [ISBN : {ISBN}] | Availability : {IsAvailable}";

        public void Borrow(Member member) 
        {
            this.IsAvailable = false;
            BorrowedTime = DateTime.Now;
            BorrowedBy = member;
        }

        public void ReturnBook() 
        {
            this.IsAvailable = true;
            BorrowedBy = null;
            BorrowedTime = default;
        } 
        
    }
}
