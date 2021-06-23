using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ZooLabs.DAO;
using ZooLabs.Models;

namespace ZooLabs
{
    class ZooManager
    {
        private ZooContext db;

        

        public ZooManager ()
        {
            db = new ZooContext();
        }
        public void Test()
        {
            Animal a = db.Animals.Find(4);
            Console.WriteLine(a);
            Console.WriteLine(a.Cage);
            Console.WriteLine(a.AnimalType);
            Cage c = db.Cages.Find(9);
            Console.WriteLine(c.AnimalTypeId);
        }
        public bool AddAnimal (Animal a)
        {
            if (a.AnimalType != a.Cage.AnimalType) return false;

            db.Animals.Add(a);
            db.SaveChanges();
            return true;
        }
        public void RemoveAnimal(Animal a)
        {
            db.Animals.Remove(a);
            db.SaveChanges();
        }
        public IEnumerable<Cage> GetCages()
        {
            return db.Cages.Include(c => c.Animals).Include(c=>c.AnimalType);
        }
        public IEnumerable<Animal> GetAnimalsInCage (Cage c)
        {
            return db.Animals.Where(a => a.CageId==c.Id).Include(a => a.AnimalType).Include(a=>a.Cage);
        }
        public IEnumerable<AnimalType> GetAnimalTypes()
        {
            return db.AnimalTypes;
        }
    }
}
