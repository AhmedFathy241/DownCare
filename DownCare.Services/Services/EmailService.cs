using DownCare.Core.IServices;
using FluentEmail.Core;
using System.Text;

namespace DownCare.Services.Services
{
    public class EmailService : IEmailService
    {
        private readonly IFluentEmail _fluentEmail;

        public EmailService(IFluentEmail fluentEmail)
        {
            _fluentEmail = fluentEmail;
        }
        public async Task SendEmailVerificationAsync(string email, string userName, string confirmLink)
        {
            StringBuilder EmailMessage = new StringBuilder();
            EmailMessage.AppendLine("<html>");
            EmailMessage.AppendLine("<body>");
            EmailMessage.AppendLine($"<p> Dear {userName}, </p>");
            EmailMessage.AppendLine($"<p> Thank you for registration with DownCare. Before we continue, we just need to confirm that this is you. Click below to verify your email address:</p>");
            EmailMessage.AppendLine($"<h2> <a href=\"{confirmLink}\">Click Here</a> </h2>");
            EmailMessage.AppendLine($"<p> If you did not request this, please ignore this email. </p>");
            EmailMessage.AppendLine($"<br>");
            EmailMessage.AppendLine($"<p> Best regards, </p>");
            EmailMessage.AppendLine($"<p><strong>DownCare</strong></p>");
            EmailMessage.AppendLine($"</body>");
            EmailMessage.AppendLine("</html>");
            string message = EmailMessage.ToString();

            await _fluentEmail.To(email)
                .Subject("Verify your email address for DownCare")
                .Body(message, true)
                .SendAsync();
        }
        public async Task SendResetPasswordVerificationAsync(string email, string userName, string resetCode)
        {
            StringBuilder EmailMessage = new StringBuilder();
            EmailMessage.AppendLine("<html>");
            EmailMessage.AppendLine("<body>");
            EmailMessage.AppendLine($"<p> Dear {userName}, </p>");
            EmailMessage.AppendLine($"<p> A request has been sent to reset your password on DownCare, please enter the following code below to reset your password:</p>");
            EmailMessage.AppendLine($"<h2>{resetCode}</h2>");
            EmailMessage.AppendLine($"<p> If you did not request this, please ignore this email. </p>");
            EmailMessage.AppendLine($"<br>");
            EmailMessage.AppendLine($"<p> Best regards, </p>");
            EmailMessage.AppendLine($"<p><strong>DownCare</strong></p>");
            EmailMessage.AppendLine($"</body>");
            EmailMessage.AppendLine("</html>");
            string message = EmailMessage.ToString();

            await _fluentEmail.To(email)
                .Subject("Reset Password Request")
                .Body(message, true)
                .SendAsync();
        }
    }
}
//private void SendEmail(string Email, string EmailCode)
//{
//    StringBuilder EmailMessage = new StringBuilder();
//    EmailMessage.AppendLine("<html>");
//    EmailMessage.AppendLine("<body>");
//    EmailMessage.AppendLine($"<p> Dear {Email}, </p>");
//    EmailMessage.AppendLine($"<p> Thank you for registration with DownCare. To verify your email address, please use the following verification code: </p>");
//    EmailMessage.AppendLine($"<h2> Verification Code: {EmailCode} </h2>");
//    EmailMessage.AppendLine($"<p> Please Enter this code on our system to complete your registration.</p>");
//    EmailMessage.AppendLine($"<p> If you did not request this, please ignore this email. </p>");
//    EmailMessage.AppendLine($"<br>");
//    EmailMessage.AppendLine($"<p> Best regards, </p>");
//    EmailMessage.AppendLine($"<p><strong>DownCare</strong></p>");
//    EmailMessage.AppendLine($"</body>");
//    EmailMessage.AppendLine("</html>");
//    string message = EmailMessage.ToString();

//    var _email = new MimeMessage();
//    _email.To.Add(MailboxAddress.Parse(Email));
//    _email.From.Add(MailboxAddress.Parse("ahmedkarram241@gmail.com"));
//    _email.Subject = "Email Confirmation";
//    _email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message };

//    using var smtp = new SmtpClient();
//    smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
//    smtp.Authenticate("ahmedkarram241@gmail.com", "rnoc jjwp pdmi qujh");
//    smtp.Send(_email);
//    smtp.Disconnect(true);
//    //return "Thank you for registration, kindly check your email for confirmation code";
//}
//var ConfirmLink = Url.Action("Verify-Email", "Account", new { userEmail = user.Email, token = EmailToken }, Request.Scheme);