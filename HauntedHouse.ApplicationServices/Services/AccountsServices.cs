using HauntedHouse.Core.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HauntedHouse.ApplicationServices.Services
{
    public class AccountsServices : IAccountServices
    {
        private readonly UserManager<ApplicationUser> _userManager; // lae uus pag
        private readonly SignInManager<ApplicationUser> _SignInManager;

        public AccountsServices(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _SignInManager = signInManager;
        }
    }
}
