﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoe2Shop.Application.Entities
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
