using System.Threading.Tasks;
using System;
using System.Net.Http;
using System.Configuration;

namespace Shoe2Shop.Application.Web.Models
{
    public class StoreModels
    {
        public static ReadStoresRes ReadStores()
        {
            try
            {
                using (var oClient = new HttpClient())
                {

                    string method = Convert.ToString(ConfigurationManager.AppSettings["ReadStores"]);

                    oClient.BaseAddress = new Uri(Convert.ToString(ConfigurationManager.AppSettings["BaseAddressServices"]));
                    oClient.DefaultRequestHeaders.Accept.Clear();
                    oClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    //oClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.AuthenticationHeaderValue()/)

                    HttpResponseMessage oHttpResponse = oClient.GetAsync(method).Result;

                    if (oHttpResponse.IsSuccessStatusCode)
                    {
                        ReadStoresRes oResponse = oHttpResponse.Content.ReadAsAsync<ReadStoresRes>().Result;
                        return oResponse;
                    }
                    else
                    {
                        return new ReadStoresRes() { ErrorCode = (int)oHttpResponse.StatusCode, Success = false, ErrorMessage = oHttpResponse.ReasonPhrase };
                    }

                }
            }
            catch (Exception ex)
            {
                // To conserve the stack trace
                throw new Exception(ex.Message, ex);
            }

        }

    }
}