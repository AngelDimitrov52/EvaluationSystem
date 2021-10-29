using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Book
    {
        public Book()
        {

        }
        public Book(int id, string title, int date, string author)
        {
            Id = id;
            Title = title;
            Date = date;
            AuthorName = author;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int Date { get; set; }
        public string AuthorName { get; set; }
        public string Email { get; set; }
    }
}
