using System.ComponentModel.DataAnnotations.Schema;

namespace DDON_WebPage.Components.Data
{
    public class Smtp
    {
        [Column("Server")]
        public string Server { get; } = string.Empty;
        
        [Column("Port")]
        public string Port { get; } = string.Empty;
        
        [Column("EmailAddr")]
        public string EmailAddr { get; } = string.Empty;
        
        [Column("EmailPwd")]
        public string EmailPwd { get; } = string.Empty;
        
        [Column("VerifySubject")]
        public string VerifySubject { get; } = string.Empty;
        
        [Column("ForgotPwdSubject")]
        public string ForgotPwdSubject { get; } = string.Empty;
        
        [Column("ForgotUsrSubject")]
        public string ForgotUsrSubject { get; } = string.Empty;
        
        [Column("NewsSubject")]
        public string NewsSubject { get; } = string.Empty;
    }
}