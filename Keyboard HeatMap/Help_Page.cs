using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Keyboard_HeatMap
{
    public partial class Help_Page : UserControl
    {
        public Help_Page()
        {
            InitializeComponent();
        }

        private void GoBack(object sender, EventArgs e)
        {
            this.Visible = false;
            this.SendToBack();
        }

        private void OpenInstagramPage(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.instagram.com/iambucuriee") { UseShellExecute = true });
        }
    }
}
