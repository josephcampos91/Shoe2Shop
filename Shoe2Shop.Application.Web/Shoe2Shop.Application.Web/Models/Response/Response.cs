using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shoe2Shop.Application.Web.Models
{
    public class Response
    {
        public bool Success { get; set; }

        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public Response()
        {
            this.Success = true;
            this.ErrorCode = (int)HttpStatusCode.OK;
            this.ErrorMessage = HttpStatusCode.OK.ToString();
        }
    }
}
