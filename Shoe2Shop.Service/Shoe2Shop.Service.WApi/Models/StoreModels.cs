using Shoe2Shop.Service.BL;
using Shoe2Shop.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shoe2Shop.Service.WApi.Models
{
    public class StoreModels
    {
        public static ReadStoresRes ReadStores()
        {
            try
            {
                return StoresBL.ReadStores();
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
                return StoresBL.CreateStore(pReq);
            }
            catch (Exception ex)
            {
                // to preserve the stack trace
                throw new Exception(ex.Message, ex);
            }
        }
    }
}