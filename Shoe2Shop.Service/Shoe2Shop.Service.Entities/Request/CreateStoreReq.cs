using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoe2Shop.Service.Entities
{
    public class CreateStoreReq
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public CreateStoreReq()
        {
            this.Name = string.Empty;
            this.Name = string.Empty;
        }
    }
}
