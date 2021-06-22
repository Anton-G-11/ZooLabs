using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data.Entity;
using System.Windows;
using ZooLabs.DAO;
using ZooLabs.Models;

namespace ZooWpf.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        private ZooContext db;


        public MainViewModel()
        {
            db = new ZooContext();
            Cages = db.Cages.Include(c => c.Animals).Include(c => c.AnimalType).ToList();
            SelectedCage = Cages[0];
            FeedingList = new List<string>();
            FillFeeding();
        }

        private Cage selectedCage;
        private Animal selectedAnimal;

        public List <Cage> Cages { get; set; }
        
                

        public List<Animal> AnimalsInCage
        {
            get
            {
                return db.Animals.Where(a => a.CageId == selectedCage.Id).Include(a => a.Cage).Include(a => a.AnimalType).ToList();
            }
        }

        public List<AnimalType> Types
        {
            get 
            {
                return db.AnimalTypes.ToList();
            }
        }

        public Cage SelectedCage
        {
            get { return selectedCage; }
            set
            {
                selectedCage = value;
                OnPropertyChanged("SelectedCage");
                OnPropertyChanged("AnimalsInCage");
            }
        }
        public Animal SelectedAnimal
        {
            get { return selectedAnimal; }
            set
            {
                selectedAnimal = value;
                OnPropertyChanged("SelectedAnimal");
            }
        }

        private string newName;
        private int newAge;
        private Cage newCage;
        private AnimalType newType;
        private string newFeeding;

        public List<string> FeedingList { get; set; }

        private void FillFeeding()
        {
            int i = 0;
            while(i<3)
            {
                Feeding f = (Feeding)i;
                FeedingList.Add(f.ToString());
                OnPropertyChanged("FeedingList");
                i++;
            }

        }

        public string NewName
        {
            get { return newName; }
            set
            {
                newName = value;
                OnPropertyChanged("newName");
            }
        }

        public int NewAge
        {
            get { return newAge; }
            set
            {
                newAge = value;
                OnPropertyChanged("newName");
            }
        }

        public Cage NewCage
        {
            get { return newCage; }
            set
            {
                newCage = value;
                OnPropertyChanged("NewCage");
            }
        }
        public AnimalType NewType
        {
            get { return newType; }
            set
            {
                newType = value;
                OnPropertyChanged("NewType");
            }
        }
        public string NewFeeding
        {
            get { return newFeeding; }
            set
            {
                newFeeding = value;
                OnPropertyChanged("NewFeeding");
            }
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      
                      int i = FeedingList.IndexOf(NewFeeding);
                      Feeding f = (Feeding) i;
                      Animal animal = new Animal { Name = newName, Age = newAge, Feeding = f, Cage = newCage, AnimalType = newType };
                      if (animal.AnimalType != animal.Cage.AnimalType)
                      {
                          MessageBox.Show("Animal Type of the new animal should be the same as of the cage;");
                      }
                      else
                      {
                          db.Animals.Add(animal);
                          db.SaveChanges();
                      }

                      OnPropertyChanged("AnimalsInCage");
                  }));
            }
        }

        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand(obj =>
                  {
                      db.Animals.Remove(SelectedAnimal);
                      db.SaveChanges();

                      OnPropertyChanged("AnimalsInCage");
                  }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
