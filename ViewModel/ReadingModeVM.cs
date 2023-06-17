
namespace BookWorm.ViewModel
{
    public class ReadingModeVM : BaseVM, IReadingModeVM
    {
        private static string _bookText;
        private static string _nightModeReading;
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
