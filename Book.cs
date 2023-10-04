using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class Book
    {
        int isbn;
        String title;
        String author;
        int publicationYear;

        public Book(int isbn, String title, String author, int publicationYear) 
        { 
            this.isbn = isbn;
            this.title = title;
            this.author = author;
            this.publicationYear = publicationYear;
        }
        public int getISBN()
        {
            return isbn;
        }
        public string getTitle()
        {
            return title;
        }
        public String getAuthor()
        {
            return author;
        }
        public int getPublicationYear()
        {
            return publicationYear;
        }
        public void DisplayBook()
        {
            Console.WriteLine("{0} ,{1} ,{2} ,{3}",isbn,title,author,publicationYear);
        }
    }
}
