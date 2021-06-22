using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ZooLabs.Models
{
    public class Cage : INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string name;
        public AnimalType AnimalType { get; set; }

        public int? AnimalTypeId { get; set; }

        public string Name
        {
            get { return name; }
            set { name = value;
                OnPropertyChanged("Name");
            }
        }

        public List<Animal> Animals { get; set; }

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
