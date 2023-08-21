using CinemaProject.Data;
using CinemaProject.Data.Enums;
using CinemaProject.Models;
using CinemaProject.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CinemaProject.Controllers
{
    [Authorize(Roles = "Admin")]

    public class MoviesController : Controller
    {
        IMovieRepository MovRepo;
        IProducerRepository ProRepo;
        ICinemaRepository CinemaRepo;

        public MoviesController(IMovieRepository _MovRepo, ICinemaRepository _CinemaRepo, IProducerRepository _ProRepo)
        {

            MovRepo = _MovRepo;
            ProRepo = _ProRepo;
            CinemaRepo = _CinemaRepo;

        }
        [AllowAnonymous]
        public IActionResult Index()
        {


            List<Movie> movies = MovRepo.GetAll();

            return View(movies);

        }
        public IActionResult AdminMovie()
        {


            List<Movie> movies = MovRepo.GetAll();

            return View(movies);

        }

        public IActionResult New()
        {
            ViewData["ProducerList"] = ProRepo.GetAll();
            ViewData["CinemaList"] = CinemaRepo.GetAll();
           

            return View();
        }
        [HttpPost]
        public IActionResult New(Movie newMovie)
        {

            MovRepo.Add(newMovie);
            MovRepo.Save();
            ViewData["Movlist"] = MovRepo.GetAll();
            return RedirectToAction("AdminMovie");

        }

        public IActionResult Edit(int id)
        {
           Movie mov = MovRepo.GetById(id);
            ViewData["ProducerList"] = ProRepo.GetAll();
            ViewData["CinemaList"] = CinemaRepo.GetAll();


            return View(mov);
        }
        [HttpPost]
        public IActionResult Edit(Movie mov, int id)
        {
            //Employee emp= EmpRepo.GetById(id);

            //if(ModelState.IsValid ==true)

            MovRepo.Update(mov, id);
            MovRepo.Save();
            return RedirectToAction("AdminMovie");

            // context.Entry(emp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

        }

        [AllowAnonymous]

        public IActionResult details(int id)
        {
            ViewData["Movlist"] = MovRepo.GetAll();
            Movie movie = MovRepo.GetById(id);
            return View(movie);
        }
        public IActionResult Delete(int id)
        {
            MovRepo.Delete(id);
            MovRepo.Save();
            return RedirectToAction("index");
        }
        [AllowAnonymous]

        public IActionResult Search(string Name)
        {
            if (Name != "")
            {
                var mov = MovRepo.Search(Name);
                return View("Index", mov);
            }
            else
            {
                var movie = MovRepo.GetAll();
                return View("Index", movie);
            }
        }
    }
}
