using System.Windows.Input;

namespace BookWorm.ViewModel
{
    public interface IValidatioinEmailVM :IBaseVM
    {
        string Code { get; set; }
        string Email { get; set; }
        bool IsFieldVisible { get; set; }
        string Message { get; set; }
        ICommand ValidationCommand { get; set; }
    }
}