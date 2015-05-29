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

        // GET: /DBServerUser/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DBServerUser dbserveruser = _DBServerUserService.GetById(id.Value);

            if (dbserveruser == null)
            {
                return HttpNotFound();
            }
            return View(dbserveruser);
        }

        // GET: /DBServerUser/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(_DBServerUserService.GetAll(), "Id", "Username");

            return View();
        }

        // POST: /DBServerUser/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Username,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy,Id")] DBServerUser dbserveruser)
        {
            if (ModelState.IsValid)
            {
                _DBServerUserService.Create(dbserveruser);

                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(_DBServerUserService.GetAll(), "Id", "Username");

            return View(dbserveruser);
        }

        // GET: /DBServerUser/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DBServerUser dbserveruser = _DBServerUserService.GetById(id.Value);

            if (dbserveruser == null)
            {
                return HttpNotFound();
            }

            ViewBag.Id = new SelectList(_DBServerUserService.GetAll(), "Id", "Username");

            return View(dbserveruser);
        }

        // POST: /DBServerUser/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Username,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy,Id")] DBServerUser dbserveruser)
        {
            if (ModelState.IsValid)
            {
                _DBServerUserService.Update(dbserveruser);

                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(_DBServerUserService.GetAll(), "Id", "Username");

            return View(dbserveruser);
        }

        // GET: /DBServerUser/Delete/5
        public ActionResult Delete(int? id)
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
        public ActionResult DeleteConfirmed(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DBServerUser dbserveruser = _DBServerUserService.GetById(id);

            if (dbserveruser == null)
            {
                return HttpNotFound();
            }
            return View(dbserveruser);
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
