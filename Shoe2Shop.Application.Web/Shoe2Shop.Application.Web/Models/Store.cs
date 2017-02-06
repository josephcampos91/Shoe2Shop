using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shoe2Shop.Application.Web.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public Store()
        {
            this.Id = 0;
            this.Name = string.Empty;
            this.Address = string.Empty;
        }
    }
}