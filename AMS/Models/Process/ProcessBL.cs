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
    public class ProcessBL
    {
        public string message;
        string constr = ConfigurationManager.ConnectionStrings["AMS"].ConnectionString;

        #region Add/update Group Detail
        public void AddGrp(ProcessGrp prsgrp)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("SP_PRSGRP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ACTION", 2);
                cmd.Parameters.AddWithValue("@AUDTUSER", HttpContext.Current.User.Identity.GetUserName());
                cmd.Parameters.AddWithValue("@CHKGRPID", prsgrp.CHKGRPID);
                cmd.Parameters.AddWithValue("@CHKGRPNAME", prsgrp.CHKGRPNAME);
                cmd.Parameters.AddWithValue("@CHKGRPDESC", prsgrp.CHKGRPDESC);
                cmd.Parameters.AddWithValue("@INACTIVE", prsgrp.INACTIVE);
                cmd.Parameters.AddWithValue("@SORTORD", prsgrp.SORTORD);
                cmd.Parameters.AddWithValue("@DATELASTMN", prsgrp.DATELASTMN);
                cmd.Parameters.Add("@MESSAGE", SqlDbType.VarChar, 500);
                cmd.Parameters["@MESSAGE"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                message = cmd.Parameters["@MESSAGE"].Value.ToString();
            }
        }
        #endregion

        #region Add/Update/delete List Detail
        public void AddList(ProcessList prslist)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("SP_PRSLIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ACTION", 2);
                cmd.Parameters.AddWithValue("@AUDTUSER", HttpContext.Current.User.Identity.GetUserName());
                cmd.Parameters.AddWithValue("@CHKLISTID", prslist.CHKLISTID);
                cmd.Parameters.AddWithValue("@CHKGRPID", prslist.CHKGRPID);
                cmd.Parameters.AddWithValue("@CHKLISTTIT", prslist.CHKLISTTIT);
                cmd.Parameters.AddWithValue("@CHKLISTDESC", prslist.CHKLISTDESC);
                cmd.Parameters.AddWithValue("@SORTORD", prslist.SORTORD);
                cmd.Parameters.AddWithValue("@DATELASTMN", prslist.DATELASTMN);
                cmd.Parameters.Add("@MESSAGE", SqlDbType.VarChar, 500);
                cmd.Parameters["@MESSAGE"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                message = cmd.Parameters["@MESSAGE"].Value.ToString();
            }
        }
        public void DeleteList(string chklistid)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("SP_PRSLIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ACTION", 3);
                cmd.Parameters.AddWithValue("@CHKLISTID", chklistid);
                cmd.Parameters.Add("@MESSAGE", SqlDbType.VarChar, 500);
                cmd.Parameters["@MESSAGE"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                message = cmd.Parameters["@MESSAGE"].Value.ToString();

            }
        }
        #endregion

        #region User Acknowledgement
        public void userack(string name)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("SP_PRSUSRACK", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ACTION", 2);
                cmd.Parameters.AddWithValue("@AUDTUSER", HttpContext.Current.User.Identity.GetUserName());
                cmd.Parameters.AddWithValue("@USERNAME", HttpContext.Current.User.Identity.GetUserName());
                cmd.Parameters.AddWithValue("@CHKGRPNAME", name);
                cmd.Parameters.Add("@MESSAGE", SqlDbType.VarChar, 500);
                cmd.Parameters["@MESSAGE"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                message = cmd.Parameters["@MESSAGE"].Value.ToString();
            }

        }
        #endregion

        #region user suggestion 
        public void usrsugg(string usrsug)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("SP_PRSUSRSUG", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ACTION", 2);
                cmd.Parameters.AddWithValue("@AUDTUSER", HttpContext.Current.User.Identity.GetUserName());
                cmd.Parameters.AddWithValue("@USERNAME", HttpContext.Current.User.Identity.GetUserName());
                cmd.Parameters.AddWithValue("@SUGGESTION", usrsug);
                cmd.Parameters.Add("@MESSAGE", SqlDbType.VarChar, 500);
                cmd.Parameters["@MESSAGE"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                message = cmd.Parameters["@MESSAGE"].Value.ToString();
            }
        }
        public void usrsugupd(int id)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {

                SqlCommand cmd = new SqlCommand("SP_PRSUSRSUG", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ACTION", 3);
                cmd.Parameters.AddWithValue("@AUDTUSER", HttpContext.Current.User.Identity.GetUserName());
                cmd.Parameters.AddWithValue("@SUGGID", id);
                cmd.Parameters.Add("@MESSAGE", SqlDbType.VarChar, 500);
                cmd.Parameters["@MESSAGE"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                message = cmd.Parameters["@MESSAGE"].Value.ToString();
            }
        }
        #endregion

    }
}