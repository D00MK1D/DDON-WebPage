using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDON_WebPage.Components.Data
{
    public class Account
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [Column("state")]
        public int State { get; set; }

        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Column("normal_name")]
        public string NormalName { get; set; } = string.Empty;

        [Column("password_token")]
        public string? PasswordToken { get; set; } = string.Empty;

        [Column("hash")]
        public string Hash { get; set; } = string.Empty;

        [Column("mail")]
        public string Email { get; set; } = string.Empty;

        [Column("mail_token")]
        public string? EmailToken { get; set; } = string.Empty;

        [Column("mail_verified")]
        public bool EmailVerified { get; set; } = false;

        [Column("mail_verified_at")]
        public DateTime EmailVerifiedAt { get; set; }

        [Column("last_login")]
        public DateTime LastLogin { get; set; }

        [Column("created")]
        public DateTime CreatedAt { get; set; }
    }

    public class Connection
    {
        [Key]
        [Column("server_id")]
        public int ServerId { get; set; }

        [Column ("account_name")]
        public string AccountName { get; set; } = string.Empty;

        [Column("connected_at")]
        public DateTime ConnectedAt { get; set; }
    }
}
