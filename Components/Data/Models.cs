using System.ComponentModel.DataAnnotations;

namespace DDON_WebPage.Components.Data
{
    public class Models
    {
        public class UpdateModel
        {
            public int Id { get; set; }

            [Required(ErrorMessage = "E-mail cannot be empty")]
            [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid e-mail format")]
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
            public string Name { get; set; } = string.Empty;

            [Required(ErrorMessage = "E-mail cannot be empty")]
            [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid e-mail format")]
            public string Email { get; set; } = string.Empty;

            [Required(ErrorMessage = "Password cannot be empty")]
            public string Password { get; set; } = string.Empty;

            [Required(ErrorMessage = "Confirmation cannot be empty")]
            [Compare("Password", ErrorMessage = "Passwords don't match")]
            public string ConfirmPassword { get; set; } = string.Empty;
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
            [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid e-mail format")]
            public string Email { get; set; } = string.Empty;
        }
    }
}
