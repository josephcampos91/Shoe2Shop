using Shoe2Shop.Service.BL;
using Shoe2Shop.Service.Entities;
using System;

namespace Shoe2Shop.Service.WApi.Models
{
    public class ArticleModels
    {
        public static ReadArticlesXStoreRes ReadArticlesXStore(int pId)
        {
            try
            {
                return ArticleBL.ReadArticlesXStore(pId);
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
                return ArticleBL.ReadArticles();
            }
            catch (Exception ex)
            {
                // to preserve the stack trace
                throw new Exception(ex.Message, ex);
            }
        }
    }
}