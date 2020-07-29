﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApp.API.Entities;
using BookApp.BLL;
using BookApp.DAL;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private BookService BookObj = new BookService(new BookContext());

        //[HttpGet]
        //public ActionResult<List<Book>> GetBooks()
        //{
        //    return BookObj.GetBookByCategory();
        //}

        [HttpPost]
        public ActionResult<Book> AddBook(Book book)
        {
            BookObj.AddBook(book);

            return Ok();
        }

        [HttpGet("category/{categoryId}")]
        public ActionResult<List<Book>> GetBooksByCategoryId(int categoryId)
        {
            return BookObj.GetBookByCategory(categoryId);
        }

        [HttpPut]
        public ActionResult<Book> UpdateBook(Book book)
        {
            BookObj.UpdateBook(book);

            return Ok();
        }

        [HttpGet("{bookId}")]
        public ActionResult<Book> GetBookByBookId(int bookId)
        {
            return BookObj.GetBook(bookId);
        }

    }
}