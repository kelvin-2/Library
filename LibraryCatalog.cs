using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Security.Principal;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;
using static System.Console;

namespace Library
{
    internal class LibraryCatalog
    {
        ArrayList BookList;
        int sortedState = 0;

        public LibraryCatalog()
        {
            BookList = new ArrayList();
        }
        public void ReadData()
        {
            StreamReader sr = new StreamReader("BookData.txt");
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] fildes = line.Split(',');
                int isbn = int.Parse(fildes[0].Trim());
                String title = fildes[1].Trim();
                String author = fildes[2].Trim();
                int publicationYear = int.Parse(fildes[3].Trim());

                Book book = new Book(isbn, title, author, publicationYear);
                BookList.Add(book);
            }
            sr.Close();
        }
        public void Add(Book book)
        {
            BookList.Add(book);
            sortedState = 0;
        }
        public void Delete(int wanted)
        {
            //using the binary search to find the book
            int pos = Find(wanted);
            BookList.RemoveAt(pos);
        }
        private void swap(int x, int y)
        {
            object temp = BookList[x];
            BookList[x] = BookList[y];
            BookList[y] = temp;
        }
        /// <summary>
        /// check this out why it was not running 
        /// </summary>
        private void bubleSort()
        {
            for (int index = 0; index < BookList.Count-1; index++)
            {
                for (int i = 0; i < BookList.Count-1; i++)
                {
                    //casting 
                    Book book1 = (Book)BookList[i];
                    Book book2 = (Book)BookList[i+1];
                    //the algorithim
                    if (book1.getISBN() > book2.getISBN())
                    {
                        swap(i , i+1);
                    }
                }
            }
           
        }
        
        private void SelectionSort()
        {
            int Minindex = 0;
            for (int index = 1; index < BookList.Count; index++)
            {
                for (int x = index; x < BookList.Count; x++)
                {
                    //sorting by the author
                    Book author1 = (Book)BookList[x];
                    Book author2 = (Book)BookList[Minindex];

                    if (author1.getAuthor().CompareTo(author2.getAuthor())<0)
                    
                        Minindex = x;
                }
                swap( index - 1,Minindex);
            }
           
        }
        private void InsertionSorted()
        {
            //change the way this is working 
            for (int pass = 1; pass < BookList.Count; pass++)
            {
                Book key = (Book)BookList[pass];
                int curPos= pass - 1;
                Book currentOne= (Book)BookList[curPos];
                while ((curPos!=-1)&&(key.getPublicationYear()<currentOne.getPublicationYear()))
                {
                    curPos--;
                    if(curPos!=-1)
                    
                        currentOne = (Book)BookList[curPos];
                    
                }
                BookList.RemoveAt(pass);
                BookList.Insert(curPos+ 1, key);
            }
        }
        private  int BinarySearch(int key)
        {
            int stop = BookList.Count;
            int start = 0;
            
            while(start <=stop)
            {
                int middle = (stop + start) / 2;
                Book book = (Book)BookList[middle];
                if (book.getISBN() == key)
                {
                    return middle;
                }
                else if (book.getISBN()<key)
                {
                    stop = middle - 1;
                }
                else
                    stop = middle + 1;
            }
            return -1;
        }
        private int LinearSearch(int wanted)
        {
            //searching using book title
            for(int i=0;i<BookList.Count;i++)
            {
                Book book = (Book)BookList[i];
                if(book.getISBN().Equals(wanted))
                {
                    return i;
                }
            }
            return -1;
        }
        public int Find(int wanted)
        {
            if (sortedState == 1 || sortedState == 3)
            {
                return BinarySearch(wanted);
            }
            else
                return LinearSearch(wanted);
        }

        public void DisplayBooks()
        {
            for (int i = 0; i < BookList.Count; i++)
            {
                Book book = (Book)BookList[i];
                book.DisplayBook();
            }
        }
        public void DisplayBook(int wanted)
        {
            int pos = LinearSearch(wanted);
            Book book = (Book)BookList[pos];
            book.DisplayBook();
        }
        public void INSBSort()
        {
            bubleSort();
            DisplayBooks();
            sortedState = 1;
        }
        public void AuthorSort()
        {
            SelectionSort();
            DisplayBooks();
            sortedState = 2;
        }
        public void PublishedYear()
        {
            InsertionSorted();
            DisplayBooks();
            sortedState = 3;
        }
        public void WriteData()
        {
            StreamWriter wr = new StreamWriter("Output.txt");
            for(int i = 0;i < BookList.Count;i++)
            {
                Book book = (Book)BookList[i];  
                WriteLine(book.getISBN()+","+book.getTitle()+","+book.getAuthor()+","+book.getPublicationYear());
            }
            wr.Close();
        }
    }
}
