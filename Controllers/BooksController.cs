using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApp.API.Entities;
using BookApp.BLL;
using BookApp.DAL;
using BookAppStoreAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private BookService bookService = new BookService(new BookContext());

        [HttpPost]
        public ActionResult<Book> AddBook(Book book)
        {
            bookService.AddBook(book);

            return Ok();
        }

        [HttpGet("category/{categoryId}")]
        public ActionResult<List<Book>> GetBooksByCategoryId(int categoryId)
        {
            return bookService.GetBookByCategory(categoryId);
        }

        [HttpPut]
        public ActionResult<Book> UpdateBook(Book book)
        {
            bookService.UpdateBook(book);

            return Ok();
        }

        [HttpGet("{bookId}")]
        public ActionResult<Book> GetBookByBookId(int bookId)
        {
            return bookService.GetBook(bookId);
        }

        [HttpGet("categories")]
        public ActionResult<List<BookCategory>> GetCategories()
        {
            return bookService.GetCategories();
        }
    }
}