using Shoe2Shop.Service.Entities;
using Shoe2Shop.Service.WApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shoe2Shop.Service.WApi.Controllers
{
    public class ArticlesController : ApiController
    {
        // GET: api/Articles
        public ReadArticlesRes Get()
        {
            ReadArticlesRes oResponse;
            try
            {
                oResponse = ArticleModels.ReadArticles();

                if (oResponse.TotalElemens.Equals(0))
                {
                    oResponse.Success = false;
                    oResponse.ErrorCode = (int)HttpStatusCode.NotFound;
                    oResponse.ErrorMessage = "Record not Found";
                }

            }
            catch (Exception ex)
            {
                oResponse = new ReadArticlesRes()
                {
                    Success = false,
                    ErrorCode = (int)HttpStatusCode.InternalServerError,
                    ErrorMessage = string.Concat("Server Error: ", ex.Message)
                };

                // @TODO Log it
            }
            return oResponse;
        }
        // GET: services/Articles/Stores/5
        [Route("services/Articles/Stores/{id}")]
        public ReadArticlesXStoreRes Get(int id)
        {
            ReadArticlesXStoreRes oResponse;
            try
            {
                if (id <= 0)
                {
                    oResponse = new ReadArticlesXStoreRes()
                    {
                        Success = false,
                        ErrorCode = (int)HttpStatusCode.BadRequest,
                        ErrorMessage = HttpStatusCode.BadRequest.ToString()
                    };
                }
                else
                {
                    oResponse = ArticleModels.ReadArticlesXStore(id);
                    
                    if (oResponse.TotalElemens.Equals(0))
                    {
                        oResponse.Success = false;
                        oResponse.ErrorCode = (int)HttpStatusCode.NotFound;
                        oResponse.ErrorMessage = "Record not Found";
                    }
                }
            }
            catch (Exception ex)
            {
                oResponse = new ReadArticlesXStoreRes()
                {
                    Success = false,
                    ErrorCode = (int)HttpStatusCode.InternalServerError,
                    ErrorMessage = string.Concat("Server Error: ", ex.Message)
                };

                // @TODO Log it
            }
            return oResponse;
        }

    }
}
