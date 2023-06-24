
using System.Windows.Input;

namespace BookWorm.ViewModel
{
    public interface IReadingModeVM : IBaseVM
    {
        string BookText { get; set; }
        string NightModeReading { get; set; }
        ICommand TranslateWordCommand { get; set; }
        string FromLanguage { get; set; }
        string Translate { get; set; }
        string ToLanguage { get; set; }

    }
}