using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AMS.Models
{
    public class AssignBL
    {
        public string message;
        string constr = ConfigurationManager.ConnectionStrings["AMS"].ConnectionString;

        #region Assign Hardware
        public void AssignHw(AstAsgMultiview asgmulti)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmdins = new SqlCommand("SP_ASTASGH", con);
                cmdins.CommandType = CommandType.StoredProcedure;
                cmdins.Parameters.AddWithValue("@ACTION", 1);
                cmdins.Parameters.AddWithValue("@MASSETTAG", asgmulti.HwAssetDet.ASSETTAG);
                cmdins.Parameters.AddWithValue("@CATGNAME", asgmulti.HwAssetDet.CATGNAME);
                cmdins.Parameters.AddWithValue("@BRAND", asgmulti.HwAssetDet.BRAND);
                cmdins.Parameters.AddWithValue("@MDLNAME", asgmulti.HwAssetDet.MDLNAME);
                cmdins.Parameters.AddWithValue("@SLNO", asgmulti.HwAssetDet.SLNO);
                cmdins.Parameters.AddWithValue("@CASSETTAG", asgmulti.AssetDet1.ASSETTAG);
                cmdins.Parameters.AddWithValue("@CCATGNAME", asgmulti.AssetDet1.CATGNAME);
                cmdins.Parameters.AddWithValue("@CBRAND", asgmulti.AssetDet1.BRAND);
                cmdins.Parameters.AddWithValue("@CMDLNAME", asgmulti.AssetDet1.MDLNAME);
                cmdins.Parameters.AddWithValue("@CSLNO", asgmulti.AssetDet1.SLNO);
                cmdins.Parameters.AddWithValue("@SERIALIZED", asgmulti.AssetDet1.SERIALIZED);
                cmdins.Parameters.AddWithValue("@QTY", asgmulti.AssetDet1.QTY);
                cmdins.Parameters.AddWithValue("@ASGDATE", asgmulti.AssetDet1.ASGDATE);
                cmdins.Parameters.AddWithValue("@RETDATE", "");
                cmdins.Parameters.AddWithValue("@RECDATE", asgmulti.AssetDet1.RECDATE);
                cmdins.Parameters.AddWithValue("@AUDTUSER", "ADMIN");
                cmdins.Parameters.Add("@MESSAGE", SqlDbType.VarChar, 500);
                cmdins.Parameters["@MESSAGE"].Direction = ParameterDirection.Output;
                con.Open();
                cmdins.ExecuteNonQuery();
                message = cmdins.Parameters["@MESSAGE"].Value.ToString();
            }
        }
        #endregion

        #region Assign Software
        public void AssignSw(AstAsgMultiview asgmulti)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmdins = new SqlCommand("SP_ASTASGH", con);
                cmdins.CommandType = CommandType.StoredProcedure;
                cmdins.Parameters.AddWithValue("@ACTION", 2);
                cmdins.Parameters.AddWithValue("@MASSETTAG", asgmulti.HwAssetDet.ASSETTAG);
                cmdins.Parameters.AddWithValue("@CATGNAME", asgmulti.HwAssetDet.CATGNAME);
                cmdins.Parameters.AddWithValue("@BRAND", asgmulti.HwAssetDet.BRAND);
                cmdins.Parameters.AddWithValue("@MDLNAME", asgmulti.HwAssetDet.MDLNAME);
                cmdins.Parameters.AddWithValue("@SLNO", asgmulti.HwAssetDet.SLNO);
                cmdins.Parameters.AddWithValue("@CASSETTAG", asgmulti.AssetDet2.ASSETTAG);
                cmdins.Parameters.AddWithValue("@CCATGNAME", asgmulti.AssetDet2.CATGNAME);
                cmdins.Parameters.AddWithValue("@CBRAND", asgmulti.AssetDet2.BRAND);
                cmdins.Parameters.AddWithValue("@CMDLNAME", asgmulti.AssetDet2.MDLNAME);
                cmdins.Parameters.AddWithValue("@CSLNO", asgmulti.AssetDet2.SLNO);
                cmdins.Parameters.AddWithValue("@SERIALIZED", asgmulti.AssetDet2.SERIALIZED);
                cmdins.Parameters.AddWithValue("@QTY", asgmulti.AssetDet2.QTY);
                cmdins.Parameters.AddWithValue("@ASGDATE", asgmulti.AssetDet2.ASGDATE);
                cmdins.Parameters.AddWithValue("@RETDATE", "");
                cmdins.Parameters.AddWithValue("@RECDATE", asgmulti.AssetDet2.RECDATE);
                cmdins.Parameters.AddWithValue("@AUDTUSER", "ADMIN");
                cmdins.Parameters.AddWithValue("@LICTYPE", asgmulti.AssetDet2.LICTYPE);
                cmdins.Parameters.AddWithValue("@LICENSE", asgmulti.AssetDet2.LICENSE);
                cmdins.Parameters.Add("@MESSAGE", SqlDbType.VarChar, 500);
                cmdins.Parameters["@MESSAGE"].Direction = ParameterDirection.Output;
                con.Open();
                cmdins.ExecuteNonQuery();
                message = cmdins.Parameters["@MESSAGE"].Value.ToString();
            }
        }
        #endregion

        #region Assign Employee
        public void AssignEmp(AstAsgMultiview asgmulti)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmdins = new SqlCommand("SP_ASTASGH", con);
                cmdins.CommandType = CommandType.StoredProcedure;
                cmdins.Parameters.AddWithValue("@ACTION", '3');
                cmdins.Parameters.AddWithValue("@MASSETTAG", asgmulti.HwAssetDet.ASSETTAG);
                cmdins.Parameters.AddWithValue("@CATGNAME", asgmulti.HwAssetDet.CATGNAME);
                cmdins.Parameters.AddWithValue("@BRAND", asgmulti.HwAssetDet.BRAND);
                cmdins.Parameters.AddWithValue("@MDLNAME", asgmulti.HwAssetDet.MDLNAME);
                cmdins.Parameters.AddWithValue("@SLNO", asgmulti.HwAssetDet.SLNO);
                cmdins.Parameters.AddWithValue("@EMPCODE", asgmulti.AssetDet3.EMPCODE);
                cmdins.Parameters.AddWithValue("@EMPNAME", asgmulti.AssetDet3.EMPNAME);
                cmdins.Parameters.AddWithValue("@DESG", asgmulti.AssetDet3.DESG);
                cmdins.Parameters.AddWithValue("@DEPT", asgmulti.AssetDet3.DEPT);
                cmdins.Parameters.AddWithValue("@DOJ", asgmulti.AssetDet3.DOJ);
                cmdins.Parameters.AddWithValue("@RPTMANAGER", asgmulti.AssetDet3.RPTMANAGER);
                cmdins.Parameters.AddWithValue("@EMPLOC", asgmulti.AssetDet3.EMPLOC);
                cmdins.Parameters.AddWithValue("@EMPCONT1", asgmulti.AssetDet3.EMPCONT1);
                cmdins.Parameters.AddWithValue("@EMPCONT2", asgmulti.AssetDet3.EMPCONT2);
                cmdins.Parameters.AddWithValue("@EMPEMAIL", asgmulti.AssetDet3.EMPEMAIL);
                cmdins.Parameters.AddWithValue("@GEOLOC", asgmulti.AssetDet3.GEOLOC);
                cmdins.Parameters.AddWithValue("@PHLOC", asgmulti.AssetDet3.PHLOC);
                cmdins.Parameters.AddWithValue("@ASGDATE", asgmulti.AssetDet3.ASGDATE);
                cmdins.Parameters.AddWithValue("@RETDATE", "");
                cmdins.Parameters.AddWithValue("@RECDATE", asgmulti.AssetDet3.RECDATE);
                cmdins.Parameters.AddWithValue("@AUDTUSER", "ADMIN");
                cmdins.Parameters.Add("@MESSAGE", SqlDbType.VarChar, 500);
                cmdins.Parameters["@MESSAGE"].Direction = ParameterDirection.Output;
                con.Open();
                cmdins.ExecuteNonQuery();
                message = cmdins.Parameters["@MESSAGE"].Value.ToString();
            }
        }
        #endregion

    }
}