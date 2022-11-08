using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using drugmanagementsystproject.Models;

namespace drugmanagementsystproject.dal
{
    public class DataAxcessingLayer
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


        public bool insertEmployee(EmployeeRegistrationModel employee)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@employeeid", employee.employeeid);
            cmd.Parameters.AddWithValue("@employeename", employee.employeename);
            cmd.Parameters.AddWithValue("@dob", employee.dob);
            cmd.Parameters.AddWithValue("@phonenumber", employee.phonenumber);
            cmd.Parameters.AddWithValue("@emailid", employee.emailid);
            cmd.Parameters.AddWithValue("@gender", employee.gender);
            cmd.Parameters.AddWithValue("@department", employee.department);
            cmd.Parameters.AddWithValue("@designation", employee.designation);
            cmd.Parameters.AddWithValue("@username", employee.username);
            cmd.Parameters.AddWithValue("@password", employee.password);
            cmd.Parameters.AddWithValue("@confirmpassword", employee.confirmpassword);
            cmd.Parameters.AddWithValue("@Employee", employee.Employee);
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


        public List<EmployeeRegistrationModel> getAllEmployees()
        {
            connection();
            List<EmployeeRegistrationModel> EmpList = new List<EmployeeRegistrationModel>();

            SqlCommand cmd = new SqlCommand("GetEmployees", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            connectionManager();
            sd.Fill(dt);
            connectionManager();

            foreach (DataRow dr in dt.Rows)
            {
                EmpList.Add(
                new EmployeeRegistrationModel
                {
                    employeeid = Convert.ToInt32(dr["employeeid"]),
                    employeename = Convert.ToString(dr["employeename"]),
                    dob = Convert.ToDateTime(dr["dob"]),
                    phonenumber = Convert.ToString(dr["phonenumber"]),
                    emailid = Convert.ToString(dr["emailid"]),
                    gender = Convert.ToString(dr["gender"]),
                    department = Convert.ToString(dr["department"]),
                    designation = Convert.ToString(dr["designation"]),
                    username = Convert.ToString(dr["username"]),
                    password = Convert.ToString(dr["password"]),
                    confirmpassword = Convert.ToString(dr["confirmpassword"]),
                    Employee = Convert.ToBoolean(dr["Employee"])

                });
            }

            dt.Dispose();
            return EmpList;
        }
        public bool updateDetails(EmployeeRegistrationModel employee)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateEmployeeDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@employeeid", employee.employeeid);
            cmd.Parameters.AddWithValue("@employeename", employee.employeename);
            cmd.Parameters.AddWithValue("@dob", employee.dob);
            cmd.Parameters.AddWithValue("@phonenumber", employee.phonenumber);
            cmd.Parameters.AddWithValue("@emailid", employee.emailid);
            cmd.Parameters.AddWithValue("@gender", employee.gender);
            cmd.Parameters.AddWithValue("@department", employee.department);
            cmd.Parameters.AddWithValue("@designation", employee.designation);
            cmd.Parameters.AddWithValue("@username", employee.username);
            cmd.Parameters.AddWithValue("@password", employee.password);
            cmd.Parameters.AddWithValue("@confirmpassword", employee.confirmpassword);
            //cmd.Parameters.AddWithValue("@Employee", employee.Employee);
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
        public bool deleteEmployee(int employeeid)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@employeeid", employeeid);
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

        public EmployeeRegistrationModel getEmployeeById(int employeeid)
        {
            connection();
            EmployeeRegistrationModel employee = new EmployeeRegistrationModel();

            SqlCommand cmd = new SqlCommand("GetEmployeeByid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@employeeid", employeeid);
            DataTable dt = new DataTable();
            connectionManager();
            sd.Fill(dt);
            connectionManager();
            if (dt.Rows.Count != 0)
            {
                employee.employeeid = Convert.ToInt32(dt.Rows[0]["employeeid"]);
                employee.employeename = Convert.ToString(dt.Rows[0]["employeename"]);
                employee.dob = Convert.ToDateTime(dt.Rows[0]["dob"]);
                employee.phonenumber = Convert.ToString(dt.Rows[0]["phonenumber"]);
                employee.emailid = Convert.ToString(dt.Rows[0]["emailid"]);
                employee.gender = Convert.ToString(dt.Rows[0]["gender"]);
                employee.department = Convert.ToString(dt.Rows[0]["department"]);
                employee.designation = Convert.ToString(dt.Rows[0]["designation"]);
                employee.username = Convert.ToString(dt.Rows[0]["username"]);
                employee.password = Convert.ToString(dt.Rows[0]["password"]);
                employee.confirmpassword = Convert.ToString(dt.Rows[0]["confirmpassword"]);
                // employee.Employee = Convert.ToBoolean(dt.Rows[0]["Employee"]);

                dt.Dispose();
                return employee;
            }
            dt.Dispose();
            return null;
        }
        public EmployeeRegistrationModel Getsingleuserdetail(string emailid)
        {
            connection();
            EmployeeRegistrationModel employee = new EmployeeRegistrationModel();
            SqlCommand cmd = new SqlCommand("GetSingleUserDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@emailid", emailid);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            connectionManager();
            sd.Fill(dt);
            connectionManager();
            if (dt.Rows.Count != 0)
            {
                employee.employeeid = Convert.ToInt32(dt.Rows[0]["employeeid"]);
                employee.employeename = Convert.ToString(dt.Rows[0]["employeename"]);
                employee.dob = Convert.ToDateTime(dt.Rows[0]["dob"]);
                employee.phonenumber = Convert.ToString(dt.Rows[0]["phonenumber"]);
                employee.emailid = Convert.ToString(dt.Rows[0]["emailid"]);
                employee.gender = Convert.ToString(dt.Rows[0]["gender"]);
                employee.department = Convert.ToString(dt.Rows[0]["department"]);
                employee.designation = Convert.ToString(dt.Rows[0]["designation"]);
                employee.username = Convert.ToString(dt.Rows[0]["username"]);
                employee.password = Convert.ToString(dt.Rows[0]["password"]);
                employee.confirmpassword = Convert.ToString(dt.Rows[0]["confirmpassword"]);
                employee.Employee = Convert.ToBoolean(dt.Rows[0]["Employee"]);
                dt.Dispose();
                return employee;
            }
            dt.Dispose();
            return null;
        }

        public EmployeeRegistrationModel GetEmployeeByResetPasswordCode(string code)
        {
            connection();
            EmployeeRegistrationModel employee = new EmployeeRegistrationModel();

            SqlCommand cmd = new SqlCommand("GetEmployeeByResetPasswordCode", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@resetcode", code);

            DataTable dt = new DataTable();
            connectionManager();
            sd.Fill(dt);
            connectionManager();
            if (dt.Rows.Count != 0)
            {

                employee.employeeid = Convert.ToInt32(dt.Rows[0]["employeeid"]);
                employee.employeename = Convert.ToString(dt.Rows[0]["employeename"]);
                employee.dob = Convert.ToDateTime(dt.Rows[0]["dob"]);
                employee.phonenumber = Convert.ToString(dt.Rows[0]["phonenumber"]);
                employee.emailid = Convert.ToString(dt.Rows[0]["emailid"]);
                employee.gender = Convert.ToString(dt.Rows[0]["gender"]);
                employee.department = Convert.ToString(dt.Rows[0]["department"]);
                employee.designation = Convert.ToString(dt.Rows[0]["designation"]);
                employee.username = Convert.ToString(dt.Rows[0]["username"]);
                employee.password = Convert.ToString(dt.Rows[0]["password"]);
                employee.confirmpassword = Convert.ToString(dt.Rows[0]["confirmpassword"]);
                employee.Employee = Convert.ToBoolean(dt.Rows[0]["Employee"]);

                dt.Dispose();
                return employee;
            }
            dt.Dispose();
            return null;

        }


        public bool AddResetPasswordCode(string resetcode, int employeeid)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddResetPasswordCode", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@resetcode", resetcode);
            cmd.Parameters.AddWithValue("@employeeid", employeeid);

            connectionManager();
            int i = cmd.ExecuteNonQuery();
            connectionManager();

            if (i >= 1)
                return true;
            else
                return false;
        }


        public bool UpdatePassword(string password, int employeeid)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdatePassword", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddWithValue("@employeeid", employeeid);

            connectionManager();
            int i = cmd.ExecuteNonQuery();
            connectionManager();

            if (i >= 1)
                return true;
            else
                return false;
        }

    }
}
