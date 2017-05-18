using System.Windows.Forms;

namespace WmiBrowser
{
	public partial class CustomGridView : DataGridView
	{
		public CustomGridView()
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

		protected override void OnRowPrePaint(DataGridViewRowPrePaintEventArgs e)
		{
			base.OnRowPrePaint(e);

			int ri = e.RowIndex;
			if (ri > -1 && ri < RowCount && (ri & 1) == 1)
			{
				Rows[ri].DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
			}
		}

	}
}
