
namespace BookWorm.Api
{
    public static class EndPointApi
    {
        public static string GetBaseUrlGuenbergApi() => "https://gutendex.com/";
        public static string GetTextBooksUrl(string bookId) => $"https://www.gutenberg.org/ebooks/{bookId}.txt.utf-8";
        public static string ListOfBook() => "books?page=1&sort=ascending";
        public static string FilterByLanguages(string languages) => $"/books?page=1&languages={languages}";
        public static string FilterByAuthorAndTitle(string author,string title) => $"/books?search={author}20great{title}";
        public static  string FilterByAuthorOrTitle(string authorOrTitle) => $"/books?search={authorOrTitle}";
        public static string FilterByTopic(string topic) => $"/books?topic={topic}";
        public static string FilterById(string bookId) => $"/books/{bookId}";
    }
}
