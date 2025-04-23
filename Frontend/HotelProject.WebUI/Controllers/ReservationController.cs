using HotelProject.DataAccessLayer.Concrete.Database;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Reservation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Security.Claims;

namespace HotelProject.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly Context _context;
        private readonly UserManager<AppUser> _userManager;

        public ReservationController(Context context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> MyReservations()
        {
            var user = await _userManager.GetUserAsync(User);
            //if (user == null)
            //{
            //    return RedirectToAction("Login", "Account");
            //}

            var userEmail = user.Email;

            var reservations = await _context.Bookings
                .Where(b => b.Email == userEmail)
                .Select(b => new MyReservationViewModel
                {
                    UserName = user.UserName,
                    Email = b.Email,
                    CheckIn = b.CheckIn,
                    CheckOut = b.CheckOut,
                    AdultCount = b.AdultCount,
                    ChildCount = b.ChildCount,
                    SpecialRequest = b.SpecialRequest,
                    Status = b.Status,
                    City = b.City,
                    Country = b.Country
                })
                .ToListAsync();

            return View(reservations);
        }
    }
}