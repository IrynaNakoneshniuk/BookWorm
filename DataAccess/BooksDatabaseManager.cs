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
                    if (!ValidateBook(book))
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


        //додати видалення з пов*язаних таблиць
        public async Task DeleteBookById(int id)
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
                        db.FavoriteBooks.Add(new FavoriteBooks(book.IdUser, book.Id));
                        await db.SaveChangesAsync();
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
                        db.RecommendedBook.Add(new RecommendedBook(book.IdUser, book.Id));
                        await db.SaveChangesAsync();
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
                        db.ReadingBooks.Add(new ReadingBooks(book.IdUser, book.Id));
                        await db.SaveChangesAsync();
                    }
                    catch (SqlException exc)
                    {
                        MessageBox.Show(exc.Message);
                    }
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
