using System;
using System.Collections.Generic;

namespace Dorfverwaltung
{
    class Tribe
    {
        private const int tax_rate = 2125;
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
        public int Tax { get; set; }
        public Dwarf Leader { get; set; }
        public string LeaderSince { get; set; }

        public void addMember(Dwarf member)
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

        public void printTribe()
        {
            CalculateForce();

            Console.WriteLine($"-- {Name} --");
            Console.WriteLine($"\tExisting since: {ExistingSince}");
            Console.WriteLine($"\tLeader: {Leader.Name} since {LeaderSince}");
            Console.WriteLine("\tMembers:");
            foreach (var member in Members)
                Console.WriteLine($"\t\t - {member.Name}");

            Console.WriteLine($"\tTaxes: {Tax} gold");
            Console.WriteLine($"\tTotal force: {Force}");
            Console.WriteLine();
        }
    }
}
