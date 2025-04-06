using System.Windows.Forms;

namespace csharp_lksmart.Forms.Admin
{
    public class MessageBoxHelper
    {
        public static void ShowWarning(string message)
        {
            MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowInformation(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowQuestion(string message)
        {
            MessageBox.Show(message, "Question", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
    }
}