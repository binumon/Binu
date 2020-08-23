using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance.Model
{
    public class PlanModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string Dob { get; set; }
        public string SaleDate { get; set; }
        public string CoveragePlan { get; set; }
        public decimal NetPrice { get; set; }
    }
}
