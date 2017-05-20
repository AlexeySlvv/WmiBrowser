using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WmiBrowser
{
    public partial class CustomListView : ListView
    {

        public CustomListView()
        {
            InitializeComponent();
        }

        // Disable blinking
        protected override CreateParams CreateParams
        {   // http://www.cyberforum.ru/post8161293.html
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;   // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

    }
}
