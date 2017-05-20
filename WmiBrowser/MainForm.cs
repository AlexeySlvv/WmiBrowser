// CimType: https://msdn.microsoft.com/ru-ru/library/system.management.cimtype(v=vs.110).aspx
// Win32 Classes: https://msdn.microsoft.com/en-us/library/aa394084(v=vs.85).aspx

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
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
		/// WMI classes shortname to description
		/// </summary>
		Dictionary<string, WmiCLassDesc> _wmiClassCollection;

		private void MainForm_Load(object sender, EventArgs e)
		{
			_wmiClassCollection = new Dictionary<string, WmiCLassDesc>();

			// Get available classes' list
			const string query = @"SELECT * FROM Meta_Class WHERE __Class LIKE 'win32_%'";
			ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
			foreach (ManagementObject mo in searcher.Get())
			{
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
			listBox.Items.AddRange(_wmiClassCollection.Keys.ToArray<object>());
		}

		private void listBoxClasses_SelectedIndexChanged(object sender, EventArgs e)
		{
			textBoxClassDesc.Text = _wmiClassCollection[listBox.Text].Description;
		}

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

        /// <summary>
        /// Property name to description
        /// </summary>
        readonly Dictionary<string, string> _nameToDescription = new Dictionary<string, string>();

		private async void UpdateProperties(object sender, EventArgs e)
		{
			if (listBox.SelectedItem == null)
			{
				MessageBox.Show("No class select", WmiBrowserMain.ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			try
			{
				Cursor = Cursors.WaitCursor;
				listBox.Enabled = false;

                _nameToDescription.Clear();
                listView.Items.Clear();
				textBoxPropertyDesc.Text = null;
                
				string className = _wmiClassCollection[listBox.Text].Name;
				const string qDescription = "Description";

				await Task.Run(() =>
				{
					ManagementClass processClass = new ManagementClass(className)
					{
						Options = { UseAmendedQualifiers = true }
					};
					PropertyDataCollection properties = processClass.Properties;

					ManagementObjectSearcher searcher = new ManagementObjectSearcher($"SELECT * FROM {className}");
					foreach (ManagementObject mo in searcher.Get())
					{
                        ListViewGroup moGroup = new ListViewGroup(mo.Path.RelativePath);
                        Invoke(new Action(() => {
                            listView.Groups.Add(moGroup);
                        }));

						// fill rows
						foreach (PropertyData p in properties)
						{
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
							{   // Not array
								switch (p.Type)
								{
									case CimType.DateTime:
										// convert DateTime to handy format
										string value = mo[pName]?.ToString();
										if (false == string.IsNullOrEmpty(value))
											pValue = ManagementDateTimeConverter.ToDateTime(value).ToString();
										break;
									case CimType.None:
										pValue = null;
										break;
									default:
										pValue = $"{mo[pName]}";
										break;
								}
							}

							// Property description
							string pDescription = default(string);
							foreach (QualifierData q in p.Qualifiers)
							{
								if (q.Name.Equals(qDescription))
								{
									pDescription = processClass.GetPropertyQualifierValue(pName, qDescription)?.ToString();
                                    _nameToDescription[pName] = pDescription;
									break;
								}
							}

                            ListViewItem pItem = new ListViewItem(new string[] { pName, pCimType, pValue })
                            {
                                Group = moGroup
                            };
                            Invoke(new Action(() => {
                                listView.Items.Add(pItem);
                            }));
						}
					}
				});
			}
			finally
			{
				listBox.Enabled = true;
				Cursor = Cursors.Default;
			}
		}

        private void listView_MouseClick(object sender, MouseEventArgs e)
        {   
            ShowPropertyDescription();
        }

        /// <summary>
        /// show property description
        /// </summary>
        private void ShowPropertyDescription()
        {
            if (listView.SelectedItems.Count > 0
                && listView.SelectedItems[0].SubItems.Count > 0)
            {
                string pName = listView.SelectedItems[0].SubItems[0].Text;
                if (_nameToDescription.ContainsKey(pName))
                    textBoxPropertyDesc.Text = _nameToDescription[pName];
            }
        }

        private void listView_KeyUp(object sender, KeyEventArgs e)
        {
            ShowPropertyDescription();
        }
    }
}
