using BookWorm.DTO;
using System.Collections.Generic;


namespace BookWorm.DataAccess
{
    public class BookLibrary
    {
        public int  Id { get; set; }
        public string Title { get; set; }

        public List<PersonDto> Author { get; set; }

        public string Url { get; set; }

        public BookLibrary(int id, string title, List<PersonDto> author, string url)
        {
            this.Id = id;
            this.Title = title;
            this.Author = author;
            this.Url = url;
        }
        public BookLibrary()
        {
            this.Id = 0;
            this.Title = null;
            this.Author = null;
            this.Url = null;
        }
    }
}
