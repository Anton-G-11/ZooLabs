using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ZooLabs.DAO;

namespace ZooLabs.Models
{
    public class AnimalRepository : IRepository<Animal>
    {
        private ZooContext db;

        public AnimalRepository(ZooContext context)
        {
            this.db = context;
        }

        public IEnumerable<Animal> GetAll()
        {
            return db.Animals.Include(a => a.AnimalType);
        }

        public Animal Get(int id)
        {
            return db.Animals.Find(id);
        }

        public void Create(Animal animal)
        {
            db.Animals.Add(animal);
        }

        public void Update(Animal animal)
        {
            db.Entry(animal).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Animal animal = db.Animals.Find(id);
            if (animal != null)
                db.Animals.Remove(animal);
        }
    }
}
