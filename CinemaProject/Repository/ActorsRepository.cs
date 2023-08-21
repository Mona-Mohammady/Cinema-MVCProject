

using CinemaProject.Data;
using CinemaProject.Models;
using CinemaProject.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CinemaProject.Repository
{
    public class ActorRepository : IActorsRepository
    {
        AppDBContext context; 

        public ActorRepository(AppDBContext context)
        {
            this.context = context;
        }
        public List<Actor> GetAll()
        {
            return context.Actors.ToList();
        }
        public Actor GetById(int id)
        {
            return context.Actors.FirstOrDefault(d => d.Id == id);
        }
        public Actor GetByName(string name)
        {
            return context.Actors.FirstOrDefault(d => d.FullName == name);
        }
        public void Add(Actor actor)
        {
            context.Actors.Add(actor);
        }
        public void Save()
        {

            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Actor oldact = GetById(id);
           
            context.Actors.Remove(oldact);


        }
        public void Update(Actor actor, int id)
        {
            Actor oldact = context.Actors.SingleOrDefault(d => d.Id == id);
            oldact.Id = id;
            oldact.FullName = actor.FullName;
            oldact.Image = actor.Image;
            oldact.Bio = actor.Bio;

        }

    }
}
