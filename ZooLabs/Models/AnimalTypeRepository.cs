using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ZooLabs.DAO;

namespace ZooLabs.Models
{
    public class AnimalTypeRepository : IRepository<AnimalType>
    {
        private ZooContext db;

        public AnimalTypeRepository(ZooContext context)
        {
            this.db = context;
        }

        public IEnumerable<AnimalType> GetAll()
        {
            return db.AnimalTypes;
        }

        public AnimalType Get(int id)
        {
            return db.AnimalTypes.Find(id);
        }

        public void Create(AnimalType type)
        {
            db.AnimalTypes.Add(type);
        }

        public void Update(AnimalType type)
        {
            db.Entry(type).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            AnimalType type = db.AnimalTypes.Find(id);
            if (type != null)
                db.AnimalTypes.Remove(type);
        }
    }
}
