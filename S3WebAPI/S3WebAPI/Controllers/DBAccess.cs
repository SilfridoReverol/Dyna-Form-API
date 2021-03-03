using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using S3WebAPI.Users;


namespace S3WebAPI.Library
{
    public class DbAccess
    {

        string sConnStr = string.Empty;

        public DbAccess()
        {
            sConnStr = ConfigurationManager.ConnectionStrings["S3Project"].ConnectionString.Trim();
        }


        public DataSet getTopItems(int top)
        {
            SqlConnection oConn = new SqlConnection(sConnStr);
            SqlCommand oCmd = new SqlCommand()
            {
                Connection = oConn,
                CommandType = CommandType.StoredProcedure,
                CommandText = "[sproc_GetTopItems]"
            };
            oCmd.Parameters.Add("@top", SqlDbType.Int).Value = top;
            DataSet oDS = new DataSet();
            try
            {
                oConn.Open();
                SqlDataAdapter oAd = new SqlDataAdapter(oCmd);
                oAd.Fill(oDS, "access");
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }
            finally
            {
                oCmd.Parameters.Clear();
                oConn.Close();
            }
            return oDS;
        }


        public string UserLogin(string LoginName, string Password)
        {
            SqlConnection oConn = new SqlConnection(sConnStr);
            SqlCommand oCmd = new SqlCommand()
            {
                Connection = oConn,
                CommandType = CommandType.StoredProcedure,
                CommandText = "[sproc_Login]"
            };
            oCmd.Parameters.Add("@username", SqlDbType.VarChar).Value = LoginName;
            oCmd.Parameters.Add("@password", SqlDbType.VarChar).Value = Password;
            oCmd.Parameters.Add("@responseMessage", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
            string sResponse = string.Empty;
            try
            {
                oConn.Open();
                oCmd.ExecuteNonQuery();
                sResponse = oCmd.Parameters["@responseMessage"].Value.ToString();
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }
            finally
            {
                oCmd.Parameters.Clear();
                oConn.Close();
            }
            return sResponse;
        }


        public string Register(UsersClass oUsr)
        {
            SqlConnection oConn = new SqlConnection(sConnStr);
            SqlCommand oCmd = new SqlCommand()
            {
                Connection = oConn,
                CommandType = CommandType.StoredProcedure,
                CommandText = "[sproc_RegisterUser]"
            };
            oCmd.Parameters.Add("@username", SqlDbType.VarChar).Value = oUsr.userName;
            oCmd.Parameters.Add("@firstName", SqlDbType.VarChar).Value = oUsr.firstName;
            oCmd.Parameters.Add("@lastName", SqlDbType.VarChar).Value = oUsr.lastName;
            oCmd.Parameters.Add("@email", SqlDbType.VarChar).Value = oUsr.email;
            oCmd.Parameters.Add("@sex", SqlDbType.VarChar).Value = oUsr.sex;
            oCmd.Parameters.Add("@age", SqlDbType.Int).Value = oUsr.age;
            oCmd.Parameters.Add("@password", SqlDbType.VarChar).Value = oUsr.password;
            string sResponse = string.Empty;
            try
            {
                oConn.Open();
                oCmd.ExecuteNonQuery();
                return "Ok";
            }
            catch (SqlException e)
            {
                return e.Message;
                throw new ApplicationException(e.Message);
            }
            finally
            {
                oCmd.Parameters.Clear();
                oConn.Close();
            }
        }



        public DataSet GetUser(string userName)
        {
            SqlConnection oConn = new SqlConnection(sConnStr);
            SqlCommand oCmd = new SqlCommand()
            {
                Connection = oConn,
                CommandType = CommandType.StoredProcedure,
                CommandText = "[sproc_GetUser]"
            };
            oCmd.Parameters.Add("@username", SqlDbType.VarChar).Value = userName;
            DataSet oDS = new DataSet();
            try
            {
                oConn.Open();
                SqlDataAdapter oAd = new SqlDataAdapter(oCmd);
                oAd.Fill(oDS, "user");
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }
            finally
            {
                oCmd.Parameters.Clear();
                oConn.Close();
            }
            return oDS;
        }

        public DataSet GetForms()
        {
            SqlConnection oConn = new SqlConnection(sConnStr);
            SqlCommand oCmd = new SqlCommand()
            {
                Connection = oConn,
                CommandType = CommandType.StoredProcedure,
                CommandText = "[sproc_GetForms]"
            };
            DataSet oDS = new DataSet();
            try
            {
                oConn.Open();
                SqlDataAdapter oAd = new SqlDataAdapter(oCmd);
                oAd.Fill(oDS, "forms");
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }
            finally
            {
                oCmd.Parameters.Clear();
                oConn.Close();
            }
            return oDS;
        }



        public string GetForm(string formName)
        {
            SqlConnection oConn = new SqlConnection(sConnStr);
            SqlCommand oCmd = new SqlCommand()
            {
                Connection = oConn,
                CommandType = CommandType.StoredProcedure,
                CommandText = "[sproc_GetFormbyForm]"
            };
            oCmd.Parameters.Add("@formName", SqlDbType.VarChar).Value = formName;
            string form_schema;
            try
            {
                oConn.Open();
                form_schema = oCmd.ExecuteScalar().ToString();
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }
            finally
            {
                oCmd.Parameters.Clear();
                oConn.Close();
            }
            return form_schema;
        }






    }

}
