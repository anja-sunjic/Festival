using Festival.Data.Models;
using Festival.Data.Repositories;
using FestivalWebApplication.ViewModels.ShopItem;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FestivalWebApplication.Controllers
{
    [Authorize]
    public class ShopItemController : Controller
    {
        private readonly IShopItemRepository _repo;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ShopItemController(IShopItemRepository repo, IWebHostEnvironment webHostEnvironment)
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
            List<ShopItemListVM> model = _repo.GetAll().Select(p =>
                 new ShopItemListVM
                 {
                     ID = p.ID,
                     Name = p.Name,
                     Price = p.Price,
                     Quantity = p.Quantity,
                     Description = p.Description
                 }).ToList();
            return View("List", model);
        }

        public IActionResult New()
        {
            NewShopItemVM Model = new NewShopItemVM();
            return View(Model);
        }

        public IActionResult Delete(int ID)
        {
            _repo.Delete(ID);
            return Redirect("/ShopItem/List");
        }

        public IActionResult Detail(int ID)
        {
            ShopItem item = _repo.GetByID(ID);
            DetailShopItemVM model = new DetailShopItemVM()
            {
                ID = item.ID,
                Name = item.Name,
                Quantity = item.Quantity,
                Price = item.Price,
                Description = item.Description,
                Picture = item.Picture
            };
            return View(model);
        }

        public IActionResult Edit(int ID)
        {
            ShopItem shopItem = _repo.GetByID(ID);
            EditShopItemVM Model = new EditShopItemVM
            {
                ID = ID,
                Name = shopItem.Name,
                Price = shopItem.Price,
                Quantity = shopItem.Quantity,
                Description = shopItem.Description
            };
            return View("Edit", Model);
        }

        [HttpPost]
        public IActionResult SaveNew(NewShopItemVM model)
        {
            if (!ModelState.IsValid)
            {
                return View("New");
            }

            string uniqueFileName = UploadedFile(model);

            ShopItem shopItem = new ShopItem()
            {
                Name = model.Name,
                Price = model.Price,
                Quantity = model.Quantity,
                Description = model.Description,
                Picture = uniqueFileName
            };

            _repo.Add(shopItem);

            return RedirectToAction("List");
        }

        public IActionResult Save(EditShopItemVM model)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit");
            }

            string uniqueFileName = UploadedFile(model);

            ShopItem shopItem = _repo.GetByID(model.ID);
            shopItem.Name = model.Name;
            shopItem.Description = model.Description;
            shopItem.Price = model.Price;
            shopItem.Quantity = model.Quantity;
            if (model.ProfileImage != null)
            {
                shopItem.Picture = uniqueFileName;
            }
            _repo.Save();
            return RedirectToAction("List");
        }

        private string UploadedFile(NewShopItemVM model)
        {
            string uniqueFileName = null;

            if (model.ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "shopitems");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        private string UploadedFile(EditShopItemVM model)
        {
            string uniqueFileName = null;

            if (model.ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "shopitems");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

    }
}
