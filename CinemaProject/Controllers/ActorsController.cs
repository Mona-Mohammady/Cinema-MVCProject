using CinemaProject.Data;
using CinemaProject.Models;
using CinemaProject.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaProject.Controllers
{
    public class ActorsController : Controller
    {

      IActorsRepository ActRepo;

        public ActorsController(IActorsRepository actorRepository)
        {

            ActRepo = actorRepository;

        }
     
        public IActionResult Index()
        {


            List<Actor> actors = ActRepo.GetAll();
            return View(actors);

        }
     
        public IActionResult New()
        {
            //ViewData["Actlist"] = ActRepo.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult New(Actor newActor)
        {

            ActRepo.Add(newActor);
            ActRepo.Save();
            ViewData["Actlist"] = ActRepo.GetAll();
            return RedirectToAction("index");

        }

        public IActionResult Edit(int id)
        {
            Actor act = ActRepo.GetById(id);
            //  ViewData["emplist"] = EmpRepo.GetAll();

            return View(act);
        }
        [HttpPost]
        public IActionResult Edit(Actor act, int id)
        {
            //Employee emp= EmpRepo.GetById(id);

            //if(ModelState.IsValid ==true)

            ActRepo.Update(act, id);
            ActRepo.Save();
            return RedirectToAction("Index");

            // context.Entry(emp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

        }
        public IActionResult details(int id)
        {
            ViewData["Actlist"] = ActRepo.GetAll();
           Actor actor = ActRepo.GetById(id);
            return View(actor);
        }
        public IActionResult Delete(int id)
        {
            ActRepo.Delete(id);
            ActRepo.Save();
            return RedirectToAction("index");
        }


        //public async Task<IActionResult> Create(Actor actor)
        //{
        //    if (ModelState.IsValid)
        //    {
        //         actRepo.Add(actor);
        //        return RedirectToAction("Index");
        //    }
        //    else { return View(actor); }

        //}
    }
}
