using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_SuperHero
{
    class Program
    {
        static void Main(string[] args)
        {
            Person joe = new Person("Joe Black", "Joey");
            Person sue = new Person("Susette James", "Sue");
            Person ben = new Person("Ben Vicks", "Benny");

            SuperHero spidey = new SuperHero("Spider-Man", "Peter Parker", "Super Strength and Agility");
            SuperHero batey = new SuperHero("Batman", "Bruce Wayne", "Smart and Wealthy");
            SuperHero wolv = new SuperHero("Wolverine", "Logan", "Super Healing");

            Villain joke = new Villain("Joker", "Batman");
            Villain pin = new Villain("Kingpin", "Spider-Man");
            Villain rev = new Villain("Reverse Flash", "The Flash");

            List<Person> diverse = new List<Person>();

            diverse.Add(joe);
            diverse.Add(sue);
            diverse.Add(ben);
            diverse.Add(spidey);
            diverse.Add(batey);
            diverse.Add(wolv);
            diverse.Add(joke);
            diverse.Add(pin);
            diverse.Add(rev);

            foreach (Person people in diverse)
            {
                Console.Write(people.name + ": ");
                people.PrintGreeting();
                Console.WriteLine("\n\n");
            }

            Console.ReadLine();
        }
    }

    class Person
    {
        public string name { get; private set; }
        public string nickname { get; private set; }

        public override string ToString()
        {
            return "\nThis person is " + name + ".";
        }

        public virtual void PrintGreeting()
        {
            Console.WriteLine("Hello, my name is {0}, you can call me {1}.", name, nickname);
        }

        public Person(string pName, string pNickName)
        {
            name = pName;
            nickname = pNickName;
        }
    }

    class SuperHero : Person
    {
        public string realName { get; private set; }
        public string superPower { get; private set; }

        public override void PrintGreeting()
        {
            Console.WriteLine("I am {0}. When I am {1}, ", realName, name);
            Console.WriteLine("my super power is {0}!", superPower);
        }
        public SuperHero(string sname, string rName, string sPower) : base(sname, null)
        {
            realName = rName;
            superPower = sPower;
        }
    }

    class Villain : Person
    {
        public string nemesis { get; private set; }

        public override void PrintGreeting()
        {
            Console.WriteLine("I am {0}! Have you seen {1}?", name, nemesis);
        }
        public Villain(string vname, string nName) : base(vname, null)
        {
            nemesis = nName;
        }

    }
}
