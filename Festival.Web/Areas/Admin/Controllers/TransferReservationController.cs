using Festival.Data.Models;
using Festival.Data.Repositories;
using Festival.Web.Areas.Admin.ViewModels.TransferReservation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Festival.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TransferReservationController : Controller
    {
        private readonly ITransferReservationRepository _repo;

        public TransferReservationController(ITransferReservationRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public IActionResult List()
        {

            List<TransferReservationListVM> model = _repo.GetAll().Select(x => new TransferReservationListVM
            {
                ID = x.ID,
                FullName = x.Attendee.FirstName + x.Attendee.LastName,
                Email = x.Attendee.Email,
                Date = x.TransferService.Date,
                MeetingPoint = x.TransferService.MeetingPoint
            }).ToList();

            return View(model);
        }

        public IActionResult New()
        {
            NewTransferReservationVM model = new NewTransferReservationVM()
            {
                Attendees = _repo.GetAllAttendees().Select(o => new SelectListItem
                {
                    Value = o.ID.ToString(),
                    Text = o.FirstName + " " + o.LastName
                }).ToList(),
                TransferServices = _repo.GetAllServices().Select(o => new SelectListItem
                {
                    Value = o.ID.ToString(),
                    Text = o.TransferVehicle.Name + " - " + o.MeetingPoint + " - " + o.Date.ToString()
                }).ToList()
            };

            return View(model);
        }

        public IActionResult SaveNew(NewTransferReservationVM model)
        {
            var reservation = new TransferReservation()
            {
                AttendeeID = model.AttendeeID,
                TransferServiceID = model.TransferServiceID
            };
            _repo.Add(reservation);
            return RedirectToAction("List");
        }
    }
}
