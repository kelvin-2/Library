using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LibraryCatalog catalogue = new LibraryCatalog();
            catalogue.ReadData();
            DisplayOptions();
            int choice = int.Parse(ReadLine());
            ProcessOption(catalogue, choice);
            while (choice != 8)
            {
                DisplayOptions();
                choice = int.Parse(ReadLine());
                ProcessOption(catalogue, choice);
            }
            ReadLine();
        }

        static void DisplayOptions()
        {
            WriteLine("Choose one of the following options: ");
            WriteLine("1. Add a new book");
            WriteLine("2. Delete a book");
            WriteLine("3. Display book details");
            WriteLine("4. List all books");
            WriteLine("5. Sort catalogue in ascending order of ISBN number, then display list");
            WriteLine("6. Sort catalogue in ascending order of Author then display list");
            WriteLine("7. Sort catalogue in ascending order of publication year, then display list");
            WriteLine("8. Save data and quit");
            Write("Choice: ");
        }

        static void ProcessOption(LibraryCatalog catalogue, int choice)
        {
            WriteLine();

            switch (choice)
            {
                case 1:
                    AddBook(catalogue);
                    WriteLine();
                    break;
                case 2:
                    DeleteBook(catalogue);
                    WriteLine();
                    break;
                case 3:
                    DisplayBookDetail(catalogue);
                    WriteLine();
                    break;
                case 4:
                    catalogue.DisplayBooks();
                    WriteLine();
                    break;
                case 5:
                    catalogue.INSBSort();
                    WriteLine();
                    break;
                case 6:
                    catalogue.AuthorSort();
                    WriteLine();
                    break;
                case 7:
                    catalogue.PublishedYear();
                    WriteLine();
                    break;
                default:
                    catalogue.WriteData();
                    WriteLine("Goodbye, the data will now be written to the text file");
                    break;
            }
        }
        static void AddBook(LibraryCatalog catalogue)
        {
            Write("Enter ISBN number: ");
            int isbn = int.Parse(ReadLine());
            Write("Enter Book Titile: ");
            string title=ReadLine();
            Write("Enter Author: ");
            string author = ReadLine();
            Write("Enter year published: ");
            int year=int.Parse(ReadLine());

            Book book=new Book(isbn, title, author,year);
            catalogue.Add(book);
        }

        static void DeleteBook(LibraryCatalog catalogue)
        {
            Write("Enter the ISBN number: ");
            int isbn = int.Parse(ReadLine());
            int pos = catalogue.Find(isbn);
            if(pos == -1)
            {
                Write("Not Found!");
            }
            else
            {
                catalogue.Delete(isbn);
                WriteLine("Book deleted.");
            }
           
        }
        static void DisplayBookDetail(LibraryCatalog catalogue)
        {
            Write("Enter the ISBN number ");
            int isbn = int.Parse(ReadLine());
            int pos =catalogue.Find(isbn);
            if(pos == -1)
            {
                WriteLine("not found!");
            }
            else
            {
                catalogue.DisplayBook(isbn);
            }
         
        }
    }
}
