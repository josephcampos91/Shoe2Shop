using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoe2Shop.Service.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int TotalShelf { get; set; }
        public int TotalVault { get; set; }
        public int StoreId { get; set; }

        public Article()
        {
            this.Id = 0;
            this.Name = string.Empty;
            this.Description = string.Empty;
            this.Price = 0;
            this.TotalShelf = 0;
            this.TotalVault = 0;
            this.StoreId = 0;
        }

    }
}
