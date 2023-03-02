using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWorm.ModelDB
{
    public class Books
    {
        public int? Id { get; set; }
        public string? Identificator { get; set; }
        public string? Author { get; set; }
        public string? UrlImage { get; set; }
        public string? Title { get; set; }
        public string? Comment { get; set; }
        public int? IdUser { get; set; }

        public Books(string? identificator, string? author, string? urlImage, string? title, string? comment, int? idUser)
        {
            Identificator = identificator;
            Author = author;
            UrlImage = urlImage;
            Title = title;
            Comment = comment;
            IdUser = idUser;
        }
    }
}
