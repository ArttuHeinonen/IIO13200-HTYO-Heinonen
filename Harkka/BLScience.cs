using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harkka
{
    /// <summary>
    /// Business logic handling science upgrades
    /// </summary>
    public class BLScience
    {
        Science sci = new Science();
        List<ReqResource> masonryReq = new List<ReqResource>();
        List<ReqResource> agricultureReq = new List<ReqResource>();

        public BLScience()
        {
            InitializeScienceRequirements();
        }

        private void InitializeScienceRequirements()
        {
            masonryReq.Add(new ReqResource("Science", 100, 1));
            agricultureReq.Add(new ReqResource("Stone", 10, 1));
            agricultureReq.Add(new ReqResource("Science", 150, 1));
        }
    }
}
