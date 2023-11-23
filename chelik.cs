using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testashota
{
    internal class chelik
    {
        public string Name;
        public double BukvyVsekundu;
        public int BukvyVminutu;
        public int Oshibki;

        public chelik(string name, int bukvyvminutu, double bukvyvsekundu, int oshibki)
        {
            Name = name;
            BukvyVsekundu = bukvyvsekundu;
            BukvyVminutu = bukvyvminutu;
            Oshibki = oshibki;
        }
    }
}
