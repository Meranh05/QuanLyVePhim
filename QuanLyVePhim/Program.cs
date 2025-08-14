using System;
using System.Windows.Forms;

namespace QuanLyVeXemPhim
{
	 static class Program
	 {
		  [STAThread]
		  static void Main()
		  {
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new Forms.FormLogin());
				Application.Run();
		  }
	 }
}
