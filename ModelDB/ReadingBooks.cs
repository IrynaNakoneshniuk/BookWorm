

namespace BookWorm.ModelDB
{
    public class ReadingBooks
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? BookId { get; set; }

        public ReadingBooks(int? userId, int? bookId)
        {
            UserId = userId;
            BookId = bookId;
        }
    }
}
