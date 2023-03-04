
namespace BookWorm.Api
{
    public static class EndPointApi
    {
        public static string GetBaseUrlGuenbergApi() => "https://gutendex.com/";
        public static string GetTextBooksUrl(string bookId) => $"https://www.gutenberg.org/files/{bookId}/{bookId}-0.txt";
        public static string ListOfBook() => "books?page=1&sort=ascending";
        public static string FilterByLanguages(string languages) => $"/books?page=1&languages={languages}";
        public static string FilterByAuthorAndTitle(string author,string title) => $"/books?search={author}20great{title}";
        public static  string FilterByAuthorOrTitle(string authorOrTitle) => $"/books?search={authorOrTitle}";
        public static string FilterByTopic(string topic) => $"/books?topic={topic}";
        public static string FilterById(string bookId) => $"/books/{bookId}";
        public static string TranslatorEndPoint(string from, string to) => $"https://api-eur.cognitive.microsofttranslator.com/translate?api-version=3.0&from={from}&to={to}";
    }
}
