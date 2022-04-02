
using EconomicManagementAPP.Models;

public interface IRepositorieAccountTypes
{
    Task Create(AccountTypes accountTypes); // Se agrega task por el asincronismo
    Task<bool> Exist(string Name, int UserId);
    Task<IEnumerable<AccountTypes>> GetAccountsTypes(int UserId = 1);
    Task Modify(AccountTypes accountTypes);
    Task<AccountTypes> GetAccountById(int id, int userId = 1); // para el modify
    Task Delete(int id);
}
