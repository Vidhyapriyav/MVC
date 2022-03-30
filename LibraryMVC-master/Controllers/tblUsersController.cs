using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryMSMVC.Models;

namespace LibraryMSMVC.Controllers
{
    public class tblUsersController : Controller
    {
        private LibraryMVCEntities tbluserdb = new LibraryMVCEntities();

        // GET: tblUsers
        public ActionResult Index()
        {
            return View(tbluserdb.tblUsers.ToList());
        }
        public ActionResult GetAll()
        {
            var userlist = tbluserdb.tblUsers.ToList();
            return Json(new { data = userlist }, JsonRequestBehavior.AllowGet);
        }
        // GET: tblUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUser tblUser = tbluserdb.tblUsers.Find(id);
            if (tblUser == null)
            {
                return HttpNotFound();
            }
            return View(tblUser);
        }

        // GET: tblUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,UserName,UserGender,UserDep,UserAdmNo,UserEmail,UserPass")] tblUser tblUser)
        {
            if (ModelState.IsValid)
            {
                tbluserdb.tblUsers.Add(tblUser);
                tbluserdb.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblUser);
        }

        // GET: tblUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUser tblUser = tbluserdb.tblUsers.Find(id);
            if (tblUser == null)
            {
                return HttpNotFound();
            }
            return View(tblUser);
        }

        // POST: tblUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,UserName,UserGender,UserDep,UserAdmNo,UserEmail,UserPass")] tblUser tblUser)
        {
            if (ModelState.IsValid)
            {
                tbluserdb.Entry(tblUser).State = EntityState.Modified;
                tbluserdb.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblUser);
        }

        // GET: tblUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUser tblUser = tbluserdb.tblUsers.Find(id);
            if (tblUser == null)
            {
                return HttpNotFound();
            }
            return View(tblUser);
        }

        // POST: tblUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblUser tblUser = tbluserdb.tblUsers.Find(id);
            tbluserdb.tblUsers.Remove(tblUser);
            tbluserdb.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                tbluserdb.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
