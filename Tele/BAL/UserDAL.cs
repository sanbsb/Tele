using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Tele.Models;
namespace Tele.BAL
{
    public class UserDAL
    {
        string connection = System.Configuration.ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
        //public IEnumerable<Details> GetAllData()
        //{
        //    List<Details> emp = new List<Details>();
        //    using (SqlConnection cn = new SqlConnection(connection))
        //    {
        //        SqlCommand cm = new SqlCommand("Usp_InsertUpdateDelete", cn);
        //        cm.Parameters.AddWithValue("@ID", 0);
        //        cm.Parameters.AddWithValue("@Name", "");
        //        cm.Parameters.AddWithValue("@Address", "");
        //        cm.Parameters.AddWithValue("@Mobile_no", 0);
        //        cm.Parameters.AddWithValue("@Status", "All");

        //        cm.CommandType = CommandType.StoredProcedure;
        //        cn.Open();
        //        SqlDataReader dr = cm.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            Details e = new Details();
        //            e.id = Convert.ToInt32(dr["Id"]);
        //            e.name = Convert.ToString(dr["Name"]);
        //            e.address = Convert.ToString(dr["Address"]);
        //            e.mobile_no = Convert.ToInt32(dr["Mobile_no"]);
        //            emp.Add(e);
        //        }
        //        cn.Close();
        //        return emp;
        //    }
        //}

        public void Insert(User st)
        {
            using (SqlConnection cn = new SqlConnection(connection))
            {
                SqlCommand cm = new SqlCommand("Usp_InsertUpdateDelete", cn);
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.AddWithValue("@Name", st.UserName);
                cm.Parameters.AddWithValue("@Email", st.Email);
                cm.Parameters.AddWithValue("@Address", st.Address);
                cm.Parameters.AddWithValue("@Mobile_no", st.Phone);
                cm.Parameters.AddWithValue("@Status", "Insert");
                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();
            }

        }

        public void Registration(User st)
        {
            using (SqlConnection cn = new SqlConnection(connection))
            {
                SqlCommand cm = new SqlCommand("User_Registration", cn);
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.AddWithValue("@Name", st.UserName);
                cm.Parameters.AddWithValue("@Email", st.Email);
                cm.Parameters.AddWithValue("@Address", st.Address);
                cm.Parameters.AddWithValue("@Mobile_no", st.Phone);
                cm.Parameters.AddWithValue("@status", st.Status);
                cm.Parameters.AddWithValue("@Password", st.Password);
                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();
            }

        }
        public List<User> GetUserList(User userdetails, string action, string username = "")
        {
            List<User> li = new List<User>();
            using (SqlConnection cn = new SqlConnection(connection))
            {
                SqlCommand cm = new SqlCommand("UserList", cn);
                cm.Parameters.AddWithValue("@username", username);
                cm.Parameters.AddWithValue("@Action", action);

                cm.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    User e = new User();
                    e.UserName = Convert.ToString(dr["username"]);
                    e.Email = Convert.ToString(dr["emaiid"]);
                    e.Phone = Convert.ToString(dr["phoneno"]);
                    e.Address = Convert.ToString(dr["address"]);
                    e.Status = Convert.ToString(dr["status"]);
                    li.Add(e);
                }
                cn.Close();
                return li;
            }
        }
        public User GetUserDetails(User userdetails, string action, string username = "")
        {
            User e = new User();
            using (SqlConnection cn = new SqlConnection(connection))
            {
                SqlCommand cm = new SqlCommand("UserList", cn);
                cm.Parameters.AddWithValue("@username", username);
                cm.Parameters.AddWithValue("@Action", action);

                cm.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {

                    e.UserNameForUpdate = Convert.ToString(dr["username"]);
                    e.Email = Convert.ToString(dr["emaiid"]);
                    e.Phone = Convert.ToString(dr["phoneno"]);
                    e.Address = Convert.ToString(dr["address"]);
                    e.Status = Convert.ToString(dr["status"]);
                    e.Role = Convert.ToString(dr["role"]);
                }
                cn.Close();
                return e;
            }
        }
        //public void Delete(Details st)
        //{
        //    using (SqlConnection cn = new SqlConnection(connection))
        //    {
        //        SqlCommand cm = new SqlCommand("Usp_InsertUpdateDelete", cn);
        //        cm.CommandType = CommandType.StoredProcedure;
        //        cm.Parameters.AddWithValue("@ID", st.id);
        //        cm.Parameters.AddWithValue("@Status", "Delete");
        //        cn.Open();
        //        cm.ExecuteNonQuery();
        //        cn.Close();
        //    }

        //}

        //public void Edit(Details st)
        //{
        //    using (SqlConnection cn = new SqlConnection(connection))
        //    {
        //        SqlCommand cm = new SqlCommand("Usp_InsertUpdateDelete", cn);
        //        cm.CommandType = CommandType.StoredProcedure;
        //        cm.Parameters.AddWithValue("@ID", st.id);
        //        cm.Parameters.AddWithValue("@Name", st.name);
        //        cm.Parameters.AddWithValue("@Address", st.address);
        //        cm.Parameters.AddWithValue("@Mobile_no", st.mobile_no);
        //        cm.Parameters.AddWithValue("@Status", "Update");
        //        cn.Open();
        //        cm.ExecuteNonQuery();
        //        cn.Close();
        //    }
        //}

