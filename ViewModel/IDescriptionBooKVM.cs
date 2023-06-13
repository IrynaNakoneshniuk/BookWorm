using BookWorm.DataAccess;

namespace BookWorm.ViewModel
{
    public interface IDescriptionBooKVM: IBaseVM
    {
        string DescriptionOfBook { get; set; }
        public BookLibrary SelectedBook { get; set; }
    }
}