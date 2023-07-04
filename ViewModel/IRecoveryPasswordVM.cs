using System.Windows.Input;

namespace BookWorm.ViewModel
{
    public interface IRecoveryPasswordVM
    {
        string Email { get; set; }
        string ErrorMessage { get; set; }
        bool IsCodeFieldEnable { get; set; }
        bool IsPasswordFieldEnable { get; set; }
        string Password { get; set; }
        int? RecoveryCode { get; set; }
        ICommand RecoveryPasswordCommand { get; set; }
        string Repassword { get; set; }
    }
}