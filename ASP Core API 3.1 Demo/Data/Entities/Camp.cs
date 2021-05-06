using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Core_API_3._1_Demo.Data.Entities
{
    public class Camp
    {
        public int CampId  { get; set; }
        public string Name { get; set; }
        public string Moniker { get; set; }
        public Location Location { get; set; }
        public DateTime EventDate { get; set; }
        public int Length { get; set; } = 1;
        public ICollection<Talk> Talks { get; set; }
    }
}
