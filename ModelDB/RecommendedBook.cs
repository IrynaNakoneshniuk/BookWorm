

namespace BookWorm.ModelDB
{
    public class RecommendedBook
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? BookId { get; set; }

        public RecommendedBook(int? userId, int? bookId)
        {
            UserId = userId;
            BookId = bookId;
        }
    }
}
