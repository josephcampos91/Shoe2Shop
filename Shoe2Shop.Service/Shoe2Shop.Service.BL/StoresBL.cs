using Shoe2Shop.Service.DAL;
using Shoe2Shop.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoe2Shop.Service.BL
{
    public class StoresBL
    {
        public static ReadStoresRes ReadStores()
        {
            try
            {
                return StoreDAL.ReadStores();

            }catch(Exception ex)
            {
                // to preserve the stack trace
                throw new Exception(ex.Message, ex);
            }
        }

        public static CreateStoreRes CreateStore(CreateStoreReq pReq)
        {
            try
            {
                return StoreDAL.CreateStore(pReq);

            }
            catch (Exception ex)
            {
                // to preserve the stack trace
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
