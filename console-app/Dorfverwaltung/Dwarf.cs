using System.Collections.Generic;

namespace Dorfverwaltung
{
    class Dwarf
    {
        public static List<Dwarf> Dwarfs = new List<Dwarf>();

        private Tribe _tribe;
        private List<Weapon> _weapons = new List<Weapon>();

        public Dwarf() => Dwarfs.Add(this);
        

        public string Name { get; set; }
        public int Age { get; set; }
        public Tribe Tribe
        {
            get { return _tribe; }
            set
            {
                _tribe = value;
                _tribe.addMember(this);
            }
        }
        public int Force { get; set; }
        public List<Weapon> Weapons
        {
            get { return _weapons; }
            set
            {
                _weapons = value;
                foreach (var weapon in _weapons)
                {
                    this.Force += weapon.MagicValue;
                }
            }
        }

        public void giveWeapon(Weapon weapon)
        {
            this.Weapons.Add(weapon);
            this.Force += weapon.MagicValue;
        }
    }
}
