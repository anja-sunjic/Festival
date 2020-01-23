using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary.Models;
using FestivalWebApplication.ViewModels.Sponsor;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace FestivalWebApplication.Controllers
{
    public class SponsorController : Controller
    {
        private readonly IWebHostEnvironment hostingEnvironment;
        public SponsorController(IWebHostEnvironment environment)
        {
            hostingEnvironment = environment;
        }
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }
        public IActionResult List()
        {
            using (FestivalContext db = new FestivalContext())
            {
                List<SponsorsListVM> Model = db.Sponsor.Select(s => new SponsorsListVM
                {
                    SponsorID = s.ID,
                    CompanyName = s.CompanyName,
                    ContactPersonName = s.ContactPersonName
                }).ToList();
                int broj = 0;
                foreach (SponsorsListVM x in Model)
                {
                    x.Number = ++broj;
                }
                return View(Model);
            }
        }
        public IActionResult New()
        {
            NewSponsorVM Model = new NewSponsorVM();
            return View(Model);
        }
        public IActionResult SaveNew(NewSponsorVM Model)
        {
            using (FestivalContext db = new FestivalContext())
            {
                //creating a new sponsor object
                Sponsor sponsor = new Sponsor();
                sponsor.CompanyName = Model.CompanyName;
                sponsor.ContactPersonName = Model.ContactPersonName;
                sponsor.PhoneNumber = Model.PhoneNumber;
                sponsor.Address = Model.Address;

                //adding new sponsor to db
                db.Sponsor.Add(sponsor);
                db.SaveChanges();

                //uploading image
                string fileName = "image" + sponsor.ID.ToString() + Path.GetExtension(Model.Image.FileName);
                string folderPath = Path.Combine(hostingEnvironment.WebRootPath, "images/sponsorImages");
                string filePath = Path.Combine(folderPath, fileName);

                Model.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                Image image = new Image();
                image.ImagePath = Path.Combine("~/images/sponsorImages/", fileName);
                db.Image.Add(image);
                db.SaveChanges();

                sponsor.ImageID = image.Id;
                db.SaveChanges();

                return RedirectToAction("List");
            }
        }
        public IActionResult Edit(int id)
        {
            using (FestivalContext db = new FestivalContext())
            {
                Sponsor x = db.Sponsor.Find(id);
                EditSponsorVM Model = new EditSponsorVM();
                Model.Id = x.ID;
                Model.CompanyName = x.CompanyName;
                if (x.ImageID != null)
                    Model.ImagePath = db.Image.Find(x.ImageID).ImagePath;

                Model.ContactPersonName = x.ContactPersonName;
                Model.PhoneNumber = x.PhoneNumber;
                Model.Address = x.Address;

                return View("Edit", Model);
            }

        }
        public IActionResult Save(EditSponsorVM Model)
        {
            using (FestivalContext db = new FestivalContext())
            {
                //finding sponsor in db
                Sponsor x = db.Sponsor.Find(Model.Id);
                //changing data
                x.CompanyName = Model.CompanyName;
                x.ContactPersonName = Model.ContactPersonName;
                x.Address = Model.Address;
                x.PhoneNumber = Model.PhoneNumber;

                //check if there is a new image, and change if there is 
                if (Model.Image != null)
                {
                    string fileName = "image" + x.ID.ToString() + Path.GetExtension(Model.Image.FileName);
                    string folderPath = Path.Combine(hostingEnvironment.WebRootPath, "images/sponsorImages");
                    string filePath = Path.Combine(folderPath, fileName);

                    //Model.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        Model.Image.CopyTo(stream);
                    };


                }

                db.SaveChanges();

                return RedirectToAction("List");
            }
        }

        public IActionResult Delete(int id)
        {
            using (FestivalContext db = new FestivalContext())
            {
                Sponsor x = db.Sponsor.Find(id);
              
                db.Sponsor.Remove(x);

                db.SaveChanges();

            }
            return RedirectToAction("List");
        }
    }
}
