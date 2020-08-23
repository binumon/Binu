using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Insurance.Bl;
using Insurance.Model;
using System.Net;
using System.Net.Http;
using InsuranceAPI;
using Newtonsoft.Json;
namespace Insurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        [Route("AddPlan")]
        [HttpPost]
        public HttpResponseMessage AddPlan(PlanModel Model)
        {
            try
            {
                PlanBl Bl = new PlanBl();
                int Status = Bl.AddPlan(Model);
                if (Status == 1)
                {
                    return new Response<string>("Added Succesfully", "", HttpStatusCode.Created);
                }
                else if (Status == 2)
                {
                    return new Response<string>("already exist", "", HttpStatusCode.Ambiguous);
                }
                else if (Status == 3)
                {
                    return new Response<string>("updated Successfully", "", HttpStatusCode.Created);
                }
                else if (Status == 4)
                {
                    return new Response<string>("Not found", "", HttpStatusCode.NotFound);
                }
                else
                {
                    return new Response<string>("Failed", "", HttpStatusCode.NotImplemented);
                }

            }
            catch (Exception ex)
            {
                return new Response<string>("Something went wrong", "", HttpStatusCode.ServiceUnavailable);
            }
        }

        [Route("UpdatePlan")]
        [HttpPost]
        public HttpResponseMessage UpdatePlan(PlanModel Model)
        {
            try
            {
                PlanBl Bl = new PlanBl();
                int Status = Bl.UpdatePlan(Model);
                if (Status == 1)
                {
                    return new Response<string>("Added Succesfully", "", HttpStatusCode.Created);
                }
                else if (Status == 2)
                {
                    return new Response<string>("already exist", "", HttpStatusCode.Ambiguous);
                }
                else if (Status == 3)
                {
                    return new Response<string>("updated Successfully", "", HttpStatusCode.Created);
                }
                else if (Status == 4)
                {
                    return new Response<string>("Not found", "", HttpStatusCode.NotFound);
                }
                else
                {
                    return new Response<string>("Failed", "", HttpStatusCode.NotImplemented);
                }

            }
            catch (Exception ex)
            {
                return new Response<string>("Something went wrong", "", HttpStatusCode.ServiceUnavailable);
            }
        }





        [Route("DeletePlan")]
        [HttpPost]
        public HttpResponseMessage DeletePlan(int Id)
        {
            try
            {
                PlanBl Bl = new PlanBl();
                int Status = Bl.DeletePlan(Id);
                return new Response<string>("Added Succesfully", "", HttpStatusCode.Gone);  
            }
            catch (Exception ex)
            {
                return new Response<string>("Something went wrong", "", HttpStatusCode.ServiceUnavailable);
            }
        }


        [Route("GetPlan")]
        [HttpGet]
        public HttpResponseMessage GetPlan()
        {
            try
            {
                PlanBl Bl = new PlanBl();
                List<PlanModel> Model = JsonConvert.DeserializeObject<List<PlanModel>>(Bl.GetPlan());
                return new Response<List<PlanModel>>("Data Listed Succesfully", Model, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new Response<string>("Something went wrong", "", HttpStatusCode.ServiceUnavailable);
            }
        }


    }
}
