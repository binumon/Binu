using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Insurance.Model;

namespace Insurance.Dal
{
    public class PlanDal
    {

        
        
        
        public int AddPlan(PlanModel Plan)
        {
            int returnvalue = 1;
            using (SqlConnection con = new SqlConnection(AppConfiguration.Get()))
            {
                SqlCommand cmd = new SqlCommand("AddContract", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = 0;
                cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 100)).Value = Plan.Name;
                cmd.Parameters.Add(new SqlParameter("@Address", SqlDbType.VarChar, 100)).Value = Plan.Address;
                cmd.Parameters.Add(new SqlParameter("@Country", SqlDbType.VarChar, 100)).Value = Plan.Country;
                cmd.Parameters.Add(new SqlParameter("@Gender", SqlDbType.VarChar, 5)).Value = Plan.Gender;
                cmd.Parameters.Add(new SqlParameter("@DOB", SqlDbType.DateTime)).Value = Plan.Dob;
                cmd.Parameters.Add(new SqlParameter("@SaleDate", SqlDbType.DateTime)).Value = Plan.SaleDate;
                //SqlParameter retval = cmd.Parameters.Add("return", SqlDbType.Int);
                //retval.Direction = ParameterDirection.ReturnValue;
                con.Open();
                cmd.ExecuteNonQuery();
                //returnvalue = int.Parse(retval.Value.ToString());
                con.Close();
                return returnvalue;
            }
        }


        public int UpdatePlan(PlanModel Plan)
        {
            int returnvalue = 1;
            using (SqlConnection con = new SqlConnection(AppConfiguration.Get()))
            {
                SqlCommand cmd = new SqlCommand("AddContract", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = Plan.Id;
                cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 100)).Value = Plan.Name;
                cmd.Parameters.Add(new SqlParameter("@Address", SqlDbType.VarChar, 100)).Value = Plan.Address;
                cmd.Parameters.Add(new SqlParameter("@Country", SqlDbType.VarChar, 100)).Value = Plan.Country;
                cmd.Parameters.Add(new SqlParameter("@Gender", SqlDbType.VarChar, 5)).Value = Plan.Gender;
                cmd.Parameters.Add(new SqlParameter("@DOB", SqlDbType.DateTime)).Value = Plan.Dob;
                cmd.Parameters.Add(new SqlParameter("@SaleDate", SqlDbType.DateTime)).Value = Plan.SaleDate;
                //SqlParameter retval = cmd.Parameters.Add("return", SqlDbType.Int);
                //retval.Direction = ParameterDirection.ReturnValue;
                con.Open();
                cmd.ExecuteNonQuery();
               // returnvalue = int.Parse(retval.Value.ToString());
                con.Close();
                return returnvalue;
            }
        }


        public int DeletePlan(int Id)
        {
            int returnvalue = 1;
            using (SqlConnection con = new SqlConnection(AppConfiguration.Get()))
            {
                SqlCommand cmd = new SqlCommand("DeletePlan", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = Id;
                con.Open();
                cmd.ExecuteNonQuery();
                // returnvalue = int.Parse(retval.Value.ToString());
                con.Close();
                return returnvalue;
            }
        }

        public string GetPlan()
        {
            using (SqlConnection con = new SqlConnection(AppConfiguration.Get()))
            {
                SqlCommand cmd = new SqlCommand("GetPlan", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                var jsonResult = new StringBuilder();
                if (!reader.HasRows)
                {
                    jsonResult.Append("[]");
                }
                else
                {
                    while (reader.Read())
                    {
                        jsonResult.Append(reader.GetValue(0).ToString());
                    }
                }
                con.Close();
                return jsonResult.ToString();
            }
        }
    }
}
