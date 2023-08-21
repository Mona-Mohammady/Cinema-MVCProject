using CinemaProject.Data;
using CinemaProject.Models;
using CinemaProject.Repository.Interfaces;

namespace CinemaProject.Repository
{
    public class ProducerRepository : IProducerRepository
    {


        AppDBContext context;

        public ProducerRepository(AppDBContext context)
        {
            this.context = context;
        }
        public List<Producer> GetAll()
        {


            return context.Producers.ToList();
        }
        public Producer GetById(int id)
        {
            return context.Producers.FirstOrDefault(d => d.Id == id);
        }
        public Producer GetByName(string name)
        {
            return context.Producers.FirstOrDefault(d => d.FullName == name);
        }
        public void Add(Producer producer)
        {
            context.Producers.Add(producer);
        }
        public void Save()
        {

            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Producer oldpro = GetById(id);
            // oldemp.IsDeleted = true;
            context.Producers.Remove(oldpro);


        }
        public void Update(Producer producer, int id)
        {
            Producer oldpro = context.Producers.SingleOrDefault(d => d.Id == id);
            oldpro.Id = id;
            oldpro.FullName = producer.FullName;
            oldpro.Image = producer.Image;
            oldpro.Bio = producer.Bio;

        }
    }

    
}
