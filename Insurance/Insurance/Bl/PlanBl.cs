using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Insurance.Dal;
using Insurance.Model;
namespace Insurance.Bl
{
    public class PlanBl
    {
        public int AddPlan(PlanModel Plan)
        {
            PlanDal Dal = new PlanDal();
            Dal.AddPlan(Plan);
            return 1;
        }


        
        public int UpdatePlan(PlanModel Plan)
        {
            PlanDal Dal = new PlanDal();
            Dal.UpdatePlan(Plan);
            return 1;
        }

        public int DeletePlan(int id)
        {
            PlanDal Dal = new PlanDal();
            Dal.DeletePlan(id);
            return 1;
        }
        
        public string GetPlan()
        {
            PlanDal Dal = new PlanDal();
           return Dal.GetPlan(); 
        }

    }
}
