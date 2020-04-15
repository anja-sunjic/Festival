using Festival.Data.Models;
using Festival.Data.Repositories;
using FestivalWebApplication.ViewModels.TransferVehicle;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FestivalWebApplication.Controllers
{
    [Authorize]
    public class TransferVehicleController : Controller
    {
        private readonly ITransferVehicleRepository _repo;
        private readonly ITransferServiceRepository _servicerepo;

        public TransferVehicleController(ITransferVehicleRepository repo, ITransferServiceRepository servicerepo)
        {
            _repo = repo;
            _servicerepo = servicerepo;
        }
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            List<TransferVehicleVM> Model = _repo.GetAll().Select(p => new TransferVehicleVM
            {
                Id = p.ID,
                Name = p.Name,
                RegistrationNumber = p.RegistrationNumber,
                Capacity = p.Capacity
            }).ToList();

            return View(Model);

        }

        public IActionResult New()
        {
            TransferVehicleVM Model = new TransferVehicleVM();

            return View(Model);
        }

        public IActionResult Detail(int ID)
        {
            TransferVehicle vehicle = _repo.GetByID(ID);
            TransferVehicleVM Model = new TransferVehicleVM
            {
                Id = vehicle.ID,
                Name = vehicle.Name,
                Capacity = vehicle.Capacity,
                RegistrationNumber = vehicle.RegistrationNumber
            };
            return View(Model);
        }

        public IActionResult Edit(int ID)
        {
            TransferVehicle transferVehicle = _repo.GetByID(ID);
            TransferVehicleVM Model = new TransferVehicleVM
            {
                Id = transferVehicle.ID,
                Name = transferVehicle.Name,
                RegistrationNumber = transferVehicle.RegistrationNumber,
                Capacity = transferVehicle.Capacity
            };

            return View("New", Model);
        }

        public IActionResult Delete(int Id)
        {
            TransferVehicle transferVehicle = _repo.GetByID(Id);
            List<TransferService> deleteService = _servicerepo.GetAllServicesForVehicle(Id);
            if (deleteService.Count > 0)
            {
                foreach (var service in deleteService)
                {
                    _servicerepo.Delete(service.ID);
                }
            }
            _repo.Delete(Id);
            return Redirect("/TransferVehicle/Index");
        }


        public IActionResult Save(TransferVehicleVM Model)
        {
            TransferVehicle transferVehicle;
            if (Model.Id == 0)
            {
                transferVehicle = new TransferVehicle
                {
                    Name = Model.Name,
                    RegistrationNumber = Model.RegistrationNumber,
                    Capacity = Model.Capacity
                };
                _repo.Add(transferVehicle);
            }

            else
            {
                transferVehicle = _repo.GetByID(Model.Id);
                transferVehicle.Name = Model.Name;
                transferVehicle.RegistrationNumber = Model.RegistrationNumber;
                transferVehicle.Capacity = Model.Capacity;
                _repo.Save();
            }


            return RedirectToAction("Index");
        }
    }

}
