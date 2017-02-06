﻿using Shoe2Shop.Application.Entities;
using System.Collections.Generic;

namespace Shoe2Shop.Application.Api
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
