using BookApp.API.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.DAL
{
    public class BookContext : IBook
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader reader;

        public BookContext()
        {
            conn = new SqlConnection("data source=NIKITAT-MSD2\\SQLEXPRESS2014; initial catalog=BookAppDB; integrated security=true");
        }

        public bool AddBook(Book book)
        {
            bool status = false;
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "AddBook";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookId", book.BookId);
                cmd.Parameters.AddWithValue("@ImageUrl", book.ImageUrl);
                cmd.Parameters.AddWithValue("@Title", book.Title);
                cmd.Parameters.AddWithValue("@Author", book.Author);
                cmd.Parameters.AddWithValue("@CategoryId", book.CategoryId);
                cmd.Parameters.AddWithValue("@Publisher", book.Publisher);
                cmd.Parameters.AddWithValue("@NoOfPages", book.NoOfPages);
                cmd.Parameters.AddWithValue("@Ratings", book.Ratings);
                cmd.Parameters.AddWithValue("@Edition", book.Edition);
                cmd.Parameters.AddWithValue("@Price", book.Price);
                cmd.Parameters.AddWithValue("@ReleaseDate", book.ReleaseDate);

                conn.Open();

                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                    status = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return status;
        }

        //public List<Book> GetBooks()
        //{
        //    List<Book> list = null;

        //    try
        //    {
        //        cmd = conn.CreateCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "GetAllBooks";

        //        conn.Open();

        //        reader = cmd.ExecuteReader();

        //        if (reader.HasRows)
        //        {
        //            list = new List<Book>();
        //            while (reader.Read())
        //            {
        //                Book book = new Book
        //                {
        //                    BookId = reader.GetInt32(0),
        //                    ImageUrl = reader.GetString(1),
        //                    Title = reader.GetString(2),
        //                    Author = reader.GetString(3),
        //                    CategoryId = reader.GetInt32(4),
        //                    Publisher = reader.GetString(5),
        //                    NoOfPages = reader.GetInt32(6),
        //                    Ratings = reader.GetDecimal(7),
        //                    Edition = reader.GetString(8),
        //                    Price = reader.GetDecimal(9),
        //                    ReleaseDate = reader.GetDateTime(10) 
        //                };

        //                list.Add(book);
        //            }
        //        }
        //        else
        //        {
        //            throw new Exception("No Data found");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        reader.Close();
        //        conn.Close();
        //    }
        //    return list;
        //}

        public List<Book> GetBookByCategory(int categoryid)
        {
            List<Book> list = null;

            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                if (categoryid == 0)
                {
                    cmd.CommandText = "GetBookByCategoryId";
                }
                else {
                    if (categoryid == 1)
                    {
                        cmd.CommandText = "usp_GetBook_Programming";
                    }
                    else
                    {
                        cmd.CommandText = "usp_GetBook_Biography";
                    }
                }
                cmd.Parameters.AddWithValue("@CategoryId", categoryid);
                conn.Open();

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    list = new List<Book>();
                    while (reader.Read())
                    {
                        Book b1 = new Book
                        {
                            BookId = reader.GetInt32(0),
                            ImageUrl = reader.GetString(1),
                            Title = reader.GetString(2),
                            Author = reader.GetString(3),
                            CategoryId = reader.GetInt32(4),
                            Publisher = reader.GetString(5),
                            NoOfPages = reader.GetInt32(6),
                            Ratings = reader.GetDecimal(7),
                            Edition = reader.GetString(8),
                            Price = reader.GetDecimal(9),
                            ReleaseDate = reader.GetDateTime(10)
                        };

                        list.Add(b1);
                    }
                }
                else
                {
                    throw new Exception("No Data found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                reader.Close();
                conn.Close();
            }
            return list;
        }

        public Book GetBook(int BookId)
        {
            Book book = null;

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet ds = new DataSet();
                //SqlCommand command;
                //int i = 0;

                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetBookByBookId";
                cmd.Parameters.AddWithValue("@BookId", BookId);

                conn.Open();
                //command = new SqlCommand(cmd.CommandText, conn);
                //adapter.SelectCommand = cmd;
                //adapter.Fill(ds,"dbo.books");
                //adapter.Dispose();
                //cmd.Dispose();
                //conn.Close();

                //for(i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                //{

                //}


                    reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        book = new Book
                        {
                            BookId = reader.GetInt32(0),
                            ImageUrl = reader.GetString(1),
                            Title = reader.GetString(2),
                            Author = reader.GetString(3),
                            CategoryId = reader.GetInt32(4),
                            Publisher = reader.GetString(5),
                            NoOfPages = reader.GetInt32(6),
                            Ratings = reader.GetDecimal(7),
                            Edition = reader.GetString(8),
                            Price = reader.GetDecimal(9),
                            ReleaseDate = reader.GetDateTime(10)
                        };
                    }
                }
                else
                {
                    throw new Exception("No Data found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                reader.Close();
                conn.Close();
            }
            return book;
        }

        public bool UpdateBook(Book book)
        {
            bool status = false;
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "EditBook";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BookId", book.BookId);
                cmd.Parameters.AddWithValue("@ImageUrl", book.ImageUrl);
                cmd.Parameters.AddWithValue("@Title", book.Title);
                cmd.Parameters.AddWithValue("@Author", book.Author);
                cmd.Parameters.AddWithValue("@CategoryId", book.CategoryId);
                cmd.Parameters.AddWithValue("@Publisher", book.Publisher);
                cmd.Parameters.AddWithValue("@NoOfPages", book.NoOfPages);
                cmd.Parameters.AddWithValue("@Ratings", book.Ratings);
                cmd.Parameters.AddWithValue("@Edition", book.Edition);
                cmd.Parameters.AddWithValue("@Price", book.Price);
                cmd.Parameters.AddWithValue("@ReleaseDate", book.ReleaseDate);

                conn.Open();

                int count = cmd.ExecuteNonQuery();

                if (count > 0)
                    status = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return status;
        }
    }
}
