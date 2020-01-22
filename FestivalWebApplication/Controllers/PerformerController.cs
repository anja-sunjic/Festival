using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FestivalWebApplication.ViewModels.Performer;
using Microsoft.AspNetCore.Hosting;
using ClassLibrary.Models;
using System.IO;

namespace FestivalWebApplication.Controllers
{
    public class PerformerController : Controller
    {
        private readonly IWebHostEnvironment hostingEnvironment;
        public PerformerController(IWebHostEnvironment environment)
        {
            hostingEnvironment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            using (FestivalContext db = new FestivalContext())
            {
                List<PerformersListVM> Model = db.Performer.Select(p => new PerformersListVM
                {
                    PerformerID=p.ID,
                    PerformerName=p.Name,
                    ManagerName=db.Manager.Where(m=> m.ID==p.ManagerID).FirstOrDefault().Name
                }).ToList();
                int broj = 0;
                foreach(PerformersListVM x in Model)
                {
                    x.Number = ++broj;
                }
                return View(Model); 
            }
        }
        public IActionResult New()
        {
            NewPerformerVM Model = new NewPerformerVM();
            return View(Model);
        }
        public IActionResult SaveNew(NewPerformerVM Model)
        {
            using (FestivalContext db = new FestivalContext())
            {
                //creating new manager object
                Manager manager = new Manager();
                manager.Name = Model.ManagerName;
                manager.PhoneNumber = Model.ManagerPhoneNumber;
                manager.Email = Model.ManagerEmail;
                //adding new manager to db
                db.Manager.Add(manager);
                db.SaveChanges();

                //creating new performer object
                Performer performer = new Performer();
                performer.Name = Model.Name;
                performer.Fee = Model.Fee;
                performer.PromoText = Model.PromoText;
                performer.ManagerID = manager.ID;
                db.Performer.Add(performer);
                db.SaveChanges();

                //uploading image
                string fileName = "image"+performer.ID.ToString()+Path.GetExtension(Model.Image.FileName);
                string folderPath = Path.Combine(hostingEnvironment.WebRootPath, "images/performerImages");
                string filePath = Path.Combine(folderPath, fileName);

                Model.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                Image image = new Image();
                image.ImagePath = filePath;
                db.Image.Add(image);
                db.SaveChanges();

                performer.ImageID = image.Id;
                db.SaveChanges();

                return RedirectToAction("List");
            }
        }
    }
}
