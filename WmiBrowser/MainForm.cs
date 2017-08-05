// CimType: https://msdn.microsoft.com/ru-ru/library/system.management.cimtype(v=vs.110).aspx
// Win32 Classes: https://msdn.microsoft.com/en-us/library/aa394084(v=vs.85).aspx

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WmiBrowser
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _scope = new ManagementScope(@"\\.\root\cimv2");
            _scope.Connect();

            if (Properties.Settings.Default.IsMaximized)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                Size = Properties.Settings.Default.MainFormSize;
                if (Top < 0)
                    Top = 0;
                if (Left < 0)
                    Left = 0;
            }

            groupBox1.Text = $@"Win32_classes ({Environment.MachineName})";
            FillListBox();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save maximize state and position
            Properties.Settings.Default.MainFormSize = Size;
            Properties.Settings.Default.PropWidth = colProperty.Width;
            Properties.Settings.Default.CimTypeWidth = colCimType.Width;
            Properties.Settings.Default.ValueWidth = colValue.Width;
            Properties.Settings.Default.IsMaximized = WindowState == FormWindowState.Maximized;
            Properties.Settings.Default.Save();
        }

        #region Variables

        /// <summary>
        /// Scope
        /// </summary>
        private ManagementScope _scope;

        private CancellationTokenSource _cts;

        /// <summary>
        /// WMI class description
        /// </summary>
        private class WmiCLassDesc
        {
            public readonly string Name;
            public string Description;

            public WmiCLassDesc(string name)
            {
                Name = name;
            }
        }

        /// <summary>
        /// WMI class shortname to description collection
        /// </summary>
        Dictionary<string, WmiCLassDesc> _wmiClassCollection;

        private object[] WmiClassShortNames => _wmiClassCollection.Keys.ToArray<object>();

        /// <summary>
        /// New line value
        /// </summary>
        private static string Nl => Environment.NewLine;

        /// <summary>
        /// Property name to description
        /// </summary>
        private Dictionary<string, string> NameToDescription { get; } = new Dictionary<string, string>();

        /// <summary>
        /// CimType to String dictionary
        /// </summary>
        private readonly Dictionary<CimType, string> CimTypeToString =
            new Dictionary<CimType, string>
            {
                [CimType.Boolean] = "Boolean",
                [CimType.Char16] = "Char16",
                [CimType.DateTime] = "DateTime",
                [CimType.None] = "None",
                [CimType.Object] = "Object",
                [CimType.Real32] = "Real32",
                [CimType.Real64] = "Real64",
                [CimType.Reference] = "Reference",
                [CimType.SInt16] = "SInt16",
                [CimType.SInt32] = "SInt32",
                [CimType.SInt64] = "SInt64",
                [CimType.SInt8] = "SInt8",
                [CimType.String] = "String",
                [CimType.UInt16] = "UInt16",
                [CimType.UInt32] = "UInt32",
                [CimType.UInt64] = "UInt64",
                [CimType.UInt8] = "UInt8",
            };

        #endregion Variables

        private void filterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox.ShowFilter();
        }

        #region ListBox/ListView

        /// <summary>
        /// Fill classes list
        /// </summary>
        private void FillListBox()
        {
            if (!_scope.IsConnected)
                return;

            _wmiClassCollection = new Dictionary<string, WmiCLassDesc>();

            try
            {
                Cursor = Cursors.WaitCursor;

                listBox.Items.Clear();

                // Get available classes' list
                const string query = @"SELECT * FROM Meta_Class WHERE __Class LIKE 'win32_%'";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query)
                {
                    Scope = _scope,
                };
                foreach (var o in searcher.Get())
                {
                    var mo = (ManagementObject)o;
                    string shortName = mo.ClassPath.ClassName.Substring(6);
                    _wmiClassCollection[shortName] = new WmiCLassDesc(mo.ClassPath.ClassName);
                    foreach (QualifierData q in mo.Qualifiers)
                    {
                        if (q.Name.Equals("Description"))
                        {
                            _wmiClassCollection[shortName].Description = q.Value?.ToString();
                            break;
                        }
                    }
                }
                listBox.Items.AddRange(WmiClassShortNames);
                listBox.UpdateItems = UpdateListBoxItems;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        void UpdateListBoxItems(string filter)
        {
            listBox.Items.Clear();

            if (string.IsNullOrEmpty(filter))
            {
                listBox.Items.AddRange(WmiClassShortNames);
            }
            else
            {
                // convert to uppercase for ignorecase search
                string upFilter = filter.ToUpper();
                listBox.Items.AddRange(_wmiClassCollection.Keys
                    .Where(k => k.ToUpper().Contains(upFilter)).ToArray<object>());
            }
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxClassDesc.Text = _wmiClassCollection[listBox.Text].Description?.Replace("\n", Nl);
        }

        private void listView_MouseClick(object sender, MouseEventArgs e)
        {
            ShowPropertyDescription();
        }

        private void listView_KeyUp(object sender, KeyEventArgs e)
        {
            ShowPropertyDescription();
        }

        private void ShowPropertyDescription()
        {
            string pName = listView.SelectedItems[0].SubItems[0].Text;
            if (NameToDescription.ContainsKey(pName))
                textBoxPropertyDesc.Text = NameToDescription[pName];
        }

        #endregion ListBox/ListView

        #region Menu

        private void menuFileConnect_Click(object sender, EventArgs e)
        {
            using (NewConnectForm form = new NewConnectForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var opts = new ConnectionOptions
                    {
                        Username = form.textBoxUsername.Text,
                        Password = form.textBoxPassword.Text,
                    };
                    string path = $@"\\{form.textBoxHostname.Text}\root\cimv2";

                    _scope = new ManagementScope(path, opts);
                    _scope.Connect();

                    groupBox1.Text = $@"Win32_classes ({form.textBoxHostname.Text})";
                    FillListBox();
                }
            }
        }

        /// <summary>
        /// Update properties table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void UpdateProperties(object sender, EventArgs e)
        {
            if (listBox.SelectedItem == null)
            {
                MessageBox.Show(@"No class select", WmiBrowserMain.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // revert in finally block
                Cursor = Cursors.WaitCursor;
                listBox.Enabled = false;
                menuFileCancel.Enabled = contextMenuCancel.Enabled = true;

                NameToDescription.Clear();
                listView.Items.Clear();
                listView.Groups.Clear();
                textBoxPropertyDesc.Text = null;

                const string qDescription = "Description";

                groupBox3.Text = $@"Class properties: {listBox.Text}";
                string className = _wmiClassCollection[listBox.Text].Name;

                _cts = new CancellationTokenSource();
                await Task.Run(() =>
                {
                    ManagementClass processClass = new ManagementClass(className)
                    {
                        Options = { UseAmendedQualifiers = true }
                    };
                    PropertyDataCollection properties = processClass.Properties;

                    ManagementObjectSearcher searcher = new ManagementObjectSearcher($"SELECT * FROM {className}")
                    {
                        Scope = _scope,
                    };
                    foreach (var o in searcher.Get())
                    {
                        var mo = (ManagementObject)o;
                        _cts.Token.ThrowIfCancellationRequested();

                        ListViewGroup moGroup = new ListViewGroup(mo.Path.RelativePath);
                        Invoke(new Action(() =>
                        {
                            listView.Groups.Add(moGroup);
                        }));

                        // fill rows
                        foreach (PropertyData p in properties)
                        {
                            _cts.Token.ThrowIfCancellationRequested();

                            // Property name
                            string pName = p.Name;

                            // Property value
                            string pValue = default(string);
                            string pCimType = CimTypeToString[p.Type];
                            if (p.IsArray)
                            {   // Array
                                pCimType += "[]";
                                var array = mo[pName] as Array;
                                if (array != null)
                                {
                                    foreach (var a in array)
                                        pValue += $"{a}, ";
                                }
                                else
                                {
                                    pValue = $"{mo[pName]}";
                                }
                            }
                            else
                            {
                                switch (p.Type)
                                {   // Not array
                                    case CimType.None:
                                        break;
                                    case CimType.DateTime:
                                        // convert DateTime to handy format
                                        string value = mo[pName]?.ToString();
                                        if (false == string.IsNullOrEmpty(value))
                                            pValue = ManagementDateTimeConverter.ToDateTime(value).ToString(CultureInfo.CurrentCulture);
                                        break;
                                    default:
                                        pValue = $"{mo[pName]}";
                                        break;
                                }
                            }

                            // Property description
                            foreach (QualifierData q in p.Qualifiers)
                            {
                                _cts.Token.ThrowIfCancellationRequested();

                                if (q.Name.Equals(qDescription))
                                {
                                    string pDescription = processClass.GetPropertyQualifierValue(pName, qDescription)?.ToString();
                                    NameToDescription[pName] = pDescription?.Replace("\n", Nl);
                                    break;
                                }
                            }

                            ListViewItem pItem = new ListViewItem(new[] { pName, pCimType, pValue })
                            {
                                Group = moGroup
                            };
                            if ((listView.Items.Count & 1) == 1)
                                pItem.BackColor = System.Drawing.Color.LightGray;
                            Invoke(new Action(() =>
                            {
                                listView.Items.Add(pItem);
                            }));
                        }
                    }
                }, _cts.Token);
            }
            catch (OperationCanceledException ex)
            {
                MessageBox.Show(ex.Message, WmiBrowserMain.Name,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                menuFileCancel.Enabled = contextMenuCancel.Enabled = false;
                listBox.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private void CancelUpdate(object sender, EventArgs e)
        {
            _cts?.Cancel();
        }

        private void SavePropertiesToFile(object sender, EventArgs e)
        {
            if (listView.Items.Count == 0)
                return;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;

                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName, false, Encoding.GetEncoding("utf-8")))
                    {
                        foreach (ListViewGroup group in listView.Groups)
                        {
                            writer.WriteLine(group.Header);
                            foreach (ListViewItem item in group.Items)
                            {
                                string pName = item.SubItems[0].Text;
                                string pCimType = item.SubItems[1].Text;
                                string pValue = item.SubItems[2].Text;
                                writer.WriteLine($"{pName};{pCimType};{pValue}");
                            }
                        }
                    }

                    // open file
                    Process.Start(saveFileDialog.FileName);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }

        private void menuFileQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuHelpWin32Classes_Click(object sender, EventArgs e)
        {
            Process.Start("https://msdn.microsoft.com/en-us/library/aa394084(v=vs.85).aspx");
        }

        private void menuHelpAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show($@"{WmiBrowserMain.Name}:{Nl}simple program to browse WMI Win32_classes",
                WmiBrowserMain.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void contextMenuSearchMSDN_Click(object sender, EventArgs e)
        {
            Process.Start($"https://social.msdn.microsoft.com/Search/en-US?query=Win32_{listBox.Text}");
        }

        #endregion Menu
        
    }
}
