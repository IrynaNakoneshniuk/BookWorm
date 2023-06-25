using System.Windows.Input;

namespace BookWorm.ViewModel
{
    public class ReadingModeVM : BaseVM, IReadingModeVM
    {
        private static string ? _bookText;

        private static string ? _nightModeReading;

        private string ? _fromLanguage;

        private string ? _toLanguage;

        private string ? _translate;

        public string Translate
        {
            get { return _translate; }
            set { 
                _translate = value; 
                OnPropertyChanged(nameof(Translate));
            }
        }

        public string FromLanguage
        {
            get { return _fromLanguage; }
            set { 
                _fromLanguage = value; 
                OnPropertyChanged(nameof(FromLanguage));
            }
        }

        public string ToLanguage
        {
            get { return _toLanguage; }
            set
            {
                _toLanguage = value;
                OnPropertyChanged(nameof(ToLanguage));
            }
        }
        public ICommand TranslateWordCommand { get; set; }

        public string BookText
        {
            get
            {
                return _bookText;
            }

            set
            {
                _bookText = value;
                OnPropertyChanged(nameof(BookText));
            }
        }

        public string NightModeReading
        {
            get
            {
                return _nightModeReading;
            }

            set
            {
                _nightModeReading = value;
                OnPropertyChanged(nameof(NightModeReading));
            }
        }
    }
}
