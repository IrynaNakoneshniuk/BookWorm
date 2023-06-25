using BookWorm.ModelDB;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;


namespace BookWorm.DataAccess
{
    public class BooksDatabaseManager
    {
        public async Task<bool> AddBookAsync(Books book)
        {
            using (var db = new MyDbContext())
            {
                try
                {
                    var selectedBook = await (from item in db.Books
                                       where item.Identificator == book.Identificator
                                       select item).FirstOrDefaultAsync();
                    if (!ValidateBook(book)|| selectedBook!=null)
                    {
                        return false;
                    }

                    db.Books.Add(book);
                    await db.SaveChangesAsync();

                    return true;
                }
                catch(SqlException exc)
                {
                   MessageBox.Show(exc.Message);
                }
                catch(Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
               return false;
            }
        }


        public async Task<Books> GetBookById(int id)
        {
            using (var db = new MyDbContext())
            {
                try
                {
                    return await db.Books.FirstOrDefaultAsync(b => b.Id == id);
                }
                catch(SqlException exc)
                {
                    MessageBox.Show(exc.Message);
                }
                return null;
            }
        }


        public async Task<List<Books>> GetListBooksByIdUser(int idUser)
        {
            List<Books> booksList = new List<Books>();
             await Task.Run(() =>
              {
                  using (var db = new MyDbContext())
                  {
                      try
                      {
                          var listDB = from book in db.Books
                                                         where book.IdUser == idUser
                                                         select book;
                          foreach(var book in listDB)
                          {
                              booksList.Add(book);
                          }
                      }
                      catch (SqlException exc)
                      {
                          MessageBox.Show(exc.Message);
                          
                      }
                  }
            });
            return booksList;
        }


        public async Task<List<FavoriteBooks>> GetFavoriteBooksByIdUser(int idUser)
        {
            List<FavoriteBooks>booksList = new List<FavoriteBooks>();

            await Task.Run(() =>
            {
                using (var db = new MyDbContext())
                {
                    try
                    {
                        var listDB = from book in db.FavoriteBooks
                                     where book.UserId == idUser
                                     select book;
                        foreach (var book in listDB)
                        {
                            booksList.Add(book);
                        }
                    }
                    catch (SqlException exc)
                    {
                        MessageBox.Show(exc.Message);

                    }
                }
            });

            return booksList;
        }


        public async Task<List<ReadingBooks>> GetReadingBooksByIdUser(int idUser)
        {
            List< ReadingBooks> booksList = new List<ReadingBooks>();

            await Task.Run(() =>
            {
                using (var db = new MyDbContext())
                {
                    try
                    {
                        var listDB = from book in db.ReadingBooks
                                     where book.UserId == idUser
                                     select book;
                        foreach (var book in listDB)
                        {
                            booksList.Add(book);
                        }
                    }
                    catch (SqlException exc)
                    {
                        MessageBox.Show(exc.Message);

                    }
                }
            });
            return booksList;
        }


        public async Task DeleteBookById(int? id)
        {
            using (var db = new MyDbContext())
            {
                try
                {
                    var bookToDelete = await db.Books.FirstOrDefaultAsync(b => b.Id == id);
                    if (bookToDelete != null)
                    {
                        db.Books.Remove(bookToDelete);
                        await db.SaveChangesAsync();
                    }
                }
                catch (SqlException exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }


        public async Task AddFavouriteBook(Books book)
        {
            if (ValidateBook(book))
            {
                using (var db = new MyDbContext())
                {
                    try
                    {
                        var bookForreading = new FavoriteBooks(book.IdUser, book.Id);

                        var selectedBook = (from selectBook in db.FavoriteBooks
                                            where selectBook.BookId == book.Id
                                            select selectBook).FirstOrDefault();
                        if (selectedBook == null)
                        {
                            db.FavoriteBooks.Add(bookForreading);
                            await db.SaveChangesAsync();
                            MessageBox.Show("Книгу додано до списку!");
                        }
                        else
                        {
                            MessageBox.Show("Обрана книга наявна списку!");
                        }
                    }
                    catch (SqlException exc)
                    {
                        MessageBox.Show(exc.Message);
                    }
                }
            }
        }


        public async Task AddRecommendedBook(Books book)
        {
            if (ValidateBook(book))
            {
                using (var db = new MyDbContext())
                {
                    try
                    {
                        var bookForreading = new RecommendedBook(book.IdUser, book.Id);

                        var selectedBook = (from selectBook in db.RecommendedBook
                                            where selectBook.BookId == book.Id
                                            select selectBook).FirstOrDefault();
                        if (selectedBook == null)
                        {
                            db.RecommendedBook.Add(bookForreading);
                            await db.SaveChangesAsync();
                            MessageBox.Show("Книгу додано до списку!");
                        }
                        else
                        {
                            MessageBox.Show("Обрана книга наявна списку!");
                        }
                    }
                    catch (SqlException exc)
                    {
                        MessageBox.Show(exc.Message);
                    }
                }
            }
        }


        public async Task AddReadingBook(Books book)
        {
            if (ValidateBook(book))
            {
                using (var db = new MyDbContext())
                {
                    try
                    {
                        var bookForreading = new ReadingBooks(book.IdUser, book.Id);

                        var selectedBook = (from selectBook in db.ReadingBooks
                                           where selectBook.BookId== book.Id
                                            select selectBook).FirstOrDefault();
                        if (selectedBook==null)
                        {
                            db.ReadingBooks.Add(bookForreading);
                            await db.SaveChangesAsync();
                            MessageBox.Show("Книгу додано до списку!");
                        }
                        else{
                            MessageBox.Show("Обрана книга наявна списку!");
                        }
                    }
                    catch (SqlException exc)
                    {
                        MessageBox.Show(exc.Message);
                    }
                }
            }
        }


        public async Task DeleteBookFromFavorite(int bookId)
        {
            using (var db = new MyDbContext())
            {
                try
                {
                    var bookRemove = db.FavoriteBooks.FirstOrDefault(book => book.BookId == bookId);
                    if (bookRemove != null)
                        db.FavoriteBooks.Remove(bookRemove);
                    await db.SaveChangesAsync();
                }
                catch (SqlException exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }


        public async Task EditCommentByBookId(int bookId, string comment)
        {
            using (var db = new MyDbContext())
            {
                try
                {
                    var book = db.Books.FirstOrDefault(book => book.Id == bookId);
                    
                    if (book != null)
                    {
                        book.Comment = comment;

                        db.Books.Entry(book).State =EntityState.Modified;
                    }
                    await db.SaveChangesAsync();
                }
                catch (SqlException exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }


        public async Task DeleteBookFromReading(int bookId)
        {
            using (var db = new MyDbContext())
            {
                try
                {
                    var bookRemove = db.ReadingBooks.FirstOrDefault(book => book.BookId == bookId);
                    if (bookRemove != null)
                        db.ReadingBooks.Remove(bookRemove);
                    await db.SaveChangesAsync();
                }
                catch (SqlException exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }


        private bool ValidateBook(Books book)
        {
            if (string.IsNullOrWhiteSpace(book.Identificator) ||
                string.IsNullOrWhiteSpace(book.Author) ||
                string.IsNullOrWhiteSpace(book.UrlImage) ||
                string.IsNullOrWhiteSpace(book.Title) ||
                book.IdUser <= 0)
            {
                return false;
            }

            return true;
        }
    }
}
