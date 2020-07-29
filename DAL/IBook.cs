using BookApp.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.DAL
{
    public interface IBook
    {
        bool AddBook(Book book);
        List<Book> GetBookByCategory(int categoryid);
        Book GetBook(int BookId);
        bool UpdateBook(Book book);
    }
}
