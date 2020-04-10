using System;
using System.Collections.Generic;

namespace Dorfverwaltung
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tribes
            Tribe t1 = new Tribe() { Name = "Altobarden", ExistingSince = "1247 ndK" };
            Tribe t2 = new Tribe() { Name = "Elbknechte", ExistingSince = "1023 ndK" };

            // Weapons
            var w1 = new Weapon() { Type = "Axt", MagicValue = 12 };
            var w2 = new Weapon() { Type = "Schwert", MagicValue = 15 };
            var w3 = new Weapon() { Type = "Axt", MagicValue = 17 };
            var w4 = new Weapon() { Type = "Zauberstab", MagicValue = 45 };
            var w5 = new Weapon() { Type = "Streithammer", MagicValue = 15 };

            //Dwarfs
            var d1 = new Dwarf() { Name = "Gimli", Age = 140, Tribe = t1, Weapons = new List<Weapon>() { w1, w2 } };
            var d2 = new Dwarf() { Name = "Zwingli", Age = 70, Tribe = t1, Weapons = new List<Weapon>() { w3 } };
            var d3 = new Dwarf() { Name = "Gumli", Age = 163, Tribe = t2, Weapons = new List<Weapon>() { w4, w5 } };

            t1.Leader = d1;
            t1.LeaderSince = "25 years";

            t2.Leader = d3;
            t2.LeaderSince = "unknown";

            // User Input
            string dwarfName;
            string weaponName;
            while (true)
            {
                // Output
                Console.Clear();

                t1.printTribe();
                t2.printTribe();

                // List existing weapons
                Console.Write("Weapons:");
                foreach(var weapon in Weapon.Weapons)
                    Console.Write($" {weapon.Type}({weapon.MagicValue})");
                
                Console.WriteLine();
                Console.WriteLine();

                // User Input
                Console.Write("Enter Dwarf name: ");
                dwarfName = Console.ReadLine();

                Console.Write("Choose a weapon: ");
                weaponName = Console.ReadLine();

                // Simple input check
                if (dwarfName.Length == 0 || weaponName.Length == 0)
                    return;

                // Search for the dwarf give weapon
                foreach(var dwarf in Dwarf.Dwarfs)
                {
                    if(dwarf.Name == dwarfName)
                    {
                        foreach(var weapon in Weapon.Weapons)
                        {
                            if (weapon.Type == weaponName)
                            {
                                dwarf.giveWeapon(weapon);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
