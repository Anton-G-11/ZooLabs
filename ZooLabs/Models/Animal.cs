using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ZooLabs.Models
{
    public enum Feeding 
    { 
        [Description("Herbivore")]
        Herbivore,
        [Description("Omnivore")]
        Omnivore,
        [Description("Carnivore")]
        Carnivore 
    }

    public class Animal : INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string name;
        private int age;
        public AnimalType AnimalType { get; set; }
        private Feeding feeding;
        public Cage Cage { get; set; }

        public int? AnimalTypeId { get; set; }
        public int? CageId { get; set; }

        public Animal ()
        {
            Name = "New Animal";
            Age = 0;
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                OnPropertyChanged("Age");
            }
        }

        public Feeding Feeding
        {
            get { return feeding; }
            set
            {
                feeding = value;
                OnPropertyChanged("Feeding");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
