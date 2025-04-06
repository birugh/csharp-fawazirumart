using System.Windows.Forms;

namespace csharp_lksmart.Forms.Admin
{
    public class SnackBarHelper
    {
        private static Bunifu.UI.WinForms.BunifuSnackbar snackBar;
        public static void ShowSuccessInformation(Form currentForm, string message)
        {
            snackBar.Show(currentForm, message,
            Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success,
            3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomLeft);
        }
    }
}
