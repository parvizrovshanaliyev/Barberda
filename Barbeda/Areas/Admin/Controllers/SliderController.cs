using Barbeda.DAL;
using Barbeda.Extensions;
using Barbeda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Barbeda.Utilities.Utilities;

namespace Barbeda.Areas.Admin.Controllers
{
    public class SliderController : Controller
    {
        private readonly BarbedaContext _context;
        public SliderController()
        {
            _context = new BarbedaContext();
        }
        // GET: Admin/Slider
        public ActionResult Index()
        {
            
            //DateTime? date = _context.Sliders.OrderByDescending(s => s.UpdateAt).FirstOrDefault().UpdateAt;

            
            //ViewBag.UpdateAt = date;
            return View(_context.Sliders);
        }

        public ActionResult Create()
        {
            return View();

        }

        [HttpPost,ValidateAntiForgeryToken,ValidateInput(false)]
        public ActionResult Create([Bind(Include = "TitleOne,TitleTwo,Photo")]Slider sliderI)
        {
            if (!ModelState.IsValid) return View(sliderI);
            if (sliderI.Photo != null)
            {
                if (!sliderI.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Photo type is not valid");
                    
                    return View(sliderI);
                }
                
                sliderI.Image = sliderI.Photo.SavePhoto("Assets/img", "slider");
            }

            _context.Sliders.Add(sliderI);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }
        public ActionResult Edit(int? Id)
        {
            if (Id == null) return HttpNotFound("Id gelmir la");
            var sliderItem = _context.Sliders.Find(Id);
            if (sliderItem == null) return HttpNotFound("slider Item yok la");
            return View(sliderItem);
        }

        [HttpPost,ValidateAntiForgeryToken,ValidateInput(false)]
        public ActionResult Edit([Bind(Include ="Id,TitleOne,TitleTwo,Photo")]Slider sliderInput)
        {
            if (!ModelState.IsValid) return View(sliderInput);

            Slider sliderBase = _context.Sliders.Find(sliderInput.Id);

            if(sliderInput.Photo != null)
            {
                if (!sliderInput.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Photo type is not valid");
                    sliderInput.Image = sliderBase.Image ;
                    return View(sliderInput);
                }
                RemoveImage("Assets/img", sliderBase.Image);
                sliderBase.Image = sliderInput.Photo.SavePhoto("Assets/img", "slider");
            }

            sliderBase.TitleOne= sliderInput.TitleOne;
            sliderBase.TitleTwo= sliderInput.TitleTwo;
            sliderBase.UpdateAt = DateTime.Now;
         
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}