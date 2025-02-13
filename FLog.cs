using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharp_lksmart
{
    public partial class FLog : Form
    {
        private static string connString = ConfigurationManager.AppSettings["connString"].ToString();
        public FLog()
        {
            InitializeComponent();
        }

        private void btnKelolaUser_Click(object sender, EventArgs e)
        {

        }

        private void btnKelolaLaporan_Click(object sender, EventArgs e)
        {

        }

        private void btnLog_Click(object sender, EventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {

        }
    }
}
