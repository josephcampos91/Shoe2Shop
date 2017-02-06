using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoe2Shop.Service.Entities
{
    public class CreateStoreRes : Response
    {
        public int Id { get; set; }

        public CreateStoreRes() : base()
        {
            this.Id = 0;
        }
    }
}
