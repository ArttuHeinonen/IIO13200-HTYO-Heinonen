using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harkka
{
    /// <summary>
    /// Model for population management
    /// </summary>
    public class Population
    {
        public int maxPopulation { get; set; }
        public int thinkers { get; set; }
        public int woodcutters { get; set; }
        public int foragers { get; set; }
        public int miners { get; set; }
        public int guards { get; set; }
        public int merchants { get; set; }
        public int priests { get; set; }
        public Population(int maxPopulation)
        {
            this.maxPopulation = maxPopulation;
            this.thinkers = maxPopulation;
        }
    }
}
