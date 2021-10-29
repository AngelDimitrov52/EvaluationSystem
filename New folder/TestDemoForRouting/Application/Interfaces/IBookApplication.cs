using Application.ModelDTOs;
using System.Collections.Generic;

namespace Application
{
    public interface IBookApplication
    {
        BookDto AddBookToData(BookDto model);
        BookDto DeleteBook(int id);
        List<BookDto> ReturnAllBooks();
        BookDto ReturnBookWithId(int Id);
        BookDto UpdateBook(BookDto model);
    }
}