using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoe2Shop.Service.Entities
{
    public class ReadStoresRes : ResponseList
    {
        private List<Store> _stores;

        public ReadStoresRes() : base()
        {
            this._stores = new List<Store>();
        }

        public List<Store> Stores
        {
            get { return this._stores; }
            set { this._stores = value; this.TotalElemens = value.Count; }
        }
    }
}
