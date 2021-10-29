using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionDemo
{
   public static class BookExtension
    {

        public static void FullInfoOfBook(this Book book)
        {
            Console.WriteLine($"Id:{book.Id} Title:{book.Title} Text:{book.Text}");
        }

        public static void WhileBook( this BookUser book , Book bookToUse)
        {
            Console.WriteLine($"Whrite a book : {bookToUse.Text}"); 
        } 
        public static void WhileBook( this BookUser book , int one)
        {
            Console.WriteLine($"Count ot books is {one}"); 
        }

    }
}
