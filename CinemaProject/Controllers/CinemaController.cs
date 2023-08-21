using CinemaProject.Models;
using CinemaProject.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Controllers
{
    public class CinemaController : Controller
    {
        ICinemaRepository CinRepo;

        public CinemaController(ICinemaRepository cinemaRepository)
        {

            CinRepo = cinemaRepository;

        }

        public IActionResult Index()
        {


            List<Cinema> cinemas = CinRepo.GetAll();
            return View(cinemas);

        }
        
        public IActionResult New()
        {
            ViewData["cinlist"] = CinRepo.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult New(Cinema newCinema)
        {

            CinRepo.Add(newCinema);
            CinRepo.Save();
            ViewData["cinlist"] = CinRepo.GetAll();
            return RedirectToAction("index");

        }

        public IActionResult Edit(int id)
        {
            Cinema cin = CinRepo.GetById(id);
            //  ViewData["emplist"] = EmpRepo.GetAll();

            return View(cin);
        }
        [HttpPost]
        public IActionResult Edit(Cinema Cin, int id)
        {
            //Employee emp= EmpRepo.GetById(id);

            //if(ModelState.IsValid ==true)

            CinRepo.Update(Cin, id);
            CinRepo.Save();
            return RedirectToAction("Index");

            // context.Entry(emp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

        }
        public IActionResult details(int id)
        {
            ViewData["cinlist"] = CinRepo.GetAll();
            Cinema cinema = CinRepo.GetById(id);
            return View(cinema);
        }
        public IActionResult Delete(int id)
        {
            CinRepo.Delete(id);
            CinRepo.Save();
            return RedirectToAction("index");
        }

        //public IActionResult Search(string Name)
        //{
        //    if (Name != "")
        //    {
        //        var empls = EmpRepo.(x => x.Name.ToLower().Contains(Name.ToLower())).ToList();
        //        return View("Index", empls);
        //    }
        //    else
        //    {
        //        var instructors = db.instructors.ToList();

        //        return View("Index", instructors);
        //    }

        //}
    }  }
