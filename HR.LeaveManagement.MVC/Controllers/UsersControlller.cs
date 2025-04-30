using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        public UsersController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        public IActionResult Login(string returlUrl = default)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM, string returlUrl)
        {

                var loggedin = await _authenticationService.Authenticate(loginVM.Email, loginVM.Password);

                if (loggedin)
                    return LocalRedirect(returlUrl ?? Url.Content("~/"));
            

            ModelState.AddModelError(string.Empty, "Invalid login attempt");
            return View(loginVM);
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationVM registrationVM)
        {
            if (ModelState.IsValid)
            {
                var returnUrl = Url.Content("~/");
                var registeredIn = await _authenticationService.Register(registrationVM.Email, registrationVM.Password, registrationVM.FirstName, registrationVM.LastName, registrationVM.UserName);

                if(registeredIn.UserId != default)
                    return LocalRedirect(returnUrl);
            }
            ModelState.AddModelError("", "Invalid registration attempt");
            return View(registrationVM);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut(string returnUrl)
        {
            returnUrl ??= Url.Content("~/");
            await _authenticationService.LogOut();

            return LocalRedirect(returnUrl);
        }
    }
}
