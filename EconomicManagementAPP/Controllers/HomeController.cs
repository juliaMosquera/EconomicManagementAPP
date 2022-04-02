using EconomicManagementAPP.Models;
using EconomicManagementAPP.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EconomicManagementAPP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorieAccounts repositorieAccounts;
        private readonly IRepositorieAccountTypes repositorieAccountTypes;
        private readonly IRepositorieUsers repositorieUsers;


        public HomeController(ILogger<HomeController> logger, 
                              IRepositorieUsers repositorieUsers, 
                              IRepositorieAccountTypes repositorieAccountTypes, 
                              IRepositorieAccounts repositorieAccounts)
        {
            _logger = logger;
            this.repositorieAccounts = repositorieAccounts;
            this.repositorieUsers = repositorieUsers;
            this.repositorieAccountTypes = repositorieAccountTypes;
        }

        public async Task<IActionResult> Index()
        {
            if (UsersController.valorSesion is null)
            {
                return RedirectToAction("Login", "Users");
            }
            int userId = UsersController.valorSesion.Id;
            AccountAndAccountTypes accountAndAccountTypes = new()
            {
                AccountTypes = await repositorieAccountTypes.GetAccountsTypes(userId),
                Accounts = await repositorieAccounts.GetUserAccounts(userId)
            };
            return !accountAndAccountTypes.AccountTypes.Any() ? RedirectToAction("Create", "AccountTypes") : View(accountAndAccountTypes);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // Interfaz para error de no encontrar el id
        public IActionResult Override()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}