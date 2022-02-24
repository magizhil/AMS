using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.AspNet.Identity;
namespace AMS.Models
{
    public class MasterBL
    {
        public string message;
        string constr = ConfigurationManager.ConnectionStrings["AMS"].ConnectionString;
        #region Vendor Master

        #region Vendor Insert
        public void AddVendor(MsVendor vend)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("SP_VENDMSTR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ACTION", 2);
                cmd.Parameters.AddWithValue("@AUDTUSER", "ADMIN");
                cmd.Parameters.AddWithValue("@VENDID", vend.VENDID);
                cmd.Parameters.AddWithValue("@VENDNAME", vend.VENDNAME);
                cmd.Parameters.AddWithValue("@VENDADDR", vend.VENDADDR);
                cmd.Parameters.AddWithValue("@VENDPHNO", vend.VENDPHNO);
                cmd.Parameters.AddWithValue("@VENDEMAIL", vend.VENDEMAIL);
                cmd.Parameters.AddWithValue("@COMMENTS", vend.COMMENTS);
                cmd.Parameters.AddWithValue("@INACTIVE", vend.INACTIVE);
                cmd.Parameters.Add("@MESSAGE", SqlDbType.VarChar, 500);
                cmd.Parameters["@MESSAGE"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                message = cmd.Parameters["@MESSAGE"].Value.ToString();

            }
        }
        #endregion

        #region Vendor Delete
        public void DelVendor(string venid)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("SP_VENDMSTR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ACTION", 3);
                cmd.Parameters.AddWithValue("@VENDID", venid);
                cmd.Parameters.Add("@MESSAGE", SqlDbType.VarChar, 500);
                cmd.Parameters["@MESSAGE"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                message = cmd.Parameters["@MESSAGE"].Value.ToString();

            }
        }
        #endregion

        #endregion

        #region Item Information

        #region Item Insert
        public void AddCatg(MsCategory catg)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("SP_MSCATG", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ACTION", 2);
                cmd.Parameters.AddWithValue("@AUDTUSER", "ADMIN");
                cmd.Parameters.AddWithValue("@CATGNAME", catg.CATGNAME);
                cmd.Parameters.AddWithValue("@CATGDESC", catg.CATGDESC);
                cmd.Parameters.AddWithValue("@CATGTYPE", catg.CATGTYPE);
                cmd.Parameters.AddWithValue("@INACTIVE", catg.INACTIVE);
                cmd.Parameters.Add("@MESSAGE", SqlDbType.VarChar, 500);
                cmd.Parameters["@MESSAGE"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                message = cmd.Parameters["@MESSAGE"].Value.ToString();

            }
        }
        #endregion

        #region Delete Item 
        public void DelCatg(string catno)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("SP_MSCATG", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ACTION", 3);
                cmd.Parameters.AddWithValue("@CATGNAME", catno);
                cmd.Parameters.Add("@MESSAGE", SqlDbType.VarChar, 500);
                cmd.Parameters["@MESSAGE"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                message = cmd.Parameters["@MESSAGE"].Value.ToString();
            }
        }
        #endregion

        #endregion
 
        #region Invoice Upload
        public void InvUplInfo(AstInvoice astinv)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("SP_INVUPLOAD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ACTION", 1);
                cmd.Parameters.AddWithValue("@AUDTUSER", HttpContext.Current.User.Identity.GetUserName());
                cmd.Parameters.AddWithValue("@ASSETTAG", astinv.ASSETTAG);
                cmd.Parameters.AddWithValue("@INVOICENUMBER", astinv.INVOICENUMBER);
                cmd.Parameters.AddWithValue("@INVPATH", astinv.INVPATH);
                cmd.Parameters.AddWithValue("@ASSTTYPE", astinv.ASSTTYPE);
                cmd.Parameters.Add("@MESSAGE", SqlDbType.VarChar, 500);
                cmd.Parameters["@MESSAGE"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                message = cmd.Parameters["@MESSAGE"].Value.ToString();

            }
        }
        #endregion

        #region Contract Type

        #region Contract Type Insert
        public void AddCntType(MsCnttype cnt)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("SP_MSCNTTYPE", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ACTION", 1);
                cmd.Parameters.AddWithValue("@AUDTUSER", HttpContext.Current.User.Identity.GetUserName());
                cmd.Parameters.AddWithValue("@CNTNAME", cnt.CNTTYPE);
                cmd.Parameters.AddWithValue("@CNTDESC", cnt.CNTDESC);
                cmd.Parameters.AddWithValue("@INACTIVE", cnt.INACTIVE);
                cmd.Parameters.Add("@MESSAGE", SqlDbType.VarChar, 500);
                cmd.Parameters["@MESSAGE"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                message = cmd.Parameters["@MESSAGE"].Value.ToString();

            }
        }
        #endregion

        #region Contract Type Delete
        public void DelCntType(string cntname)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("SP_MSCNTTYPE", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ACTION", 2);
                cmd.Parameters.AddWithValue("@CNTNAME", cntname);
                cmd.Parameters.Add("@MESSAGE", SqlDbType.VarChar, 500);
                cmd.Parameters["@MESSAGE"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                message = cmd.Parameters["@MESSAGE"].Value.ToString();
            }
        }
        #endregion

        #endregion
    }
}