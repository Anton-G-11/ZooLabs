using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooLabs.Models;

namespace ZooLabs
{
    class ConsoleView
    {
        private ZooManager zoo;
        private Cage SelectedCage;
        private List<Cage> Cages;
        private List<Animal> AnimalsInCage;

        public void test ()
        {
            zoo.Test();
        }

        public ConsoleView()
        {
            zoo = new ZooManager();
            Cages = zoo.GetCages().ToList();
        }

        public void Start()
        {
            Console.WriteLine("Choose Cage to view");
            this.SeeCages();
            this.ChooseCage();
        }

        public void SeeCages()
        {
            foreach (Cage c in Cages)
            {
                Console.WriteLine((Cages.IndexOf(c) + 1) + ") " + c.Name + ", " + c.AnimalType + ";");
            }
        }

        public void SeeAnimalTypes()
        {
            List<AnimalType> Types = zoo.GetAnimalTypes().ToList();
            foreach (AnimalType t in Types)
            {
                Console.WriteLine((Types.IndexOf(t) + 1) + ") " + t.Name + ";");
            }
        }
        private void ChooseCage()
        {

            string o1 = Console.ReadLine();
            try
            {
                int o = Convert.ToInt32(o1);
                o--;
                SelectedCage = Cages[o];
                AnimalsInCage = zoo.GetAnimalsInCage(SelectedCage).ToList();
                this.SeeAnimals();
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid option. Try again.");
                this.ChooseCage();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid option. Try again.");
                this.ChooseCage();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid option. Try again.");
                this.ChooseCage();
            }

        }

        private void SeeAnimals()
        {
            Console.WriteLine("Animals in this Cage:");
            foreach (Animal a in AnimalsInCage)
            {
                Console.WriteLine((AnimalsInCage.IndexOf(a) + 1) + ") " + a.Name + ", " + a.Age + " years;");
            }
            Console.WriteLine("Choose Option:");
            Console.WriteLine("1) Add Animal;");
            Console.WriteLine("2) Remove Animal;");
            Console.WriteLine("3) See another Cage;");
            this.AnimalOptions();
        }

        private void AnimalOptions()
        {
            string o = Console.ReadLine();
            switch (o)
            {
                case "1":
                    this.AddAnimal();
                    break;
                case "2":
                    this.RemoveAnimal();
                    break;
                case "3":
                    this.Start();
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }

        private void AddAnimal()
        {
            try
            {
                Console.WriteLine("Enter Name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter Age:");
                int age = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Choose Feeding Type:");
                Console.WriteLine("1) Hebrivore");
                Console.WriteLine("2) Omnivore");
                Console.WriteLine("3) Carnivore");
                int f = Convert.ToInt32(Console.ReadLine());
                Feeding feeding = (Feeding)f;

                Console.WriteLine("Choose Cage to place the Animal into:");
                this.SeeCages();
                string c1 = Console.ReadLine();
                int c = Convert.ToInt32(c1);
                c--;
                Cage cage = Cages[c];

                Console.WriteLine("Choose Cage to place the Animal into:");
                this.SeeAnimalTypes();
                string t1 = Console.ReadLine();
                int t = Convert.ToInt32(t1);
                t--;
                AnimalType type = zoo.GetAnimalTypes().ToList()[t];

                Animal newAnimal = new Animal() { Name = name, Age = age, Feeding = feeding, Cage = cage, AnimalType = type };
                if (zoo.AddAnimal(newAnimal))
                {
                }
                else 
                {
                    Console.WriteLine("You can place animal only int a cage for that type of animals.");
                }
                this.SeeAnimals();

            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid option. Try again.");
                this.AddAnimal();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid option. Try again.");
                this.AddAnimal();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid option. Try again.");
                this.AddAnimal();
            }
        }

        private void RemoveAnimal()
        {
            Console.WriteLine("Choose Animal to Remove:");
            string o1 = Console.ReadLine();
            try
            {
                int o = Convert.ToInt32(o1);
                o--;
                zoo.RemoveAnimal(AnimalsInCage[o]);
                this.SeeAnimals();
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid option. Try again.");
                this.RemoveAnimal();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid option. Try again.");
                this.RemoveAnimal();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid option. Try again.");
                this.RemoveAnimal();
            }
        }

    }
}
