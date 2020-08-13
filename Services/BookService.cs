using BookApp.API.Entities;
using BookApp.DAL;
using BookAppStoreAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.BLL
{
    public class BookService
    {
        IBook bookDAL;

        public BookService(IBook BookDAL)
        {
            this.bookDAL = BookDAL;
        }

        public bool AddBook(Book book)
        {
            bool status = false;

            try
            {
                status = bookDAL.AddBook(book);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return status;
        }

        public List<Book> GetBookByCategory(int categoryid)
        {
            try
            {
                return bookDAL.GetBookByCategory(categoryid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateBook(Book book)
        {
            bool status = false;

            try
            {
                status = bookDAL.UpdateBook(book);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return status;
        }

        public Book GetBook(int BookId)
        {
            try
            {
                return bookDAL.GetBook(BookId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BookCategory> GetCategories()
        {
            try
            {
                return bookDAL.GetCategories();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
