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
            t1.LeaderSince = 25;

            t2.Leader = d3;
            t2.LeaderSince = 0;

            // User Input
            string dwarfName;
            string weaponName;
            Random random;
            Dwarf dwarf;
            Weapon weapon;

            while (true)
            {
                // Output
                Console.Clear();
                Tribe.PrintTribes();
                Weapon.PrintWeapons();

                // User Input
                Console.Write("Enter Dwarf name (blank for a random dwarf): ");
                dwarfName = Console.ReadLine();

                Console.Write("Choose a weapon (blank for a random weapon): ");
                weaponName = Console.ReadLine();

                // Check input. If the input is blank, choose randomly
                if (dwarfName == string.Empty)
                {
                    random = new Random();
                    dwarfName = Dwarf.Dwarfs[random.Next(Dwarf.Dwarfs.Count)].Name;
                }

                if (weaponName == string.Empty)
                {
                    random = new Random();
                    weaponName = Weapon.Weapons[random.Next(Weapon.Weapons.Count)].Type;
                }

                // Find the object
                dwarf = Dwarf.Dwarfs.Find(x => x.Name == dwarfName);
                weapon = Weapon.Weapons.Find(y => y.Type == weaponName);

                // Check if the objects exists and give weapon
                if ((dwarf != null) && (weapon != null))
                {
                    dwarf.GiveWeapon(weapon);
                }
            }
        }
    }
}
