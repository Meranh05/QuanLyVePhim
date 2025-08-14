using iTextSharp.text.pdf.qrcode;
using System.Drawing;
using ZXing;

namespace QuanLyVeXemPhim.Utilities
{
	 public class QrCodeUtility
	 {
		  public Bitmap GenerateQrCode(string content)
		  {
				var writer = new BarcodeWriter { Format = BarcodeFormat.QR_CODE };
				return writer.Write(content);
		  }
	 }
}
