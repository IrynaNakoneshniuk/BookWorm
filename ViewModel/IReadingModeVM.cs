
namespace BookWorm.ViewModel
{
    public interface IReadingModeVM:IBaseVM
    {
        string BookText { get; set; }
        string NightModeReading { get; set; }
    }
}