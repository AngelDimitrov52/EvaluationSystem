using Application;
using Application.ModelDTOs;
using Application.Validators;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace test.API.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBookApplication _bookApp;
    
        public BooksController(IBookApplication bookapp)
        {
            _bookApp = bookapp;
        }


        [HttpGet]
        public List<BookDto> GetAll()
        {
            return _bookApp.ReturnAllBooks();
        }



        [HttpGet("/PlusOne")]
        public List<BookDto> GetAllPlusOne()
        {
            var books = _bookApp.ReturnAllBooks(); 

            foreach (var book in books)
            {
                book.TitleDto += " Plus One";
            }
            return books;

        }


        [HttpGet("{id}")]
        public ActionResult<BookDto> GetAllById(int id)
        {
            BookDto book = _bookApp.ReturnBookWithId(id);

            if (book == null)
            {
                return NotFound();
            }
            return book;
        }


        [HttpPost]
        public BookDto Post([FromBody] BookDto model)
        {
            //BookDtoValidator validator = new BookDtoValidator();
            //var result = validator.Validate(model);

            //if (result.IsValid == false)
            //{
            //    return model;
            //}
            var postResult = _bookApp.AddBookToData(model);

            return postResult;
        }


        [HttpDelete]
        public int Delete(int id)
        {
            BookDto bookDto = _bookApp.DeleteBook(id);
            return bookDto.IdDto;
        }


        [HttpPut]
        public BookDto Uptate(BookDto model)
        {
            BookDto book = _bookApp.UpdateBook(model);
            return book;
        }

    }
}
