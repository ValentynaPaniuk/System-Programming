using System;

namespace TankLib
{
    public class Tank
    {
        static Random random = new Random();

        public string Name { get; set; }
        public int Ammunition { get; set; }
        public int Armor { get; set; }
        public int Maneuverability { get; set; }

        

        public Tank(string name)
        {
            Name = name;
            Ammunition = random.Next(0, 100);
            Armor = random.Next(0, 100);
            Maneuverability = random.Next(0, 100);
        }

        public override string ToString()
        {
            return this.Name + " / Amun = " +  this.Ammunition + " / Armor = " +  this.Armor + " / Speed = " +  this.Maneuverability;
        }

        public static Tank operator ^(Tank t1, Tank t2)
        {
            if (t1.Ammunition > t2.Ammunition && t1.Armor > t2.Armor)
                return t1;
            else if (t1.Ammunition > t2.Ammunition && t1.Maneuverability > t2.Maneuverability)
                return t1;
            else if (t1.Armor > t2.Armor && t1.Maneuverability > t2.Maneuverability)
                return t1;
            else return t2;
        }
    }
}
