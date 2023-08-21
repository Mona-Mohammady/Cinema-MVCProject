using CinemaProject.Models;
using System.Threading.Tasks;

namespace CinemaProject.Repository.Interfaces
{
    public interface IActorsRepository
    {
        public List<Actor> GetAll();

        public Actor GetById(int id);

        public Actor GetByName(string name);

        public void Add(Actor actor);


        public void Save();

        public void Delete(int id);

        public void Update(Actor actor, int id);
    }
}
