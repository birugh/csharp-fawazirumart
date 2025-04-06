using Bunifu.UI.WinForms;
using System;
using System.Windows.Forms;

namespace csharp_lksmart.Forms.Admin
{
    public class TimerHelper
    {
        private static Timer timer;

        public static void InitializeTimer(EventHandler eventHandler)
        {
            timer = new Timer
            {
                Interval = 1000
            };

            timer.Tick += new EventHandler(eventHandler);
            timer.Start();
        }

        public static void InitializeDateTime(BunifuLabel labelDate, BunifuLabel labelTime)
        {
            labelDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            labelTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}