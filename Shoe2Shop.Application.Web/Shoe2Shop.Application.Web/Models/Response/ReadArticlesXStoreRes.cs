using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shoe2Shop.Application.Web.Models
{
    public class ReadArticlesXStoreRes : ResponseList
    {
        private List<Article> _articles;

        public ReadArticlesXStoreRes() : base()
        {
            this._articles = new List<Article>();
        }

        public List<Article> Articles
        {
            get { return this._articles; }
            set { this._articles = value; this.TotalElemens = value.Count; }
        }
    }
}