using SpecialTemplateSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpecialTemplateSample.Controllers
{
    

    public class HomeController : Controller
    {
        //
        // GET: /Home/
        static int count = 2;
        static int count_edit = 0;
        public static Product product = new Product();
        public static Prod pr = new Prod();

        public ActionResult Index()
        {
            if (count_edit == 0)
            {
                product.count = 20;
                product.Id = 0;
                product.Name = new string[20];
                product.note = new string[20];
                product.Name[0] = "books";
                product.Name[1] = "food";
                product.Name[2] = "bla";

                product.note[0] = "Roadside Picnic";
                product.note[1] = "potatoes, bananas, milk";

                product.note[2] = "bla";
            }
            count_edit++;



            return View(product);
        }

        public ActionResult Create()
        {
            return View(pr);
        }

        [HttpPost]
        public ActionResult Create(string Name, string note)
        {
            product.Name[++count] = Name;
            product.note[count] = note;
            return RedirectToAction("Index");
        }
        public ActionResult Edit()
        {
      
           
                string url = Request.RawUrl;
                int id = Convert.ToInt32(url[url.LastIndexOf('/') + 1] - '0');
                
                pr.Name = product.Name[id];
                pr.note = product.note[id];
            
            return View(pr);
        }
        [HttpPost]
        public ActionResult Edit(string Name, string note)
        {
            
                string url = Request.RawUrl;
                int id = Convert.ToInt32(url[url.LastIndexOf('/') + 1] - '0');

            pr.Name = Name;
                pr.note = note;
            
               
                product.Name[id] = Name;
                product.note[id] = note;

            return RedirectToAction("Index");
        }

        public ActionResult Delete()
        {
            string url = Request.RawUrl;
            int id = Convert.ToInt32(url[url.LastIndexOf('/') + 1] - '0');
            pr.Name = product.Name[id];
            pr.note = product.note[id];

            return View(pr);
        }

        [HttpPost]
        public ActionResult Delete(string Name, string note)
        {
            string url = Request.RawUrl;
            int id = Convert.ToInt32(url[url.LastIndexOf('/') + 1] - '0');

            product.Name[id] = "";
            product.note[id] = "";

            return RedirectToAction("Index");
        }
    }
}
