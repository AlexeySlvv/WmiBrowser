using System;
using System.Windows.Forms;

namespace WmiBrowser
{
	public partial class CustomListBox : ListBox
	{

		public CustomListBox()
		{
			InitializeComponent();
		}

		private readonly TextBox FilterTextBox = new TextBox();

		private bool IsShowFilter = false;

		public void ShowFilter()
		{
			FilterTextBox.SetBounds(0, 0, this.Width, 21);
			FilterTextBox.KeyPress += OnFilterTextBoxKeyPress;
			Controls.Add(FilterTextBox);
			FilterTextBox.Show();
			FilterTextBox.Select();
			FilterTextBox.SelectAll();
			IsShowFilter = true;
		}

		public Action<string> UpdateItems;

		private void OnFilterTextBoxKeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char) Keys.Enter)
			{
				UpdateItems(FilterTextBox.Text);
				FilterTextBox.Hide();
				Controls.Remove(FilterTextBox);
				IsShowFilter = false;
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);

			if (IsShowFilter)
			{
				FilterTextBox.Hide();
				Controls.Remove(FilterTextBox);
				IsShowFilter = false;
			}

			if (e.Button == MouseButtons.Right)
			{
				int index = IndexFromPoint(e.Location);
				if (index >= 0)
					SelectedIndex = index;
			}
		}
		
	}
}
