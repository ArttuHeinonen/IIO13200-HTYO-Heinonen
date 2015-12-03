using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harkka
{
    /// <summary>
    /// Model for science upgrades. True if science upgrade is aquired.
    /// </summary>
    public class Science
    {
        public bool masonry { get; set; }
        public bool agriculture { get; set; }

        public Science()
        {
            masonry = false;
            agriculture = false;
        }
    }
}
