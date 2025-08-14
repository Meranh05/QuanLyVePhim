


using System.Drawing;
using System.Drawing.Printing;

namespace QuanLyVeXemPhim.Utilities
{
	 public class PrintUtility
	 {
		  public void PrintVe(string maVe, string tenPhim, string gioChieu, string ghe)
		  {
				PrintDocument pd = new PrintDocument();
				pd.PrintPage += (sender, e) =>
				{
					 e.Graphics.DrawString($"Vé: {maVe}\nPhim: {tenPhim}\nGiờ: {gioChieu}\nGhế: {ghe}",
						  new Font("Arial", 12), Brushes.Black, new PointF(100, 100));
				};
				pd.Print();
		  }
	 }
}