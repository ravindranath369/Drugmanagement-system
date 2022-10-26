using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using drugmanagementsystproject.Models;

namespace drugmanagementsystproject.dal
{
    public class AllergicInfoDal
    {
        private SqlConnection con;
        private void connection()
        {
            con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Drugsmanagementsystem;Integrated Security=True");
        }
        private void connectionManage()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            else
                con.Open();
        }

        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;

        public bool Insertdrug(AllergicInformationModel alleryomodel)
        {
            alleryomodel.allergyid = "Alg01" + GetId();
            connection();
            try
            {
                cmd = new SqlCommand("AddAlergy", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@allergyid", alleryomodel.allergyid);
                cmd.Parameters.AddWithValue("@allergyname", alleryomodel.allergyname);
                cmd.Parameters.AddWithValue("@isdrugundertrails", alleryomodel.isdrugundertrails);
                cmd.Parameters.AddWithValue("@anyallergyreaction", alleryomodel.anyallergyreaction);
                cmd.Parameters.AddWithValue("@differentsighnsandsympht", alleryomodel.differentsighnsandsympht);
                cmd.Parameters.AddWithValue("@antialergicmedicine", alleryomodel.antialergicmedicine);
                cmd.Parameters.AddWithValue("@id", alleryomodel.id);

                connectionManage();
                int r = cmd.ExecuteNonQuery();
                connectionManage();
                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<AllergicInformationModel> getAllAlergies()
        {
            connection();
            List<AllergicInformationModel> drugList = new List<AllergicInformationModel>();
            SqlCommand cmd = new SqlCommand("GetAlergies", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            connectionManage();
            sd.Fill(dt);
            connectionManage();

            foreach (DataRow dr in dt.Rows)
            {
                drugList.Add(
                new AllergicInformationModel
                {
                    allergyid = Convert.ToString(dr["allergyid"]),
                    allergyname = Convert.ToString(dr["allergyname"]),
                    isdrugundertrails = Convert.ToBoolean(dr["isdrugundertrails"]),
                    anyallergyreaction = Convert.ToBoolean(dr["anyallergyreaction"]),
                    differentsighnsandsympht = Convert.ToString(dr["differentsighnsandsympht"]),
                    antialergicmedicine = Convert.ToString(dr["antialergicmedicine"]),
                    Aid = Convert.ToInt32(dr["Aid"]),
                    id = Convert.ToInt32(dr["id"])
                }); ;
            }
            dt.Dispose();
            return drugList;
        }
        public int GetId()
        {
            int tempInt = 0;
            connection();
            SqlCommand cmd = new SqlCommand("GetIdForAllergyInfo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Aid", SqlDbType.Int).Direction = ParameterDirection.Output;
            connectionManage();
            int i = cmd.ExecuteNonQuery();
            connectionManage();
            tempInt = Convert.ToInt32(cmd.Parameters["@Aid"].Value);
            return tempInt;
        }
        public AllergicInformationModel getAlergyById(int Aid)
        {
            connection();
            AllergicInformationModel Alg = new AllergicInformationModel();
            SqlCommand cmd = new SqlCommand("GetAllergyByid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@Aid", Aid);
            DataTable dt = new DataTable();
            connectionManage();
            sd.Fill(dt);
            connectionManage();
            if (dt.Rows.Count != 0)
            {
                Alg.allergyid = Convert.ToString(dt.Rows[0]["allergyid"]);
                Alg.allergyname = Convert.ToString(dt.Rows[0]["allergyname"]);
                Alg.isdrugundertrails = Convert.ToBoolean(dt.Rows[0]["isdrugundertrails"]);
                Alg.anyallergyreaction = Convert.ToBoolean(dt.Rows[0]["anyallergyreaction"]);
                Alg.differentsighnsandsympht = Convert.ToString(dt.Rows[0]["differentsighnsandsympht"]);
                Alg.antialergicmedicine = Convert.ToString(dt.Rows[0]["antialergicmedicine"]);
                Alg.Aid = Convert.ToInt32(dt.Rows[0]["Aid"]);
                Alg.id = Convert.ToInt32(dt.Rows[0]["id"]);
                dt.Dispose();
                return Alg;
            }
            dt.Dispose();
            return null;
        }
        public bool updateDetails(AllergicInformationModel alleryomodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateAllergyDetails", con);
            cmd.Parameters.AddWithValue("@allergyid", alleryomodel.allergyid);
            cmd.Parameters.AddWithValue("@allergyname", alleryomodel.allergyname);
            cmd.Parameters.AddWithValue("@isdrugundertrails", alleryomodel.isdrugundertrails);
            cmd.Parameters.AddWithValue("@anyallergyreaction", alleryomodel.anyallergyreaction);
            cmd.Parameters.AddWithValue("@differentsighnsandsympht", alleryomodel.differentsighnsandsympht);
            cmd.Parameters.AddWithValue("@antialergicmedicine", alleryomodel.antialergicmedicine);
            cmd.Parameters.AddWithValue("@id", alleryomodel.id);

            connectionManage();
            int i = cmd.ExecuteNonQuery();
            connectionManage();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool deleteAllergy(int Aid)
        {
            connection();
            cmd = new SqlCommand("DeleteAllergy", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Aid", Aid);
            connectionManage();
            int r = cmd.ExecuteNonQuery();
            connectionManage();
            if (r > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}