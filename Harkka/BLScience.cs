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

        public String GetRequirementsAsString(String name)
        {
            List<ReqResource> temp = new List<ReqResource>();

            switch (name)
            {
                case "Masonry":
                    temp = masonryReq;
                    break;
                case "Agriculture":
                    temp = agricultureReq;
                    break;
                default:
                    break;
            }

            String text = "";

            foreach (ReqResource req in temp)
            {
                text += "\n" + req.resName + "\t\t\t" + req.value;
            }
            return text;
        }
    }
}
