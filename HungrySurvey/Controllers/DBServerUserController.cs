using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hungry.Model;
using Hungry.Service.Interfaces;

namespace HungrySurvey.Controllers
{
    public class DBServerUserController : Controller
    {
        private HungryContext db = new HungryContext();

        IDBServerUserService _DBServerUserService;

        public DBServerUserController(IDBServerUserService DBServerUserService)
        {
            _DBServerUserService = DBServerUserService;
        }

        // GET: /DBServerUser/
        public ActionResult Index()
        {
            return View(_DBServerUserService.GetAll());
        }

        // GET: /DBServerUser/
        //public ActionResult Index()
        //{
        //    return View(db.DBServerUsers.ToList());
        //}

        // GET: /DBServerUser/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DBServerUser dbserveruser = db.DBServerUsers.Find(id);
            if (dbserveruser == null)
            {
                return HttpNotFound();
            }
            return View(dbserveruser);
        }

        // GET: /DBServerUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /DBServerUser/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Username,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy")] DBServerUser dbserveruser)
        {
            if (ModelState.IsValid)
            {
                db.DBServerUsers.Add(dbserveruser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dbserveruser);
        }

        // GET: /DBServerUser/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DBServerUser dbserveruser = db.DBServerUsers.Find(id);
            if (dbserveruser == null)
            {
                return HttpNotFound();
            }
            return View(dbserveruser);
        }

        // POST: /DBServerUser/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Username,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy")] DBServerUser dbserveruser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dbserveruser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dbserveruser);
        }

        // GET: /DBServerUser/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DBServerUser dbserveruser = db.DBServerUsers.Find(id);
            if (dbserveruser == null)
            {
                return HttpNotFound();
            }
            return View(dbserveruser);
        }

        // POST: /DBServerUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            DBServerUser dbserveruser = db.DBServerUsers.Find(id);
            db.DBServerUsers.Remove(dbserveruser);
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
