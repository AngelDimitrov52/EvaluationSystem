using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionDemo
{
   public class BookUser
    {
        public void ReadBook (Book book)
        {
            Console.WriteLine($"Read book: {book.Text}");
        }
    }
}
