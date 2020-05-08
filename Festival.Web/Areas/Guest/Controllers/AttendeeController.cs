using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Festival.Data.Models;
using Festival.Data.Repositories;
using Festival.Web.Areas.Guest.ViewModels.Attendee;
using Microsoft.AspNetCore.Mvc;

namespace Festival.Web.Areas.Guest.Controllers
{
    [Area("Guest")]
    public class AttendeeController : Controller
    {
        private readonly IAttendeeRepository _repo;
        public AttendeeController(IAttendeeRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult New()
        {
            NewAttendeeVM model = new NewAttendeeVM();

            return View(model);
        }
        public IActionResult SaveNew(NewAttendeeVM model)
        {
            if (!ModelState.IsValid)
            {
                return View("New");
            }
            UserAccount userAccount = new UserAccount
            {
                Username = model.Username,
                Password = model.Password,
                Type = AccountType.attendee
            };
            _repo.AddUserAccount(userAccount);

            Attendee attendee = new Attendee
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                UserAccountID = userAccount.ID

            };
            _repo.Add(attendee);


            return RedirectToAction("Index", "Home");
        }
    }
}