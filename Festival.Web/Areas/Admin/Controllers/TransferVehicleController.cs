using Festival.Data.Models;
using Festival.Data.Repositories;
using Festival.Web.Helper;
using Festival.Web.ViewModels.TransferVehicle;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Festival.Web.Controllers;

namespace FestivalWebApplication.Controllers
{
    [Authorize]
    [Area("Admin")]
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

        public IActionResult List(int? pageNumber)
        {
            var pageSize = 4;

            var model = _repo.GetAll().OrderBy(a=>a.Name).ToList().Select(p => new ListTransferVehicleVM
            {
                Id = p.ID,
                Name = p.Name,
                RegistrationNumber = p.RegistrationNumber,
                Driver = p.Driver,
                Capacity = p.Capacity
            }).AsQueryable();

            var paginatedModel = PaginatedList<ListTransferVehicleVM>.CreateAsync(model, pageNumber ?? 1, pageSize);


            return View(paginatedModel);
        }

        public IActionResult New()
        {
            var model = new NewTransferVehicleVM();

            return View(model);
        }

        public IActionResult SaveNew(NewTransferVehicleVM model)
        {
            if (!ModelState.IsValid)
            {
                return View("New");
            }

            var uniqueFileName = Image.Upload(model.Picture, _webHostEnvironment, "transfervehicles");

            var vehicle = new TransferVehicle
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

        public IActionResult Detail(int id)
        {
            var vehicle = _repo.GetByID(id);
            var model = new DetailTransferVehicleVM
            {
                ID = vehicle.ID,
                Name = vehicle.Name,
                Capacity = vehicle.Capacity,
                RegistrationNumber = vehicle.RegistrationNumber,
                Driver = vehicle.Driver,
                Picture = vehicle.Picture
            };
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var transferVehicle = _repo.GetByID(id);
            var model = new EditTransferVehicleVM
            {
                ID = transferVehicle.ID,
                Name = transferVehicle.Name,
                RegistrationNumber = transferVehicle.RegistrationNumber,
                Driver = transferVehicle.Driver,
                Capacity = transferVehicle.Capacity
            };

            return View("Edit", model);
        }

        public IActionResult Save(EditTransferVehicleVM model)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit");
            }

            var uniqueFileName = Image.Upload(model.Picture, _webHostEnvironment, "transfervehicles");
            var vehicle = _repo.GetByID(model.ID);

            vehicle.Name = model.Name;
            vehicle.Capacity = model.Capacity;
            vehicle.RegistrationNumber = model.RegistrationNumber;
            vehicle.Driver = model.Driver;

            if (model.Picture != null)
            {
                vehicle.Picture = uniqueFileName;
            }

            _repo.Save();
            return RedirectToAction("List");
        }


        public IActionResult Delete(int Id)
        {
            var vehicle = _repo.GetByID(Id);

            Image.Delete(_webHostEnvironment, "transfervehicles", vehicle.Picture);
            _repo.Delete(Id);

            return Redirect("/TransferVehicle/Index");
        }
    }
}
