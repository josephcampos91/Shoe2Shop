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

    public class StoresController : ApiController
    {
        // GET: services/Stores
        public ReadStoresRes Get()
        {
            ReadStoresRes oResponse;
            try
            {
                oResponse = StoreModels.ReadStores();

                if (oResponse.TotalElemens.Equals(0))
                {
                    oResponse.Success = false;
                    oResponse.ErrorCode = (int)HttpStatusCode.NotFound;
                    oResponse.ErrorMessage = "Record not Found";                        
                }

            }catch(Exception ex)
            {
                oResponse = new ReadStoresRes() {
                    Success = false,
                    ErrorCode = (int)HttpStatusCode.InternalServerError,
                    ErrorMessage = string.Concat("Server Error: ", ex.Message) };

                // @TODO Log it
            }
            return oResponse;
        }

        // POST: services/Stores
        public CreateStoreRes Post([FromBody]CreateStoreReq pReq)
        {
            CreateStoreRes oResponse;
            try
            {
                oResponse = StoreModels.CreateStore(pReq);

                if (oResponse.Id.Equals(0))
                {
                    oResponse.Success = false;
                    oResponse.ErrorCode = (int)HttpStatusCode.BadRequest;
                    oResponse.ErrorMessage = HttpStatusCode.BadRequest.ToString();
                }

            }
            catch (Exception ex)
            {
                oResponse = new CreateStoreRes()
                {
                    Success = false,
                    ErrorCode = (int)HttpStatusCode.InternalServerError,
                    ErrorMessage = string.Concat("Server Error: ", ex.Message)
                };

                // @TODO Log it
            }
            return oResponse;
        }

        // PUT: api/Stores/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

    }
}
