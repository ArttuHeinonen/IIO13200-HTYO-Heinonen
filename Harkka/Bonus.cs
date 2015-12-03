using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harkka
{
    /// <summary>
    /// Model for different bonuses
    /// </summary>
    public class Bonus
    {
        public float scienceBonus { get; set; }
        public float religionBonus { get; set; }
        public float mineBonus { get; set; }

        public float foodBonus { get; set; }
        public Bonus()
        {
            scienceBonus = 1;
            religionBonus = 1;
            mineBonus = 1;
            foodBonus = 1;
        }
    }
}
