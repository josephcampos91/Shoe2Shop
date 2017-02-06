using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shoe2Shop.Application.Web.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int TotalShelf { get; set; }
        public int TotalVault { get; set; }
        public string StoreName { get; set; }

        public Article()
        {
            this.Id = 0;
            this.Name = string.Empty;
            this.Description = string.Empty;
            this.Price = 0;
            this.TotalShelf = 0;
            this.TotalVault = 0;
            this.StoreName = string.Empty;
        }

    }
}