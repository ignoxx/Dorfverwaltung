using System;
using System.Collections.Generic;

namespace Dorfverwaltung
{
    class Tribe
    {
        public static List<Tribe> Tribes = new List<Tribe>();
        private const float tax_rate = 2.125f;
        private int _force;

        public string Name { get; set; }
        public string ExistingSince { get; set; }
        private List<Dwarf> Members { get; set; } = new List<Dwarf>();
        public int Force
        {
            get => _force;
            set
            {
                _force = value;
                Tax = _force * tax_rate;
            }
        }
        public float Tax { get; set; }
        public Dwarf Leader { get; set; }
        public int LeaderSince { get; set; }

        public Tribe() => Tribes.Add(this);

        public void AddMember(Dwarf member)
        {
            Members.Add(member);
            this.Force += member.Force;
        }

        private void CalculateForce()
        {
            Force = 0;
            foreach (var member in Members)
                Force += member.Force;    
        }

        public static void PrintTribes()
        {
            foreach (var tribe in Tribe.Tribes)
                tribe.PrintTribe();
        }

        public void PrintTribe()
        {
            CalculateForce();

            Console.WriteLine($"-- {Name} --");
            Console.WriteLine($"\tExisting since: {ExistingSince}");
            Console.WriteLine($"\tLeader: {Leader.Name} since {LeaderSince} years");
            Console.WriteLine("\tMembers:");
            foreach (var member in Members)
            {
                Console.WriteLine($"\t\t - {member.Name}");
            }

            Console.WriteLine($"\tTaxes: {Tax} gold");
            Console.WriteLine($"\tTotal force: {Force}");
            Console.WriteLine();
        }
    }
}
