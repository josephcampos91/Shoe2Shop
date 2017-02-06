using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoe2Shop.Service.Entities
{
    public class ResponseList : Response
    {
        public int TotalElemens { get; set; }

        public ResponseList() : base()
        {
            this.TotalElemens = 0;
        }
    }
}
