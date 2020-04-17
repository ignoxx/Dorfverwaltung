using System.Collections.Generic;

namespace Dorfverwaltung
{
    class Dwarf
    {
        public static List<Dwarf> Dwarfs = new List<Dwarf>();
        private List<Weapon> _weapons = new List<Weapon>();
        private Tribe _tribe;

        public Dwarf() => Dwarfs.Add(this);
        public string Name { get; set; }
        public int Age { get; set; }
        public Tribe Tribe
        {
            get { return _tribe; }
            set
            {
                _tribe = value;
                _tribe.AddMember(this);
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
        public void GiveWeapon(Weapon weapon)
        {
            this.Weapons.Add(weapon);
            this.Force += weapon.MagicValue;
        }
    }
}
