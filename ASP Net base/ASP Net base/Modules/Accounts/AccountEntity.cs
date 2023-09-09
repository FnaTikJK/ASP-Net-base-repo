using System.ComponentModel.DataAnnotations;

namespace ASP_Net_base.Modules.Accounts
{
    public class AccountEntity
    {
        [Key]
        public string Login { get; set; }
        public string PasswordHash { get; set; }
    }
}
