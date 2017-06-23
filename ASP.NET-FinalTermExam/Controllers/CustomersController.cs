using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP.NET_FinalTermExam.Models;
using ASP.NET_FinalTermExam.Models.DB;

namespace ASP.NET_FinalTermExam.Controllers
{
    public class CustomersController : Controller
    {
        private KuasDB db = new KuasDB();
        //private CodeTableDB codeTableDB = new CodeTableDB();
        // GET: Customers
        public ActionResult Index(string id)
        {
            var titleList = new List<string>();

            var data = from d in db.Customers
                       select d.ContactTitle;

            titleList.AddRange(data.Distinct());
            ViewBag.ContactTitle = new SelectList(titleList);

            var customer = from m in db.Customers
                           select m;
            if (!String.IsNullOrEmpty(id))
            {
                customer = customer.Where(s => s.CustomerID.Equals(id));
            }

            return View(customer);
        }

        //Search
        public ActionResult Serach(string customerID, string CompanyName, string contactName, string contactTitle)
        {
            var titleList = new List<string>();

            var data = from d in db.Customers
                       select d.ContactTitle;

            titleList.AddRange(data.Distinct());
            ViewBag.ContactTitle = new SelectList(titleList);

            var result = from m in db.Customers
                         select m;

            if (!String.IsNullOrEmpty(customerID))
            {
                result = result.Where(s => s.CustomerID.ToString().Contains(customerID));
            }
            if (!String.IsNullOrEmpty(CompanyName))
            {
                result = result.Where(s => s.CompanyName.ToString().Contains(CompanyName));
            }
            if (!String.IsNullOrEmpty(contactName))
            {
                result = result.Where(s => s.ContactName.ToString().Contains(contactName));
            }
            if (!String.IsNullOrEmpty(contactTitle))
            {
                result = result.Where(s => s.ContactTitle.ToString().Contains(contactTitle));
            }
            return View("Index", result);

        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,CompanyName,ContactName,ContactTitle,CreationDate,Address,City,Region,PostalCode,Country,Phone,Fax")] Customers customers)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customers);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // POST: Customers/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,CompanyName,ContactName,ContactTitle,CreationDate,Address,City,Region,PostalCode,Country,Phone,Fax")] Customers customers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customers);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customers customers = db.Customers.Find(id);
            db.Customers.Remove(customers);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
