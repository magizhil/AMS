using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AMS.Models
{
    public class SoftwareBL
    {
        public string message;
        string constr = ConfigurationManager.ConnectionStrings["AMS"].ConnectionString;

        #region Software Asset Details

        #region Software Insert / Update
        public void AddSwAsset(SwAsset swast)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("SP_SWASSET", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ACTION", 2);
                cmd.Parameters.AddWithValue("@ASSTTAG", swast.ASSETTAG);
                cmd.Parameters.AddWithValue("@AUDTUSER", "ADMIN");
                cmd.Parameters.AddWithValue("@CATGNAME", swast.CATGNAME);
                cmd.Parameters.AddWithValue("@BRAND", swast.BRAND);
                cmd.Parameters.AddWithValue("@MDLNAME", swast.MDLNAME);
                cmd.Parameters.AddWithValue("@MDLNO", swast.MDLNO);
                cmd.Parameters.AddWithValue("@SLNO", swast.SLNO);
                cmd.Parameters.AddWithValue("@LICTYPE", swast.LICTYPE);
                cmd.Parameters.AddWithValue("@USRLIC", swast.USRLIC);
                cmd.Parameters.AddWithValue("@MACLIC", swast.MACLIC);
                cmd.Parameters.AddWithValue("@VENDID", swast.VENDID);
                cmd.Parameters.AddWithValue("@ASSTNO", swast.ASSTNO);
                cmd.Parameters.AddWithValue("@INVOICENUMBER", swast.INVOICENUMBER);
                cmd.Parameters.AddWithValue("@PODATE", swast.PODATE);
                cmd.Parameters.AddWithValue("@ACTDATE", swast.ACTDATE);
                cmd.Parameters.AddWithValue("@RENEWALDATE", swast.RENEWALDATE);
                cmd.Parameters.AddWithValue("@ASSETVAL", swast.ASSETVAL);
                cmd.Parameters.AddWithValue("@SWSTS", "1");
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