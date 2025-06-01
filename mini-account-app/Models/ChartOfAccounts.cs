using System.ComponentModel.DataAnnotations;

namespace mini_account_app.Models
{
    public class ChartOfAccounts
    {
        public int Id { get; set; }
        [Required]
        public string? AccountType { get; set; }
        [Required]
        public string? AccountName { get; set; }
    }

    public class ChartOfAccountsType
    {
        public static List<string> lstAccountType
        {
            get
            {
                return new List<string>()
                {
                    "Cash","Bank","Receivable"
                };
            }
        }
    }

}
