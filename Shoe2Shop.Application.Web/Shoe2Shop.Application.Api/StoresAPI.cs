using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoe2Shop.Application.Api
{
    public class StoresAPI
    {
        public static async Task<ReadStoresRes> ReadStores()
        {
            try
            {
                var method = Convert.ToString(ConfigurationManager.AppSettings["ReadStores"]);

            }catch(Exception ex)
            {
                // To conserve the stack trace
                throw new Exception(ex.Message, ex);
            }

        }
    }
}
