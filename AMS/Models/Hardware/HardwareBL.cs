using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AMS.Models
{
    public class HardwareBL
    {
        public string message;
        string constr = ConfigurationManager.ConnectionStrings["AMS"].ConnectionString;

        #region Hardware Asset Details

        #region Hardware Insert / Update
        public void AddHwAsset(HwAsset hwast)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("SP_HWASSET", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ACTION", 2);
                cmd.Parameters.AddWithValue("@ASSETTAG", hwast.ASSETTAG);
                cmd.Parameters.AddWithValue("@CATGNAME", hwast.CATGNAME);
                cmd.Parameters.AddWithValue("@BRAND", hwast.BRAND);
                cmd.Parameters.AddWithValue("@MDLNO", hwast.MDLNO);
                cmd.Parameters.AddWithValue("@MDLNAME", hwast.MDLNAME);
                cmd.Parameters.AddWithValue("@SLNO", hwast.SLNO);
                cmd.Parameters.AddWithValue("@SERTTAG", hwast.SERTTAG);
                cmd.Parameters.AddWithValue("@HDD", hwast.HDD);
                cmd.Parameters.AddWithValue("@RAM", hwast.RAM);
                cmd.Parameters.AddWithValue("@PROCESSOR", hwast.PROCESSOR);
                cmd.Parameters.AddWithValue("@CONFIGURATION", hwast.CONFIGURATION);
                cmd.Parameters.AddWithValue("@ACCESSORIES", hwast.ACCESSORIES);
                cmd.Parameters.AddWithValue("@GEOLOC", hwast.GEOLOC);
                cmd.Parameters.AddWithValue("@PHLOC", hwast.PHLOC);
                cmd.Parameters.AddWithValue("@ASSTNO", hwast.ASSTNO);
                cmd.Parameters.AddWithValue("@ASSTSTS", hwast.ASSTSTS);
                cmd.Parameters.AddWithValue("@VENDID", hwast.VENDID);
                cmd.Parameters.AddWithValue("@INVOICENUMBER", hwast.INVOICENUMBER);
                cmd.Parameters.AddWithValue("@PODATE", hwast.PODATE);
                cmd.Parameters.AddWithValue("@ASSETVAL", hwast.ASSETVAL);
                cmd.Parameters.AddWithValue("@HWSTS", "1");
                cmd.Parameters.AddWithValue("@PRTMDCYC", hwast.PRTMDCYC);
                cmd.Parameters.AddWithValue("@PRTLTDCYC", hwast.PRTLTDCYC);
                cmd.Parameters.AddWithValue("@ASSETTYPE", hwast.ASSETTYPE);
                cmd.Parameters.AddWithValue("@SERIALIZED", hwast.SERIALIZED);
                cmd.Parameters.AddWithValue("@QTY", hwast.QTY);
                cmd.Parameters.AddWithValue("@WAREXP", hwast.WAREXP);
                cmd.Parameters.AddWithValue("@WARINFO", hwast.WARINFO);
                cmd.Parameters.AddWithValue("@AUDTUSER", "ADMIN");
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