using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionDemo
{
    public class Book
    {
        public Book(int id , string title, string text)
        {
            Id = id;
            Title = title;
            Text = text;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
