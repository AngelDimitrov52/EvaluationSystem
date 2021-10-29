using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data
{
    public class OneMoreData : IData
    {

        private List<Book> books = new List<Book>()
        {
            new Book(11 , "Title11" , 20011 ,"Author11"),
            new Book(22 , "Title22" , 20022 ,"Author22"),
            new Book(33 , "Title33" , 20033 ,"Author33"),
            new Book(44 , "Title44" , 20044 ,"Author44"),
            new Book(55 , "Title55" , 20055 ,"Author55"),
            new Book(66 , "Title66" , 20066 ,"Author66")
        };
        public List<Book> AllBooks() => books;

        public void Add(Book book)
        {
            books.Add(book);
        }
        public void Update(Book book)
        {
            books[book.Id - 1] = book;
        }
       
    }
}
