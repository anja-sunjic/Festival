using Festival.Data.Models;
using Festival.Data.Repositories;
using Festival.Web.Helper;
using FestivalWebApplication.ViewModels.TransferVehicle;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Festival.Web.Controllers;

namespace FestivalWebApplication.Controllers
{
    [Authorize]
    public class TransferVehicleController : BaseController
    {
        private readonly ITransferVehicleRepository _repo;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TransferVehicleController(ITransferVehicleRepository repo, IWebHostEnvironment webHostEnvironment)
        {
            _repo = repo;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            List<ListTransferVehicleVM> Model = _repo.GetAll().Select(p => new ListTransferVehicleVM
            {
                Id = p.ID,
                Name = p.Name,
                RegistrationNumber = p.RegistrationNumber,
                Driver = p.Driver,
                Capacity = p.Capacity
            }).ToList();

            return View(Model);

        }

        public IActionResult New()
        {
            NewTransferVehicleVM Model = new NewTransferVehicleVM();

            return View(Model);
        }

        public IActionResult SaveNew(NewTransferVehicleVM model)
        {
            if (!ModelState.IsValid)
            {
                return View("New");
            }

            string uniqueFileName = ImageUpload.UploadImage(model.Picture, _webHostEnvironment, "transfervehicles");

            TransferVehicle vehicle = new TransferVehicle()
            {
                Name = model.Name,
                RegistrationNumber = model.RegistrationNumber,
                Driver = model.Driver,
                Capacity = model.Capacity,
                Picture = uniqueFileName
            };

            _repo.Add(vehicle);
            return RedirectToAction("List");
        }

        public IActionResult Detail(int ID)
        {
            TransferVehicle vehicle = _repo.GetByID(ID);
            var Model = new DetailTransferVehicleVM
            {
                ID = vehicle.ID,
                Name = vehicle.Name,
                Capacity = vehicle.Capacity,
                RegistrationNumber = vehicle.RegistrationNumber,
                Driver = vehicle.Driver,
                Picture = vehicle.Picture
            };
            return View(Model);
        }

        public IActionResult Edit(int ID)
        {
            var transferVehicle = _repo.GetByID(ID);
            var Model = new EditTransferVehicleVM
            {
                ID = transferVehicle.ID,
                Name = transferVehicle.Name,
                RegistrationNumber = transferVehicle.RegistrationNumber,
                Driver = transferVehicle.Driver,
                Capacity = transferVehicle.Capacity
            };

            return View("Edit", Model);
        }

        public IActionResult Save(EditTransferVehicleVM model)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit");
            }

            string uniqueFileName = ImageUpload.UploadImage(model.Picture, _webHostEnvironment, "transfervehicles");
            var acc = _repo.GetByID(model.ID);
            acc.Name = model.Name;
            acc.Capacity = model.Capacity;
            acc.RegistrationNumber = model.RegistrationNumber;
            acc.Driver = model.Driver;
            if (model.Picture != null)
            {
                acc.Picture = uniqueFileName;
            }
            _repo.Save();
            return RedirectToAction("List");
        }


        public IActionResult Delete(int Id)
        {
            _repo.Delete(Id);
            return Redirect("/TransferVehicle/Index");
        }
    }
}
