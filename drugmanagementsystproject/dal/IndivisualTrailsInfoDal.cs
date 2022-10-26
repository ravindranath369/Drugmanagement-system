using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using drugmanagementsystproject.Models;

namespace drugmanagementsystproject.dal
{
    public class IndivisualTrailsInfoDal
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

        public bool insertIndtrailInfo(IndivisualTrailsInfoModel dth)
        {
            dth.indivisualid = "indtr01" + GetId();
            connection();
            try
            {
                cmd = new SqlCommand("AddIndivTrailInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@indivisualid", dth.indivisualid);
                cmd.Parameters.AddWithValue("@indivisualname", dth.indivisualname);
                cmd.Parameters.AddWithValue("@indivisualadress", dth.indivisualadress);
                cmd.Parameters.AddWithValue("@phonennumber", dth.phonennumber);
                cmd.Parameters.AddWithValue("@emergencycontactnumber", dth.emergencycontactnumber);
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
            catch (Exception)
            {
                throw;
            }
        }
        public List<IndivisualTrailsInfoModel> getInditrailsinfo()
        {
            connection();
            List<IndivisualTrailsInfoModel> drugList = new List<IndivisualTrailsInfoModel>();
            SqlCommand cmd = new SqlCommand("GetIndTrailInfo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            connectionManager();
            sd.Fill(dt);
            connectionManager();

            foreach (DataRow dr in dt.Rows)
            {
                drugList.Add(
                new IndivisualTrailsInfoModel
                {
                    indivisualid = Convert.ToString(dr["indivisualid"]),
                    indivisualname = Convert.ToString(dr["indivisualname"]),
                    indivisualadress = Convert.ToString(dr["indivisualadress"]),
                    phonennumber = Convert.ToString(dr["phonennumber"]),
                    emergencycontactnumber = Convert.ToString(dr["emergencycontactnumber"]),
                    id = Convert.ToInt32(dr["id"])
                });
            }
            dt.Dispose();
            return drugList;
        }
        public int GetId()
        {
            int tempInt = 0;
            connection();
            SqlCommand cmd = new SqlCommand("GetIdForIndiTrailInfo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
            connectionManager();
            int i = cmd.ExecuteNonQuery();
            connectionManager();
            tempInt = Convert.ToInt32(cmd.Parameters["@id"].Value);
            return tempInt;
        }
        public IndivisualTrailsInfoModel getIndivTrailbyid(int id)
        {
            connection();
            IndivisualTrailsInfoModel Indivsual = new IndivisualTrailsInfoModel();
            SqlCommand cmd = new SqlCommand("GetIndiTrailById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@id", id);
            DataTable dt = new DataTable();
            connectionManager();
            sd.Fill(dt);
            connectionManager();
            if (dt.Rows.Count != 0)
            {
                Indivsual.id = Convert.ToInt32(dt.Rows[0]["id"]);
                Indivsual.indivisualid = Convert.ToString(dt.Rows[0]["indivisualid"]);
                Indivsual.indivisualname = Convert.ToString(dt.Rows[0]["indivisualname"]);
                Indivsual.indivisualadress = Convert.ToString(dt.Rows[0]["indivisualadress"]);
                Indivsual.phonennumber = Convert.ToString(dt.Rows[0]["phonennumber"]);
                Indivsual.emergencycontactnumber = Convert.ToString(dt.Rows[0]["emergencycontactnumber"]);
                dt.Dispose();
                return Indivsual;
            }
            dt.Dispose();
            return null;
        }
        public bool updateDetails(IndivisualTrailsInfoModel iti)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateIndiTraisDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", iti.id);
            cmd.Parameters.AddWithValue("@indivisualid", iti.indivisualid);
            cmd.Parameters.AddWithValue("@indivisualname", iti.indivisualname);
            cmd.Parameters.AddWithValue("@indivisualadress", iti.indivisualadress);
            cmd.Parameters.AddWithValue("@phonennumber", iti.phonennumber);
            cmd.Parameters.AddWithValue("@emergencycontactnumber", iti.emergencycontactnumber);
            
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
        public bool deleteIndiTrailInfo(int id)
        {
            connection();
            cmd = new SqlCommand("DeleteIndiTrailInfo", con);
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