using BookWorm.ModelDB;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BookWorm.DataAccess
{
    public class UserAccountManager
    {
        public async Task RegistrationUserAsync(Users? user)
        {
            using (var db = new MyDbContext())
            {
                try
                {
                    await db.Users.AddAsync(user);
                    await db.SaveChangesAsync();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        public async Task<Users> SigInUserAsync(string? email)
        {
            using (var db = new MyDbContext())
            {
                try
                {
                    return await db.Users.Where(i => i.Email.Equals(email)).FirstOrDefaultAsync();
                }
                catch(SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return null;
            }
        }


        public async Task ChangePassword(string? email, string? password)
        {
            using (var db = new MyDbContext())
            {
                try
                {
                    Users User = await db.Users.Where(i => i.Email.Equals(email)).FirstOrDefaultAsync();
                    if (User != null)
                    {
                        User.Password = password;
                        db.Entry(User).State = EntityState.Modified;
                        await db.SaveChangesAsync();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        public async Task<bool> IsEmailExist(string ? email)
        {
            using (var db = new MyDbContext()){
                try
                {
                    return await db.Users.AnyAsync(i=>i.Email.Equals(email));
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return false;
            }
        }
    }
}
