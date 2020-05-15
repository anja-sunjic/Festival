using Festival.Data.Repositories;
using Festival.Web.Areas.Admin.ViewModels.TransferReservation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Festival.Web.Areas.Admin.Controllers
{
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
                FullName = x.Attendee.FirstName + x.Attendee.LastName,
                Email = x.Attendee.Email,
                Date = x.TransferService.Date,
                MeetingPoint = x.TransferService.MeetingPoint
            }).ToList();

            return View(model);
        }
    }
}
