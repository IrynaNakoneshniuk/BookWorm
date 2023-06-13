using BookWorm.ModelDB;
using System.Windows.Input;

namespace BookWorm.ViewModel
{
    public interface IBase
    {
        IBase Base { get; set; }
        bool IsControlAVisible { get; set; }
        ILibrary Library { get; set; }
        IUserLoginVM LogginUser { get; set; }
        IRegistrationVM Registration { get; set; }
        IBaseVM SelectView { get; set; }
        ICommand SelectViewCommand { get; set; }
        Users User { get; set; }
        IValidatioinEmailVM ValidationVM { get; set; }
        IDescriptionBooKVM DescriptionBooKVm { get; set; }
    }
}