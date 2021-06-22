using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ZooLabs.DAO;

namespace ZooLabs.Models
{
    public class CageRepository : IRepository<Cage>
    {
        private ZooContext db;

        public CageRepository(ZooContext context)
        {
            this.db = context;
        }

        public IEnumerable<Cage> GetAll()
        {
            return db.Cages.Include(c => c.Animals).Include(c => c.AnimalType);
        }

        public Cage Get(int id)
        {
            return db.Cages.Find(id);
        }

        public void Create(Cage cage)
        {
            db.Cages.Add(cage);
        }

        public void Update(Cage cage)
        {
            db.Entry(cage).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Cage cage = db.Cages.Find(id);
            if (cage != null)
                db.Cages.Remove(cage);
        }
    }
}
