using WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private КиноEntities _db = new КиноEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View(_db.Films.ToList());

        }
   
        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "ID")] Films filmsToCreate)
        {
            if (!ModelState.IsValid)
                return View();
            _db.Films.Add(filmsToCreate);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Home/Edit/
        public ActionResult Edit(int id)
        {
            var filmsToEdit = (from m in _db.Films
                               where m.NumberFilm == id
                               select m).First();
            return View(filmsToEdit);

        }

        // POST: Home/Edit/
        [HttpPost]
        public ActionResult Edit(Films filmsToEdit)
        {
            var originalFilms = (from m in _db.Films
                                 where m.NumberFilm == filmsToEdit.NumberFilm
                                 select m).First();
            if (!ModelState.IsValid)
                return View(originalFilms);
            _db.Entry(originalFilms).CurrentValues.SetValues(filmsToEdit);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        // GET: Home/Delete
        public ActionResult Delete(int id)
        {
            var filmsToDelete = (from m in _db.Films
                               where m.NumberFilm == id
                               select m).First();
            return View(filmsToDelete);

        }

        // POST: Home/Delete
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var filmsToDelete = (from m in _db.Films
                                 where m.NumberFilm == id
                                 select m).First();
            try
            {
                _db.Films.Remove(filmsToDelete);
                _db.SaveChanges();
                // TODO: Add delete logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View(filmsToDelete);
            }

        }
    }
}


    
