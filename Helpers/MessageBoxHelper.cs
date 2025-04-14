using System.Windows.Forms;

namespace csharp_lksmart.Forms.Admin
{
    public static class MessageBoxHelper
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

        private static DialogResult ShowQuestion(string message)
        {
            return MessageBox.Show(message, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static bool ComparisonMsgBox(string message)
        {
            if (ShowQuestion(message) == DialogResult.No)
            {
                return false;
            }
            return true;
        }
    }
}
