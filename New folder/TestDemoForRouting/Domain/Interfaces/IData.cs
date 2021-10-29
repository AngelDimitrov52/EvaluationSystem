using System.Collections.Generic;

namespace Domain
{
    public interface IData
    {
        void Add(Book book);
        List<Book> AllBooks();
        void Update(Book book);
    }
}