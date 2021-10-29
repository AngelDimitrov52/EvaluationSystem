
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BookData : IData
    {
        private List<Book> books = new List<Book>()
        {
            new Book(1 , "Title1" , 2001 ,"Author1"),
            new Book(2 , "Title2" , 2002 ,"Author2"),
            new Book(3 , "Title3" , 2003 ,"Author3"),
            new Book(4 , "Title4" , 2004 ,"Author4"),
            new Book(5 , "Title5" , 2005 ,"Author5"),
            new Book(6 , "Title6" , 2006 ,"Author6")
        };
        public List<Book> AllBooks() => books;

        public void Add(Book book)
        {
            books.Add(book);
        }
        public void Update(Book book)
        {
           
            int index = books.FindIndex(a => a.Id == book.Id);
            books[index] = book;
        }
    }
}
