using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.LoginDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{

    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginUserDto loginUserDto)
        {
            if (!ModelState.IsValid)
                return View(loginUserDto);

            var user = await _userManager.FindByNameAsync(loginUserDto.Username);
            if (user == null)
            {
                ModelState.AddModelError("", "Kullanıcı bulunamadı.");
                return View(loginUserDto);
            }

            var passwordValid = await _userManager.CheckPasswordAsync(user, loginUserDto.Password);
            if (!passwordValid)
            {
                ModelState.AddModelError("", "Geçersiz şifre.");
                return View(loginUserDto);
            }

            await _signInManager.SignInAsync(user, isPersistent: false); 

            var roles = await _userManager.GetRolesAsync(user);
            if (roles.Contains("Admin"))
                return RedirectToAction("Index", "AdminStaff");

            else if (roles.Contains("Member"))
                return RedirectToAction("Index", "Default");

            else if (roles.Contains("Visitor"))
                return RedirectToAction("Index", "Visitor");

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }


    }
}