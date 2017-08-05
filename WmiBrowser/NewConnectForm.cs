using System;
using System.Management;
using System.Windows.Forms;

namespace WmiBrowser
{
    public partial class NewConnectForm : Form
    {

        public NewConnectForm()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (Check())
                DialogResult = DialogResult.OK;
            else
                DialogResult = DialogResult.None;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            if (Check())
                MessageBox.Show(@"Success");
            else
                MessageBox.Show(@"Failed to connect");
        }

        private bool Check()
        {
            var opts = new ConnectionOptions
            {
                Username = textBoxUsername.Text,
                Password = textBoxPassword.Text,
            };
            string path = $@"\\{textBoxHostname.Text}\root\cimv2";
            var scope = new ManagementScope(path, opts);
            scope.Connect();
            return scope.IsConnected;
        }
    }
}
