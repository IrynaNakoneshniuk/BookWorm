using BookWorm.ModelDB;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
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
