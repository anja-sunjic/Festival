using Festival.Data.Models;
using Festival.Data.Repositories;
using Festival.Web.ViewModels.TransferService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FestivalWebApplication.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class TransferServiceController : Controller
    {
        private readonly ITransferServiceRepository _repo;

        public TransferServiceController(ITransferServiceRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            List<ListTransferServiceVM> Model = _repo.GetAll().Select(p => new ListTransferServiceVM
            {
                Id = p.ID,
                VehicleName = _repo.GetVehicleNameByVehicleID(p.TransferVehicleID),
                AvailableSeats = p.NumberOfAvailableSeats,
                MeetingPoint = p.MeetingPoint,
                Date = p.Date.ToShortDateString()
            }).ToList();
            return View(Model);
        }

        public IActionResult New()
        {
            NewTransferServiceVM Model = new NewTransferServiceVM
            {
                Vehicles = _repo.GetAllVehicles().Select(o => new SelectListItem
                {
                    Value = o.ID.ToString(),
                    Text = o.Name
                }).ToList()
            };
            Model.Date = DateTime.Today;
            return View(Model);
        }
        //public IActionResult Delete(int Id)
        //{
        //    TransferService TransferService = _db.TransferService.Find(Id);

        //    _db.Remove(TransferService);
        //    _db.SaveChanges();
        //    return Redirect("/TransferService/Index");
        //}



        [HttpPost]
        public IActionResult SaveNew(NewTransferServiceVM Model)
        {
            if (!ModelState.IsValid)
            {
                var newModel = new NewTransferServiceVM
                {
                    Vehicles = _repo.GetAllVehicles().Select(o => new SelectListItem
                    {
                        Value = o.ID.ToString(),
                        Text = o.Name
                    }).ToList()
                };
                newModel.Date = DateTime.Today;
                return View("New", newModel);
            }

            TransferService transferService = new TransferService
            {
                NumberOfAvailableSeats = Model.AvailableSeats,
                TransferVehicle = _repo.GetVehicleByID(Model.VehicleId),
                MeetingPoint = Model.MeetingPoint,
                Date = Model.Date
            };

            _repo.Add(transferService);

            return RedirectToAction("Index");
        }

        public IActionResult Detail(int ID)
        {
            TransferService service = _repo.GetByID(ID);
            var model = new DetailTransferServiceVM()
            {
                Id = service.ID,
                VehicleName = _repo.GetVehicleNameByVehicleID(service.TransferVehicleID),
                MeetingPoint = service.MeetingPoint,
                Date = service.Date.ToLongTimeString() + ' ' + service.Date.ToLongDateString(),
                AvailableSeats = service.NumberOfAvailableSeats
            };
            return View(model);
        }

        public IActionResult Save(EditTransferServiceVM model)
        {
            if (!ModelState.IsValid)
            {
                var newModel = new EditTransferServiceVM
                {
                    Vehicles = _repo.GetAllVehicles().Select(o => new SelectListItem
                    {
                        Value = o.ID.ToString(),
                        Text = o.Name
                    }).ToList()
                };
                newModel.Date = DateTime.Today;
                return View("Edit", newModel);
            }

            var acc = _repo.GetByID(model.Id);
            acc.TransferVehicleID = model.VehicleId;
            acc.NumberOfAvailableSeats = model.AvailableSeats;
            acc.MeetingPoint = model.MeetingPoint;
            acc.Date = model.Date;
            _repo.Save();
            return RedirectToAction("List");
        }

        public IActionResult Edit(int Id)
        {
            TransferService transferService = _repo.GetByID(Id);
            var Model = new EditTransferServiceVM
            {
                Id = transferService.ID,
                AvailableSeats = transferService.NumberOfAvailableSeats,
                VehicleId = transferService.TransferVehicleID,
                Date = transferService.Date,
                MeetingPoint = transferService.MeetingPoint,
                Vehicles = _repo.GetAllVehicles().Select(o => new SelectListItem
                {
                    Value = o.ID.ToString(),
                    Text = o.Name
                }).ToList()
            };

            return View("Edit", Model);
        }
    }
}
