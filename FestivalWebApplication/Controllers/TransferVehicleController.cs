using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary.Models;
using FestivalWebApplication.ViewModels.TransferVehicle;
using Microsoft.AspNetCore.Mvc;

namespace FestivalWebApplication.Controllers
{
    public class TransferVehicleController : Controller
    {
        private readonly FestivalContext _db;

        public TransferVehicleController(FestivalContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<TransferVehicleVM> Model = _db.TransferVehicle.Select(p => new TransferVehicleVM
            {
                Id = p.ID,
                Name = p.Name,
                RegistrationNumber=p.RegistrationNumber,
                Capacity=p.Capacity
            }).ToList();
            return View(Model);
        }
        public IActionResult New()
        {
            TransferVehicleVM Model = new TransferVehicleVM();

            return View(Model);
        }
        public IActionResult Delete(int Id)
        {
            TransferVehicle transferVehicle = _db.TransferVehicle.Find(Id);

            _db.Remove(transferVehicle);
            _db.SaveChanges();
            return Redirect("/TransferVehicle/Index");
        }
        public IActionResult Update(int Id)
        {
            TransferVehicle transferVehicle = _db.TransferVehicle.Find(Id);
            TransferVehicleVM Model = new TransferVehicleVM
            {
                Id = transferVehicle.ID,
                Name = transferVehicle.Name,
                RegistrationNumber = transferVehicle.RegistrationNumber,
                Capacity = transferVehicle.Capacity
            };

            return View("New",Model);
        }


        [HttpPost]
        public IActionResult SaveNew(TransferVehicleVM Model)
        {
            TransferVehicle transferVehicle; 
            if (Model.Id == 0)
            {
                transferVehicle = new TransferVehicle();
                _db.TransferVehicle.Add(transferVehicle);
            }
            else
            {
                transferVehicle = _db.TransferVehicle.Find(Model.Id);
            }

            transferVehicle.Name = Model.Name;
            transferVehicle.RegistrationNumber = Model.RegistrationNumber;
            transferVehicle.Capacity = Model.Capacity;

            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }

}
