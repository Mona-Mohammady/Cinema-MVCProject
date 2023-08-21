using CinemaProject.Data;
using CinemaProject.Models;
using CinemaProject.Repository.Interfaces;

namespace CinemaProject.Repository
{
    public class CinemaRespository :ICinemaRepository
    {
        AppDBContext context;

        public CinemaRespository(AppDBContext context)
        {
            this.context = context;
        }

        public List<Cinema> GetAll()
            {


                return context.Cinemas.ToList();
            }
            public Cinema GetById(int id)
            {
                return context.Cinemas.FirstOrDefault(d => d.Id == id);
            }
            public Cinema GetByName(string name)
            {
                return context.Cinemas.FirstOrDefault(d => d.C_Name == name);
            }
            public void Add(Cinema cinema)
            {
                context.Cinemas.Add(cinema);
            }
            public void Save()
            {

                context.SaveChanges();
            }
            public void Delete(int id)
            {
                Cinema oldcin = GetById(id);
                // oldemp.IsDeleted = true;
                context.Cinemas.Remove(oldcin);


            }
            public void Update(Cinema cinema, int id)
            {
                Cinema oldcin = context.Cinemas.SingleOrDefault(d => d.Id == id);
                oldcin.Id = id;
                oldcin.C_Name = cinema.C_Name;
                oldcin.Desc = cinema.Desc;
                oldcin.Logo = cinema.Logo;

            }
        }


    }
