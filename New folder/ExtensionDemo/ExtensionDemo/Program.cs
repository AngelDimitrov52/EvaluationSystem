using System;

namespace ExtensionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book(1, "AngelTitle","Book text");
            BookUser bookUser = new BookUser();

            book.FullInfoOfBook();

            bookUser.ReadBook(book);

            bookUser.WhileBook(book);

            bookUser.WhileBook(4);

        }
    }
}
