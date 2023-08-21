using CinemaProject.Models;

namespace CinemaProject.Repository.Interfaces
{
    public interface IProducerRepository
    {
        public List<Producer> GetAll();

        public Producer GetById(int id);

        public Producer GetByName(string name);

        public void Add(Producer producer);


        public void Save();

        public void Delete(int id);

        public void Update(Producer producer, int id);

    }
}
