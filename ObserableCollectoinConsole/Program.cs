using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserableCollectoinConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Сделать коллекцию наблюдаемой и добавить в неё несколько объектов Person
            ObservableCollection<Person> people = new ObservableCollection<Person>()
            {
                new Person{FirstName ="Peter", LastName="Murphy", Age=52 },
                new Person{FirstName="Keven", LastName="Key", Age=48},
            };

            //Привязаться к событию CollectionChanged.
            people.CollectionChanged += People_CollectionChanged;

            Person person = new Person();

            person.Age = 26;
            person.FirstName = "Sealy";
            person.LastName = "Popaus";

            people.Add(person);
            people.Remove(person);

            ClassLog.Log("");

        }

        private static void People_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //Выяснить действие, которое привело к генерации события.
            Console.WriteLine("Action for this event:{0}", e.Action);

            //Было что-то удалено
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                Console.WriteLine("Here are the OLD items:");   // старые элементы 
                foreach (Person p in e.OldItems)
                {
                    Console.WriteLine(p.ToString());
                }
                Console.WriteLine();
            }
            //Было что-то добавлено
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                //Теперь вывести новые элементы, которые были вставлены
                Console.WriteLine("Here are the NEW item: ");   //новые элементы
                foreach (Person p in e.NewItems)
                {
                    Console.WriteLine(p.ToString());
                }
            }

            Console.WriteLine(sender.ToString());

            
        }

        //static ClassLog

        
    }
    public enum NotifyCollectionChangedAction
    {
        Add=0,
        Remove=1,
        Replace=2,
        Move=3,
        Reset=4,
    }
}
