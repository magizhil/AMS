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
    public class ContractBL
    {
        public string message;
        string constr = ConfigurationManager.ConnectionStrings["AMS"].ConnectionString;
        public void AddCnt(CntDetails cnt)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("SP_CNTDET", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ACTION", 1);
                cmd.Parameters.AddWithValue("@CNTNUMBER", cnt.CNTNUMBER);
                cmd.Parameters.AddWithValue("@CNTNAME", cnt.CNTNAME);
                cmd.Parameters.AddWithValue("@VENDID", cnt.VENDID);
                cmd.Parameters.AddWithValue("@VENDNAME", cnt.VENDNAME);
                cmd.Parameters.AddWithValue("@EMAIL", cnt.EMAIL);
                cmd.Parameters.AddWithValue("@PHNO", cnt.PHNO);
                cmd.Parameters.AddWithValue("@VENDADDR", cnt.VENDADDR);
                cmd.Parameters.AddWithValue("@SIGNLOC", cnt.SIGNLOC);
                cmd.Parameters.AddWithValue("@EXECLOC", cnt.EXECLOC);
                cmd.Parameters.AddWithValue("@CNTTYPE", cnt.CNTTYPE);
                cmd.Parameters.AddWithValue("@CNTPURPOSE", cnt.CNTPURPOSE);
                cmd.Parameters.AddWithValue("@CNTINFO", cnt.CNTINFO);
                cmd.Parameters.AddWithValue("@CNTVALUE", cnt.CNTVALUE);
                cmd.Parameters.AddWithValue("@CNTSTARTDT", cnt.CNTSTARTDT);
                cmd.Parameters.AddWithValue("@CNTENDDT", cnt.CNTENDDT);
                cmd.Parameters.AddWithValue("@CNTFILE", "");
                cmd.Parameters.AddWithValue("@CNTYEAR", cnt.CNTYEAR);
                cmd.Parameters.AddWithValue("@CNTSTATUS", cnt.CNTSTATUS);
                cmd.Parameters.AddWithValue("@CNTPRD", cnt.CNTPRD);
                cmd.Parameters.AddWithValue("@RENEWTYPE", cnt.RENEWTYPE);
                cmd.Parameters.AddWithValue("@CNTGRP", cnt.CNTGRP);
                cmd.Parameters.AddWithValue("@AUDTUSER", HttpContext.Current.User.Identity.GetUserName());
                cmd.Parameters.Add("@MESSAGE", SqlDbType.VarChar, 500);
                cmd.Parameters["@MESSAGE"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                message = cmd.Parameters["@MESSAGE"].Value.ToString();

            }
        }
    }
}