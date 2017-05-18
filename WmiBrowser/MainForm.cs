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

		private enum ETable
		{
			Name = 0,
			CimType = 1,
			Value = 2,
			Description = 3
		}

		private void gridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			var currentRow = (sender as CustomGridView)?.CurrentRow;
			if (currentRow == null)
				return;

			textBoxPropertyDesc.Text = currentRow.Cells[(int)ETable.Description].Value?.ToString();
		}

		// CimType: https://msdn.microsoft.com/ru-ru/library/system.management.cimtype(v=vs.110).aspx

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

		private async void tableUpdate_Click(object sender, EventArgs e)
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

				textBoxPropertyDesc.Text = null;
				table.Rows.Clear();

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
									break;
								}
							}

							table.Invoke(new Action(() =>
							{
								table.Rows.Add(pName, pCimType, pValue, pDescription);
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

	}
}
