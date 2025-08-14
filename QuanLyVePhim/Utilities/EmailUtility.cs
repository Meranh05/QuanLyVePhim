


using System.Net.Mail;

namespace QuanLyVeXemPhim.Utilities
{
	 public class EmailUtility
	 {
		  public void SendEmail(string toEmail, string subject, string body)
		  {
				using (var client = new SmtpClient("smtp.gmail.com", 587))
				{
					 client.EnableSsl = true;
					 client.Credentials = new System.Net.NetworkCredential("your-email@gmail.com", "your-app-password");
					 var message = new MailMessage("your-email@gmail.com", toEmail, subject, body);
					 client.Send(message);
				}
		  }
	 }
}