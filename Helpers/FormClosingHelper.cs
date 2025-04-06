using System;
using System.Windows.Forms;

namespace csharp_lksmart.Helpers
{
    internal class FormClosingHelper
    {
        public static void FormClosing(FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure to close?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Environment.Exit(1);
            }
            else
            {
                e.Cancel = true;
            }
        }

        public static void FormChanging<T>(Form currentForm) where T : Form, new()
        {
            T targetForm = new T();
            targetForm.Show();
            currentForm.Hide();
        }
    }
}