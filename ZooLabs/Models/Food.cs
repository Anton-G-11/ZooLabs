using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ZooLabs.Models
{
    public class Food : INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string name;
        private Feeding feeding;
        private AnimalType type;

        public int TypeId { get; set; }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
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



        public AnimalType Type
        {
            get { return type; }
            set
            {
                type = value;
                OnPropertyChanged("Type");
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
