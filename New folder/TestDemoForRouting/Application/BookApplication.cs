using Application.ModelDTOs;
using Application.Validators;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Application
{
    public class BookApplication : IBookApplication
    {
        private IData bookData;
        private IMapper _mapper;
        private List<Book> listOfBooks;

        public BookApplication(IMapper map , IData bookdata)
        {
            _mapper = map;
            bookData = bookdata;
            listOfBooks = bookData.AllBooks();

        }

        public List<BookDto> ReturnAllBooks()
        {
            var mappedDto = _mapper.Map<List<BookDto>>(listOfBooks);
            return mappedDto;
        }

        public BookDto ReturnBookWithId(int Id)
        {
            Book book = listOfBooks.FirstOrDefault(x => x.Id == Id);
            var mappedDto = _mapper.Map<BookDto>(book);
            return mappedDto;
        }
        public BookDto AddBookToData(BookDto model)
        {
            Book bookEntity = _mapper.Map<Book>(model);
            listOfBooks.Add(bookEntity);

            Book book = ReturnWithId(model.IdDto);

            BookDto bookDto = _mapper.Map<BookDto>(book);
            return bookDto;
        }
        public BookDto DeleteBook(int id)
        {
            Book book = ReturnWithId(id);
            listOfBooks.Remove(book);

            BookDto bookDto = _mapper.Map<BookDto>(book);
            return bookDto;
        }
        public BookDto UpdateBook(BookDto model)
        {
            Book bookEntity = _mapper.Map<Book>(model);
            bookData.Update(bookEntity);

            Book newBook = ReturnWithId(model.IdDto);
            BookDto bookDto = _mapper.Map<BookDto>(newBook);

            return bookDto;
        }

        private Book ReturnWithId(int Id)
        {
            Book book = bookData.AllBooks().FirstOrDefault(x => x.Id == Id);
            return book;
        }
    }
}
