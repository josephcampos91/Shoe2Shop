using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Shoe2Shop.Application.Web.Models
{
    public class ArticleModels
    {
        public static ReadArticlesXStoreRes ReadArticlesXStore(int pId)
        {
            try
            {
                using (var oClient = new HttpClient())
                {

                    string method = String.Format("{0}/{1}", Convert.ToString(ConfigurationManager.AppSettings["ReadArticlesXStore"]), pId.ToString());

                    oClient.BaseAddress = new Uri(Convert.ToString(ConfigurationManager.AppSettings["BaseAddressServices"]));
                    oClient.DefaultRequestHeaders.Accept.Clear();
                    oClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    //oClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.AuthenticationHeaderValue()/)

                    HttpResponseMessage oHttpResponse = oClient.GetAsync(method).Result;

                    if (oHttpResponse.IsSuccessStatusCode)
                    {
                        var oResponse = oHttpResponse.Content.ReadAsAsync<ReadArticlesXStoreRes>().Result;
                        return oResponse;
                    }
                    else
                    {
                        return new ReadArticlesXStoreRes() { ErrorCode = (int)oHttpResponse.StatusCode, Success = false, ErrorMessage = oHttpResponse.ReasonPhrase };
                    }

                }
            }
            catch (Exception ex)
            {
                // To conserve the stack trace
                throw new Exception(ex.Message, ex);
            }

        }

        public static ReadArticlesRes ReadArticles()
        {
            try
            {
                using (var oClient = new HttpClient())
                {

                    string method = Convert.ToString(ConfigurationManager.AppSettings["ReadArticles"]);

                    oClient.BaseAddress = new Uri(Convert.ToString(ConfigurationManager.AppSettings["BaseAddressServices"]));
                    oClient.DefaultRequestHeaders.Accept.Clear();
                    oClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    //oClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.AuthenticationHeaderValue()/)

                    HttpResponseMessage oHttpResponse = oClient.GetAsync(method).Result;

                    if (oHttpResponse.IsSuccessStatusCode)
                    {
                        var oResponse = oHttpResponse.Content.ReadAsAsync<ReadArticlesRes>().Result;
                        return oResponse;
                    }
                    else
                    {
                        return new ReadArticlesRes() { ErrorCode = (int)oHttpResponse.StatusCode, Success = false, ErrorMessage = oHttpResponse.ReasonPhrase };
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