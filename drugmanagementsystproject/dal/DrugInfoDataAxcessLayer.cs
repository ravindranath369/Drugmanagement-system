using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using drugmanagementsystproject.Models;

namespace drugmanagementsystproject.dal
{
    public class DrugInfoDataAxcessLayer
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
        public bool Insertdrug(DrugInformationModel druginfomodel)
        {
            druginfomodel.drugid = "drg01" + GetId();
            connection();
            try
            {
                cmd = new SqlCommand("AddDrug", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@drugid", druginfomodel.drugid);
                cmd.Parameters.AddWithValue("@drugshortname", druginfomodel.drugshortname);
                cmd.Parameters.AddWithValue("@druglongname", druginfomodel.druglongname);
                cmd.Parameters.AddWithValue("@allergiesmaycauseonusage", druginfomodel.allergiesmaycauseonusage);

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
        public List<DrugInformationModel> getAllDrugs()
        {
            connection();
            List<DrugInformationModel> drugList = new List<DrugInformationModel>();
            SqlCommand cmd = new SqlCommand("GetDrugs", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            connectionManage();
            sd.Fill(dt);
            connectionManage();

            foreach (DataRow dr in dt.Rows)
            {
                drugList.Add(
                new DrugInformationModel
                {
                    id = Convert.ToInt32(dr["id"]),
                    drugid = Convert.ToString(dr["drugid"]),
                    drugshortname = Convert.ToString(dr["drugshortname"]),
                    druglongname = Convert.ToString(dr["druglongname"]),
                    allergiesmaycauseonusage = Convert.ToString(dr["allergiesmaycauseonusage"])
                });
            }
            dt.Dispose();
            return drugList;
        }
        public int GetId()
        {
            int tempInt = 0;
            connection();
            SqlCommand cmd = new SqlCommand("GetIdForDrugInfo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
            connectionManage();
            int i = cmd.ExecuteNonQuery();
            connectionManage();
            tempInt = Convert.ToInt32(cmd.Parameters["@id"].Value);
            return tempInt;
        }
        public DrugInformationModel getDrugById(int id)
        {
            connection();
            DrugInformationModel drug = new DrugInformationModel();

            SqlCommand cmd = new SqlCommand("GetDrugByid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@id", id);
            DataTable dt = new DataTable();
            connectionManage();
            sd.Fill(dt);
            connectionManage();
            if (dt.Rows.Count != 0)
            {
                drug.id = Convert.ToInt32(dt.Rows[0]["id"]);
                drug.drugid = Convert.ToString(dt.Rows[0]["drugid"]);
                drug.drugshortname = Convert.ToString(dt.Rows[0]["drugshortname"]);
                drug.druglongname = Convert.ToString(dt.Rows[0]["druglongname"]);
                drug.allergiesmaycauseonusage = Convert.ToString(dt.Rows[0]["allergiesmaycauseonusage"]);
                
                dt.Dispose();
                return drug;
            }
            dt.Dispose();
            return null;
        }
        public bool updateDetails(DrugInformationModel dim)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateDrugDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", dim.id);
            cmd.Parameters.AddWithValue("@drugid", dim.drugid);
            cmd.Parameters.AddWithValue("@drugshortname", dim.drugshortname);
            cmd.Parameters.AddWithValue("@druglongname", dim.druglongname);
            cmd.Parameters.AddWithValue("@allergiesmaycauseonusage", dim.allergiesmaycauseonusage);
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
        public bool deleteDrug(int id)
        {
            connection();
            cmd = new SqlCommand("DeleteDrug", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
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
