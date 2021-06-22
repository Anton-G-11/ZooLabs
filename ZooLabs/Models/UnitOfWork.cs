using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooLabs.DAO;

namespace ZooLabs.Models
{
    public class UnitOfWork : IDisposable
    {
        private ZooContext db = new ZooContext();
        private AnimalRepository animalRepository;
        private AnimalTypeRepository animalTypeRepository;
        private CageRepository cageRepository;

        public AnimalRepository Animals
        {
            get
            {
                if (animalRepository == null)
                    animalRepository = new AnimalRepository(db);
                return animalRepository;
            }
        }

        public AnimalTypeRepository AnimalTypes
        {
            get
            {
                if (animalTypeRepository == null)
                    animalTypeRepository = new AnimalTypeRepository(db);
                return animalTypeRepository;
            }
        }

        public CageRepository Cages
        {
            get
            {
                if (cageRepository == null)
                    cageRepository = new CageRepository(db);
                return cageRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
