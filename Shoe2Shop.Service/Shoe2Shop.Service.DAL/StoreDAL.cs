using Microsoft.Practices.EnterpriseLibrary.Data;
using Shoe2Shop.Service.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoe2Shop.Service.DAL
{
    public class StoreDAL
    {
        public static ReadStoresRes ReadStores()
        {
            try
            {
                ReadStoresRes oResponse = new ReadStoresRes();
                string procedimiento = "GAP.USP_ReadStores";

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
                                var oStore = new Store();
                                oStore.Id = Convert.ToInt32(dataReader["STR_nId"]);
                                oStore.Name = Convert.ToString(dataReader["STR_strName"]);
                                oStore.Address = Convert.ToString(dataReader["STR_strAddress"]);

                                oResponse.Stores.Add(oStore);
                            }

                            oResponse.TotalElemens = oResponse.Stores.Count;
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

        public static CreateStoreRes CreateStore(CreateStoreReq pReq)
        {
            try
            {
                CreateStoreRes oResponse = new CreateStoreRes();

                string procedimiento = "GAP.USP_CreateStore";

                Database db = new Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(ConfigurationManager.AppSettings.Get("DB").ToString());
                var _comando = db.GetStoredProcCommand(procedimiento, pReq.Name, pReq.Address, null, null, null);

                db.ExecuteNonQuery(_comando);

                oResponse.ErrorCode = Convert.ToInt32(db.GetParameterValue(_comando, "nError"));
                oResponse.ErrorMessage = Convert.ToString(db.GetParameterValue(_comando, "strMessage"));
                oResponse.Id = Convert.ToInt32(db.GetParameterValue(_comando, "STR_nId"));

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
