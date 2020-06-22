using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentalProduct.PL.Helper;
using RentalProduct.PL.Models.ViewModels;
using RentalProducts.DAL.Contexts;
using System;
using System.Threading.Tasks;

namespace RentalProduct.PL.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signinManager;
        private ApplicationDbContext _context;
        public AccountController(UserManager<IdentityUser> userMgr,

        SignInManager<IdentityUser> signinMgr, ApplicationDbContext context)
        {
            userManager = userMgr;
            signinManager = signinMgr;
            _context = context;
        }

        [AllowAnonymous]
        public ViewResult Login(string returnUrl)
        {
            EventLogger.WriteLog("Get Products List", _context);
            return View(new LoginModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IdentityUser user = await userManager.FindByNameAsync(loginModel.Name);
                    if (user != null)
                    {
                        await signinManager.SignOutAsync();
                        if ((await signinManager.PasswordSignInAsync(user,
                        loginModel.Password, false, false)).Succeeded)
                        {

                            return Redirect(loginModel?.ReturnUrl ?? "/Admin/Index");
                        }
                    }
                }
                ModelState.AddModelError("", "Invalid name or password");
                EventLogger.WriteLog("Login Admin Page", _context);
                return View(loginModel);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, _context);
                return BadRequest();
            }
        }

        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signinManager.SignOutAsync();
            EventLogger.WriteLog("Admin LogOut", _context);
            return Redirect(returnUrl);
        }
    }
}
