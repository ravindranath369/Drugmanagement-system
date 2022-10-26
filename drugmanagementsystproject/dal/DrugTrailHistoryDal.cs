using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using drugmanagementsystproject.Models;

namespace drugmanagementsystproject.dal
{
    public class DrugTrailHistoryDal
    {
        private SqlConnection con;
        private void connection()
        {
            con = new SqlConnection("Data source=(localdb)\\MSSQLLocalDB;Initial Catalog=Drugsmanagementsystem;Integrated Security=true");
        }
        private void connectionManager()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            else
            {
                con.Open();
            }
        }
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;

        public bool Insertdrug(DrugTrailHistoryModel dth)
        {
            dth.drugtrailhistid = "dth01" + GetId();
            connection();
            try
            {
                cmd = new SqlCommand("AddDrugHist", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@drugtrailhistid", dth.drugtrailhistid);
                cmd.Parameters.AddWithValue("@drugname", dth.drugname);
                cmd.Parameters.AddWithValue("@numberofpartispants", dth.numberofpartispants);
                cmd.Parameters.AddWithValue("@numberofpeoplewithsideeffects", dth.numberofpeoplewithsideeffects);
                cmd.Parameters.AddWithValue("@numberofpeoplewithNoeffects", dth.numberofpeoplewithNoeffects);
                cmd.Parameters.AddWithValue("@sucesspercentageoftrails", dth.sucesspercentageoftrails);
                cmd.Parameters.AddWithValue("@comments", dth.comments);
                cmd.Parameters.AddWithValue("@finalresultofdrug", dth.finalresultofdrug);

                connectionManager();
                int r = cmd.ExecuteNonQuery();
                connectionManager();
                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                String msg = ex.Message;
                throw;
            }
        }
        public List<DrugTrailHistoryModel> getAllDrugs()
        {
            connection();
            List<DrugTrailHistoryModel> drugList = new List<DrugTrailHistoryModel>();
            SqlCommand cmd = new SqlCommand("GetDrugsHist", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            connectionManager();
            sd.Fill(dt);
            connectionManager();

            foreach (DataRow dr in dt.Rows)
            {
                drugList.Add(
                new DrugTrailHistoryModel
                {
                    id = Convert.ToInt32(dr["id"]),
                    drugtrailhistid = Convert.ToString(dr["drugtrailhistid"]),
                    drugname = Convert.ToString(dr["drugname"]),
                    numberofpartispants = Convert.ToInt32(dr["numberofpartispants"]),
                    numberofpeoplewithsideeffects = Convert.ToInt32(dr["numberofpeoplewithsideeffects"]),
                    numberofpeoplewithNoeffects = Convert.ToInt32(dr["numberofpeoplewithNoeffects"]),
                    sucesspercentageoftrails = Convert.ToInt32(dr["sucesspercentageoftrails"]),
                    comments = Convert.ToString(dr["comments"]),
                    finalresultofdrug = Convert.ToString(dr["finalresultofdrug"])
                });
            }
            dt.Dispose();
            return drugList;
        }
        public int GetId()
        {
            int tempInt = 0;
            connection();
            SqlCommand cmd = new SqlCommand("GetIdForDrugTrailHist", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
            connectionManager();
            int i = cmd.ExecuteNonQuery();
            connectionManager();
            tempInt = Convert.ToInt32(cmd.Parameters["@id"].Value);
            return tempInt;
        }
        public DrugTrailHistoryModel getDrughistbyid(int id)
        {
            connection();
            DrugTrailHistoryModel drug = new DrugTrailHistoryModel();
            SqlCommand cmd = new SqlCommand("GetDrugHistById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@id", id);
            DataTable dt = new DataTable();
            connectionManager();
            sd.Fill(dt);
            connectionManager();
            if (dt.Rows.Count != 0)
            {
                drug.id = Convert.ToInt32(dt.Rows[0]["id"]);
                drug.drugtrailhistid = Convert.ToString(dt.Rows[0]["drugtrailhistid"]);
                drug.drugname = Convert.ToString(dt.Rows[0]["drugname"]);
                drug.numberofpartispants = Convert.ToInt32(dt.Rows[0]["numberofpartispants"]);
                drug.numberofpeoplewithsideeffects = Convert.ToInt32(dt.Rows[0]["numberofpeoplewithsideeffects"]);
                drug.numberofpeoplewithNoeffects = Convert.ToInt32(dt.Rows[0]["numberofpeoplewithNoeffects"]);
                drug.sucesspercentageoftrails = Convert.ToInt32(dt.Rows[0]["sucesspercentageoftrails"]);
                drug.comments = Convert.ToString(dt.Rows[0]["comments"]);
                drug.finalresultofdrug = Convert.ToString(dt.Rows[0]["finalresultofdrug"]);
                dt.Dispose();
                return drug;
            }
            dt.Dispose();
            return null;
        }
        public bool updateDetails(DrugTrailHistoryModel dth)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateDrugHistDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", dth.id);
            cmd.Parameters.AddWithValue("@drugtrailhistid", dth.drugtrailhistid);
            cmd.Parameters.AddWithValue("@drugname", dth.drugname);
            cmd.Parameters.AddWithValue("@numberofpartispants", dth.numberofpartispants);
            cmd.Parameters.AddWithValue("@numberofpeoplewithsideeffects", dth.numberofpeoplewithsideeffects);
            cmd.Parameters.AddWithValue("@numberofpeoplewithNoeffects", dth.numberofpeoplewithNoeffects);
            cmd.Parameters.AddWithValue("@sucesspercentageoftrails", dth.sucesspercentageoftrails);
            cmd.Parameters.AddWithValue("@comments", dth.comments);
            cmd.Parameters.AddWithValue("@finalresultofdrug", dth.finalresultofdrug);
            connectionManager();
            int i = cmd.ExecuteNonQuery();
            connectionManager();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool deleteDrugHist(int id)
        {
            connection();
            cmd = new SqlCommand("DeleteDrugHist", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            connectionManager();
            int r = cmd.ExecuteNonQuery();
            connectionManager();
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
