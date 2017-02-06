using Shoe2Shop.Application.Web.Models;
using System.Web.Mvc;

namespace Shoe2Shop.Application.Web.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index()
        {
            ReadStoresRes oResponse = StoreModels.ReadStores();

            if (oResponse.Success)
                return View(oResponse.Stores);
            else
                return View(new System.Collections.Generic.List<Store>());
        }

        // GET: Store/Details/5
        public ActionResult Details(int id)
        {
            ReadArticlesXStoreRes oResponse = ArticleModels.ReadArticlesXStore(id);

            if (oResponse.Success)
                return View(oResponse.Articles);
            else
                return View(new System.Collections.Generic.List<Store>());
        }

        // GET: Store/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Store/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Store/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Store/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Store/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Store/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
