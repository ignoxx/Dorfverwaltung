using System;
using System.Collections.Generic;

namespace Dorfverwaltung
{
    class Weapon
    {
        public static List<Weapon> Weapons = new List<Weapon>();

        public Weapon() => Weapons.Add(this);
        public string Type { get; set; }

        public int MagicValue { get; set; }

        public static void PrintWeapons()
        {
            Console.Write("Weapons:");
            foreach (var weapon in Weapon.Weapons)
                Console.Write($" {weapon.Type}({weapon.MagicValue})");

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
