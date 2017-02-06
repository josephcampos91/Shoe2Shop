using Microsoft.Practices.EnterpriseLibrary.Data;
using Shoe2Shop.Service.Entities;
using System;
using System.Configuration;
using System.Data;

namespace Shoe2Shop.Service.DAL
{
    public class ArticleDAL
    {
        public static ReadArticlesXStoreRes ReadArticlesXStore(int pId)
        {
            try
            {
                ReadArticlesXStoreRes oResponse = new ReadArticlesXStoreRes();
                string procedimiento = "GAP.USP_ReadArticles_X_Store";

                Database db = new Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(ConfigurationManager.AppSettings.Get("DB").ToString());
                var _comando = db.GetStoredProcCommand(procedimiento, pId, null, null);

                using (IDataReader dataReader = db.ExecuteReader(_comando))
                {

                    //if (Convert.ToInt32(db.GetParameterValue(_comando, "nError")) == 0)
                    //{
                    if (dataReader.FieldCount > 0)
                    {
                        while (dataReader.Read())
                        {
                            var oArticle = new Article();
                            oArticle.Id = Convert.ToInt32(dataReader["ART_nId"]);
                            oArticle.Description = Convert.ToString(dataReader["ART_strDescription"]);
                            oArticle.Name = Convert.ToString(dataReader["ART_strName"]);
                            oArticle.Price = Convert.ToDecimal(dataReader["ART_dPrice"]);
                            oArticle.TotalShelf = Convert.ToInt32(dataReader["ART_nTotalShelf"]);
                            oArticle.TotalVault = Convert.ToInt32(dataReader["ART_nTotalVault"]);
                            oArticle.StoreName = Convert.ToString(dataReader["STR_strName"]);

                            oResponse.Articles.Add(oArticle);
                        }

                        oResponse.TotalElemens = oResponse.Articles.Count;
                    }
                    //}
                    //else
                    //    throw new Exception(Convert.ToString(db.GetParameterValue(_comando, "strMessage")));
                }

                return oResponse;
            }
            catch (Exception ex)
            {
                // to preserve the stack trace
                throw new Exception(ex.Message, ex);
            }
        }

        public static ReadArticlesRes ReadArticles()
        {
            try
            {
                ReadArticlesRes oResponse = new ReadArticlesRes();
                string procedimiento = "GAP.USP_ReadArticles";

                Database db = new Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(ConfigurationManager.AppSettings.Get("DB").ToString());
                var _comando = db.GetStoredProcCommand(procedimiento, null, null);

                using (IDataReader dataReader = db.ExecuteReader(_comando))
                {

                    //if (Convert.ToInt32(db.GetParameterValue(_comando, "nError")) == 0)
                    //{
                    if (dataReader.FieldCount > 0)
                    {
                        while (dataReader.Read())
                        {
                            var oArticle = new Article();
                            oArticle.Id = Convert.ToInt32(dataReader["ART_nId"]);
                            oArticle.Description = Convert.ToString(dataReader["ART_strDescription"]);
                            oArticle.Name = Convert.ToString(dataReader["ART_strName"]);
                            oArticle.Price = Convert.ToDecimal(dataReader["ART_dPrice"]);
                            oArticle.TotalShelf = Convert.ToInt32(dataReader["ART_nTotalShelf"]);
                            oArticle.TotalVault = Convert.ToInt32(dataReader["ART_nTotalVault"]);
                            oArticle.StoreName = Convert.ToString(dataReader["STR_strName"]);

                            oResponse.Articles.Add(oArticle);
                        }

                        oResponse.TotalElemens = oResponse.Articles.Count;
                    }
                    //}
                    //else
                    //    throw new Exception(Convert.ToString(db.GetParameterValue(_comando, "strMessage")));
                }

                return oResponse;
            }
            catch (Exception ex)
            {
                // to preserve the stack trace
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
