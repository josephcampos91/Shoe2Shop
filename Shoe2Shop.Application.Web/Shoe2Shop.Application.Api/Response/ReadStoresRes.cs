using Shoe2Shop.Application.Entities;
using System.Collections.Generic;

namespace Shoe2Shop.Application.Api
{
    public class ReadStoresRes : Response
    {
        public List<Store> LstStores { get; set; }

        public ReadStoresRes() : base()
        {
            LstStores = new List<Store>();
        }
    }
}
