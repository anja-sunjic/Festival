using Festival.Data.Models;
using FestivalWebApplication.ViewModels.TransferService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FestivalWebApplication.Controllers
{
    [Authorize]
    public class TransferServiceController : Controller
    {
        private readonly FestivalContext _db;

        public TransferServiceController(FestivalContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            List<ListTransferServiceVM> Model = _db.TransferService.Select(p => new ListTransferServiceVM
            {
                Id = p.ID,
                VehicleName = _db.TransferVehicle.Where(m => m.ID == p.TransferVehicleID).FirstOrDefault().Name,
                AvailableSeats = p.NumberOfAvailableSeats,
                Date = p.Date.ToShortDateString()
            }).ToList();
            return View(Model);
        }
        public IActionResult New()
        {
            NewTransferServiceVM Model = new NewTransferServiceVM
            {
                Vehicles = _db.TransferVehicle.Select(o => new SelectListItem
                {
                    Value = o.ID.ToString(),
                    Text = o.Name
                }).ToList()
            };
            return View(Model);
        }
        public IActionResult Delete(int Id)
        {
            TransferService TransferService = _db.TransferService.Find(Id);

            _db.Remove(TransferService);
            _db.SaveChanges();
            return Redirect("/TransferService/Index");
        }
        public IActionResult Update(int Id)
        {
            TransferService transferService = _db.TransferService.Include(a => a.TransferVehicle).FirstOrDefault(a => a.ID == Id);
            NewTransferServiceVM Model = new NewTransferServiceVM
            {
                Id = transferService.ID,
                AvailableSeats = transferService.NumberOfAvailableSeats,
                VehicleId = transferService.TransferVehicle.ID,
                Date = transferService.Date,
                Vehicles = _db.TransferVehicle.Select(o => new SelectListItem
                {
                    Value = o.ID.ToString(),
                    Text = o.Name
                }).ToList()
            };

            return View("New", Model);
        }


        [HttpPost]
        public IActionResult SaveNew(NewTransferServiceVM Model)
        {
            TransferService transferService;
            if (Model.Id == 0)
            {
                transferService = new TransferService();
                _db.TransferService.Add(transferService);
            }
            else
            {
                transferService = _db.TransferService.Find(Model.Id);
            }

            transferService.NumberOfAvailableSeats = _db.TransferVehicle.FirstOrDefault(a => a.ID == Model.VehicleId).Capacity;
            transferService.TransferVehicle = _db.TransferVehicle.FirstOrDefault(a => a.ID == Model.VehicleId);
            transferService.Date = Model.Date;

            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
