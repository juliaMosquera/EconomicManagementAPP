namespace EconomicManagementAPP.Models
{
    public class AccountAndAccountTypes
    {
        public IEnumerable<Accounts> Accounts { get; set; }
        public IEnumerable<AccountTypes> AccountTypes { get; set; }
    }
}
