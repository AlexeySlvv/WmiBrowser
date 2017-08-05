using System;
using System.Threading;
using System.Windows.Forms;

namespace WmiBrowser
{
	static class WmiBrowserMain
	{

		public const string Name = "WmiBrowser";

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.ThreadException += OnThreadException;

			MainForm mf = new MainForm();
			Application.Run(mf);
		}
		
		/// <summary>
		/// Getting exceptions
		/// </summary>
		private static void OnThreadException(object sender, ThreadExceptionEventArgs args)
		{
			MessageBox.Show($@"{args.Exception.Message}", Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

	}
}
