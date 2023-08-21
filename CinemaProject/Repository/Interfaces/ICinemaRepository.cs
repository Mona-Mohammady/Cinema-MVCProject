using CinemaProject.Models;

namespace CinemaProject.Repository.Interfaces
{
    public interface ICinemaRepository
    {
        
        
            public List<Cinema> GetAll();

            public Cinema GetById(int id);

            public Cinema GetByName(string name);

            public void Add(Cinema cinema);


            public void Save();

            public void Delete(int id);

            public void Update(Cinema cinema, int id);


        }
    }
