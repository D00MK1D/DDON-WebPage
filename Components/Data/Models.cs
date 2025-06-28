using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;

namespace DDON_WebPage.Components.Data
{
    public class Models
    {

        public class UpdateModel
        {
            public int Id { get; set; }

            [Required(ErrorMessage = "E-mail cannot be empty")]
            [EmailAddress(ErrorMessage = "Invalid E-mail")]
            public string Email { get; set; } = string.Empty;

            [Required(ErrorMessage = "Password cannot be empty")]
            public string Password { get; set; } = string.Empty;

            [Required(ErrorMessage = "Confirm password")]
            [Compare("Password", ErrorMessage = "Passwords don't match")]
            public string ConfirmPassword { get; set; } = string.Empty;
        }

        public class RegisterModel
        {
            [Required(ErrorMessage = "Account cannot be empty")]
            [RegularExpression(@"^\S+$", ErrorMessage = "Account ID cannot contain spaces")]
            public string Name { get; set; }

            [Required(ErrorMessage = "E-mail cannot be empty")]
            [EmailAddress(ErrorMessage = "Invalid E-mail")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Password cannot be empty")]
            public string Password { get; set; }

            [Required(ErrorMessage = "Confirmation cannot be empty")]
            [Compare("Password", ErrorMessage = "Passwords don't match")]
            public string ConfirmPassword { get; set; }
        }

        public class NewPasswordModel
        {
            [Required(ErrorMessage = "Enter new password")]
            public string? Password { get; set; }

            [Required(ErrorMessage = "Confirmation cannot be empty")]
            [Compare("Password", ErrorMessage = "Passwords don't match")]
            public string? ConfirmPassword { get; set; }
        }

        public class ForgotPasswordModel
        {
            [Required(ErrorMessage = "E-mail cannot be empty.")]
            [EmailAddress(ErrorMessage = "Invalid e-mail.")]
            public string Email { get; set; } = string.Empty;
        }

        public async Task SendResetEmail(string toEmail, string resetLink)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("someEmail@gmail.com", "somePassword"),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("ddon@crapcom.com", "Dragon's Dogma Online"),
                Subject = "Password Recovery",
                Body = $@"
                         <html>
                           <body>
                               <h2>Password Recovery</h2>
                               <p>Click on the link below to recover your password:</p>
                               <p><a href='{resetLink}'>Link</a></p>
                           </body>
                         </html>",
                IsBodyHtml = true,
            };

            mailMessage.To.Add(toEmail);

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
