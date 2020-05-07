using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Festival.Data.Models;
using Festival.Data.Repositories;
using Festival.Web.ViewModels.Attendee;
using Microsoft.AspNetCore.Mvc;

namespace Festival.Web.Controllers
{
    public class AttendeeController : Controller
    {
        private readonly IAttendeeRepository _repo;
        public AttendeeController(IAttendeeRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }
        public IActionResult List()
        {
            List<AttendeeListVM> model = _repo.GetAttendees()
                .Select(a => new AttendeeListVM
                {
                    Id = a.ID,
                    Name = a.FirstName + " " + a.LastName,
                    Email = a.Email
                }).ToList();
            return View(model);
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
                UserAccountID=userAccount.ID

            };
            _repo.Add(attendee);
            

            return RedirectToAction("Index", "Home");
        }
    }
}