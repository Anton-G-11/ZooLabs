using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ZooLabs.Models;

namespace ZooLabs.DAO
{
    public class ZooContext : DbContext
    {
        public ZooContext() : base ("DefaultConnection")
        {
            /*if (!AnimalTypes.Any())
            {
                AnimalTypes.Add(new AnimalType() { Name = "Fish" });
                AnimalTypes.Add(new AnimalType() { Name = "Reptile" });
                AnimalTypes.Add(new AnimalType() { Name = "Mammal" });
                SaveChanges();
            }
            if (!Cages.Any())
            {
                Cages.Add(new Cage { Name = "F1", Type = AnimalTypes.FirstOrDefault(a => a.Name == "Fish") });
                Cages.Add(new Cage { Name = "R1", Type = AnimalTypes.FirstOrDefault(a => a.Name == "Reptile") });
                Cages.Add(new Cage { Name = "M1", Type = AnimalTypes.FirstOrDefault(a => a.Name == "Mammal") });
                Cages.Add(new Cage { Name = "M2", Type = AnimalTypes.FirstOrDefault(a => a.Name == "Mammal") });
                SaveChanges();
            }
            if (!Animals.Any())
            {
                Animals.Add(new Animal { Name = "Trout", Age = 1, Feeding=(Feeding)2, Cage=Cages.Where(a=>a.Name=="F1").FirstOrDefault(), Type=AnimalTypes.Where(a => a.Name=="Fish").FirstOrDefault()} );
                Animals.Add(new Animal { Name = "Lizard", Age = 1, Feeding = (Feeding)1, Cage = Cages.Where(a => a.Name == "R1").FirstOrDefault(), Type = AnimalTypes.Where(a => a.Name == "Reptile").FirstOrDefault() });
                Animals.Add(new Animal { Name = "Tiger", Age = 1, Feeding = (Feeding)2, Cage = Cages.Where(a => a.Name == "M2").FirstOrDefault(), Type = AnimalTypes.Where(a => a.Name == "Mammal").FirstOrDefault() });
                SaveChanges();
            }*/
        }
        public DbSet <Animal> Animals { get; set; }
        public DbSet<AnimalType> AnimalTypes { get; set; }
        public DbSet<Cage> Cages { get; set; }
        public DbSet<Food> Foods { get; set; }


    }
}
