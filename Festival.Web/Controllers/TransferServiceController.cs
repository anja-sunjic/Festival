using Festival.Data.Models;
using Festival.Data.Repositories;
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
        private readonly ITransferServiceRepository _repo;
        private readonly ITransferVehicleRepository _vehiclerepo;

        public TransferServiceController(ITransferServiceRepository repo, ITransferVehicleRepository vehiclerepo)
        {
            _repo = repo;
            _vehiclerepo = vehiclerepo;
        }
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            List<ListTransferServiceVM> Model = _repo.GetAll().Select(p => new ListTransferServiceVM
            {
                Id = p.ID,
                VehicleName = _vehiclerepo.GetByID(p.TransferVehicle.ID).Name,
                AvailableSeats = p.NumberOfAvailableSeats,
                Date = p.Date.ToShortDateString()
            }).ToList();
            return View(Model);
        }

        public IActionResult New()
        {
            NewTransferServiceVM Model = new NewTransferServiceVM
            {
                Vehicles = _vehiclerepo.GetAll().Select(o => new SelectListItem
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
            if (!ModelState.IsValid)
            {
                return View("New");
            }

            TransferService transferService;
            if (Model.Id == 0)
            {
                transferService = new TransferService()
                {
                    NumberOfAvailableSeats = Model.AvailableSeats,
                    TransferVehicle = _vehiclerepo.GetByID(Model.VehicleId),
                    Date = Model.Date
                };
                _repo.Add(transferService);
            }
            else
            {
                transferService = _db.TransferService.Find(Model.Id);
                transferService.NumberOfAvailableSeats = _db.TransferVehicle.FirstOrDefault(a => a.ID == Model.VehicleId).Capacity;
                transferService.TransferVehicle = _db.TransferVehicle.FirstOrDefault(a => a.ID == Model.VehicleId);
                transferService.Date = Model.Date;
            }

            _repo.Save();

            return RedirectToAction("Index");
        }
    }
}
