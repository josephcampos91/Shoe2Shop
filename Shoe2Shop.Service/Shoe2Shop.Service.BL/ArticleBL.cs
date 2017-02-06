using Shoe2Shop.Service.DAL;
using Shoe2Shop.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoe2Shop.Service.BL
{
    public class ArticleBL
    {
        public static ReadArticlesXStoreRes ReadArticlesXStore(int pId)
        {
            try
            {
                return ArticleDAL.ReadArticlesXStore(pId);
            }
            catch (Exception ex)
            {
                // to preserve the stack trace
                throw new Exception(ex.Message, ex);
            }
        }

        public static ReadArticlesRes ReadArticles()
        {
            try
            {
                return ArticleDAL.ReadArticles();
            }
            catch (Exception ex)
            {
                // to preserve the stack trace
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
