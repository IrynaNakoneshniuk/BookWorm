

namespace BookWorm.ModelDB
{
    public class FavoriteBooks
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? BookId { get; set; }

        public FavoriteBooks(int? userId, int? bookId)
        {
            UserId = userId;
            BookId = bookId;
        }
    }

}
