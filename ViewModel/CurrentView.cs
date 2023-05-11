using BookWorm.DataAccess;
using BookWorm.DTO;
using BookWorm.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWorm.ViewModel
{
    public static  class CurrentView
    {
        public static Users UsersCurrent { get; set; } = new Users(null,null,null,null);
        public static List<BookLibrary> Bookslibrary { get; set; } = new List<BookLibrary>();
        public static string Email { get; set; }
    }
}
