using HotelProject.DataAccessLayer.Concrete.Database;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.WebUI.Controllers
{
    [Authorize(Roles = "Member")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly Context _context;
        public ProfileController(UserManager<AppUser> userManager, Context context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUser model)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.PhoneNumber = model.PhoneNumber;
                user.Email = model.Email;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    ViewBag.Message = "Bilgiler başarıyla güncellendi.";
                }
                else
                {
                    ViewBag.Message = "Hata oluştu. Lütfen tekrar deneyin.";
                }
            }

            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> Update()
        {
            var user = await _userManager.GetUserAsync(User);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AppUser model, string currentPassword, string newPassword, string confirmPassword)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null) return NotFound();

            user.Name = model.Name;
            user.Surname = model.Surname;
            user.Email = model.Email;
            user.ImageUrl = model.ImageUrl;

            if (!string.IsNullOrEmpty(currentPassword) &&
                !string.IsNullOrEmpty(newPassword) &&
                !string.IsNullOrEmpty(confirmPassword))
            {
                if (newPassword != confirmPassword)
                {
                    ModelState.AddModelError("", "Yeni şifre ile tekrar şifresi uyuşmuyor.");
                    return View(model);
                }

                var passwordChangeResult = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
                if (!passwordChangeResult.Succeeded)
                {
                    foreach (var error in passwordChangeResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }
            }

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                var fullName = $"{user.Name} {user.Surname}";

                var bookings = await _context.Bookings
                    .Where(b => b.Name == fullName || b.Email == user.Email)
                    .ToListAsync();

                foreach (var booking in bookings)
                {
                    booking.Name = fullName;
                    booking.Email = user.Email;
                }

                await _context.SaveChangesAsync();

                TempData["Message"] = "Bilgiler başarıyla güncellendi.";
                return RedirectToAction("Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }



    }
}
