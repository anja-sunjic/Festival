using Festival.Data.Models;
using Festival.Data.Repositories;
using Festival.Web.ViewModels.Attendee;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Festival.Web.Controllers
{

    [Area("Admin")]
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
       
    }
}