        //public Int32 CheckExistence(Details exist)
        //{
        //    using (SqlConnection cn = new SqlConnection(connection))
        //    {
        //        SqlCommand cm = new SqlCommand("select isnull(count(*),0) from Contact where Name=@name", cn);
        //        cm.Parameters.AddWithValue("@name", exist.name);
        //        cn.Open();
        //        var a = cm.ExecuteScalar();
        //        cn.Close();
        //        return (Int32)a;
        //    }
        //}

        public Int32 CheckUserNameExistence(User chk_name)
        {
            using (SqlConnection cn = new SqlConnection(connection))
            {
                // SqlCommand cm = new SqlCommand("select isnull(count(*),0) from Emp_Master where UserId=@userid", cn);
                SqlCommand cm = new SqlCommand("UserName_Existance", cn);
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.AddWithValue("@username", chk_name.UserName);
                cn.Open();
                var a = cm.ExecuteScalar();
                cn.Close();
                return (Int32)a;
            }
        }
        public Int32 CheckPasswordExistence(User chk_name)
        {
            using (SqlConnection cn = new SqlConnection(connection))
            {
                // SqlCommand cm = new SqlCommand("select isnull(count(*),0) from Emp_Master where UserId=@userid", cn);
                SqlCommand cm = new SqlCommand("Password_Existance", cn);
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.AddWithValue("@password", chk_name.Password);
                cn.Open();
                var a = cm.ExecuteScalar();
                cn.Close();
                return (Int32)a;
            }
        }
        public Int32 ValidateLogin(LoginModel vallog)
        {
            Int32? is_val = null;
            using (SqlConnection cn = new SqlConnection(connection))
            {
                SqlCommand cm = new SqlCommand("Validate_User", cn);
                cm.Parameters.AddWithValue("@Username", vallog.UserName);
                cm.Parameters.AddWithValue("@Password", vallog.Password);
                cm.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    is_val = Convert.ToInt32(dr["Result"]);
                }
                cn.Close();
                return (Int32)is_val;
            }
        }
        public string GetRole(LoginModel vallog)
        {
            string role = null;
            using (SqlConnection cn = new SqlConnection(connection))
            {
                SqlCommand cm = new SqlCommand("Validate_User", cn);
                cm.Parameters.AddWithValue("@Username", vallog.UserName);
                cm.Parameters.AddWithValue("@Password", vallog.Password);
                cm.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    role = Convert.ToString(dr["role"]);
                }
                cn.Close();
                return role;
            }
        }

        public User UpdateUserDetails(User userdetails)
        {
            User e = new User();
            if(String.IsNullOrEmpty(userdetails.Role))
            {
                userdetails.Role = "";
            }
            using (SqlConnection cn = new SqlConnection(connection))
            {
                SqlCommand cm = new SqlCommand("UpdateUserDetails", cn);
                cm.Parameters.AddWithValue("@Name", userdetails.UserNameForUpdate);
                cm.Parameters.AddWithValue("@Email", userdetails.Email);
                cm.Parameters.AddWithValue("@Address", userdetails.Address);
                cm.Parameters.AddWithValue("@Mobile_no", userdetails.Phone);
                cm.Parameters.AddWithValue("@status", userdetails.Status);
                cm.Parameters.AddWithValue("@role", userdetails.Role);

                cm.CommandType = CommandType.StoredProcedure;
                cn.Open();
                cm.ExecuteNonQuery();
                //SqlDataReader dr = cm.ExecuteReader();
                //while (dr.Read())
                //{

                //    e.UserName = Convert.ToString(dr["username"]);
                //    e.Email = Convert.ToString(dr["emaiid"]);
                //    e.Phone = Convert.ToString(dr["phoneno"]);
                //    e.Address = Convert.ToString(dr["address"]);
                //    e.Status = Convert.ToString(dr["status"]);
                //}
                cn.Close();
                return e;
            }
        }
        //public DataSet GetAll()
        //{
        //    using (SqlConnection cn = new SqlConnection(connection))
        //    {
        //        DataSet ret = new DataSet();
        //        SqlCommand cm = new SqlCommand("GetAll", cn);
        //        //cm.Parameters.AddWithValue("@ID", 0);
        //        //cm.Parameters.AddWithValue("@Name", "");
        //        //cm.Parameters.AddWithValue("@Address", "");   
        //        //cm.Parameters.AddWithValue("@Mobile_no", 0);
        //        //cm.Parameters.AddWithValue("@Status", "All");

        //        cm.CommandType = CommandType.StoredProcedure;
        //        cn.Open();
        //        SqlDataAdapter dr = new SqlDataAdapter(cm);
        //        dr.Fill(ret);
        //        cn.Close();
        //        return ret;
        //    }
        //}
        public void ResetPassword(User st)
        {
            using (SqlConnection cn = new SqlConnection(connection))
            {
                SqlCommand cm = new SqlCommand("ResetPassword", cn);
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.AddWithValue("@Name", st.UserName);
                cm.Parameters.AddWithValue("@Password", st.NewPassword);
                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();
            }

        }
    }
}