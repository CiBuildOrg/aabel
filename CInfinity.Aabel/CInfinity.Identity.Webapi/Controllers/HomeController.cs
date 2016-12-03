using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using IdentityServer4.Services;
using CInfinity.Identity.Webapi.UI.Models;
using IdentityServer4.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CInfinity.Identity.Webapi.Controllers
{
    public class HomeController : Controller
    {
        #region Fields
        private readonly IIdentityServerInteractionService _interaction;
        #endregion

        #region Constructors
        public HomeController(IIdentityServerInteractionService interaction)
        {
            _interaction = interaction;
        }
        #endregion

        #region Public methods
        public IActionResult Index() => View();

        /// <summary>
        /// Shows the error page
        /// </summary>
        public async Task<IActionResult> Error(string errorId) =>
            View("Error", await GetErrorViewModelAsync(errorId));
        #endregion

        #region Helper methods
        private async Task<ErrorViewModel> GetErrorViewModelAsync(string errorId) =>
            new ErrorViewModel
            {
                Error = await GetErrorMessage(errorId)
            };

        private async Task<ErrorMessage> GetErrorMessage(string errorId) =>
            await _interaction.GetErrorContextAsync(errorId);
        #endregion
    }
}
