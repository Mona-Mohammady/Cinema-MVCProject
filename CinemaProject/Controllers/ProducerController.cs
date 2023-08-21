using CinemaProject.Models;
using CinemaProject.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Controllers
{

    public class ProducerController : Controller
    {
        IProducerRepository ProRepo;

        public ProducerController(IProducerRepository producerRepository)
        {

            ProRepo = producerRepository;

        }
        //public EmployeeController (IEmployeeRepository EmpRepo)
        //{

        //}
        public IActionResult Index()
        {


            List<Producer> producers = ProRepo.GetAll();
            return View(producers);

        }
        //public IActionResult getall()
        //{


        //    list<Employee> list = EmpRepo.GetAll();
        //    return view(list);
        //}
        public IActionResult New()
        {
            ViewData["Prolist"] = ProRepo.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult New(Producer newProducer)
        {

            ProRepo.Add(newProducer);
            ProRepo.Save();
            ViewData["Prolist"] = ProRepo.GetAll();
            return RedirectToAction("index");

        }

        public IActionResult Edit(int id)
        {
            Producer pro = ProRepo.GetById(id);
            //  ViewData["emplist"] = EmpRepo.GetAll();

            return View(pro);
        }
        [HttpPost]
        public IActionResult Edit(Producer Pro, int id)
        {
            //Employee emp= EmpRepo.GetById(id);

            //if(ModelState.IsValid ==true)

            ProRepo.Update(Pro, id);
            ProRepo.Save();
            return RedirectToAction("Index");

            // context.Entry(emp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

        }
        public IActionResult details(int id)
        {
            ViewData["Prolist"] = ProRepo.GetAll();
            Producer producer = ProRepo.GetById(id);
            return View(producer);
        }
        public IActionResult Delete(int id)
        {
            ProRepo.Delete(id);
            ProRepo.Save();
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

   }
}
