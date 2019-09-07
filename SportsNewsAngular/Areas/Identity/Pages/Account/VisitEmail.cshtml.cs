using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportsNewsAngular.Models;

namespace SportsNewsAngular.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class VisitEmailModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public VisitEmailModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


    }
}
