using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    public class IdentityServicesController : Controller
    {



        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: IdentityServices
        public ActionResult Index()
        {
            var identityServices = db.IdentityServices.Include(i => i.ApplicationUser).Include(i => i.Service);
            return View(identityServices.ToList());
        }

        // GET: IdentityServices/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdentityService identityService = db.IdentityServices.Find(id);
            if (identityService == null)
            {
                return HttpNotFound();
            }
            return View(identityService);
        }

        //GET: IdentityServices/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email");
            ViewBag.ServiceId = new SelectList(db.Services, "Id", "Name");
            return View();
        }

        // POST: IdentityServices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,ServiceId,ApplicationUserId,Data")] IdentityService identityService)
        {
            if (ModelState.IsValid)
            {
                identityService.Id = Guid.NewGuid();
                db.IdentityServices.Add(identityService);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", identityService.ApplicationUserId);
            ViewBag.ServiceId = new SelectList(db.Services, "Id", "Name", identityService.ServiceId);
            return View(identityService);
        }

        // GET: IdentityServices/Edit/5
        [Authorize]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdentityService identityService = db.IdentityServices.Find(id);
            if (identityService == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", identityService.ApplicationUserId);
            ViewBag.ServiceId = new SelectList(db.Services, "Id", "Name", identityService.ServiceId);
            return View(identityService);
        }

        // POST: IdentityServices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,ServiceId,ApplicationUserId,Data")] IdentityService identityService)
        {
            if (ModelState.IsValid)
            {
                db.Entry(identityService).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", identityService.ApplicationUserId);
            ViewBag.ServiceId = new SelectList(db.Services, "Id", "Name", identityService.ServiceId);
            return View(identityService);
        }

        // GET: IdentityServices/Delete/5
        [Authorize]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdentityService identityService = db.IdentityServices.Find(id);
            if (identityService == null)
            {
                return HttpNotFound();
            }
            return View(identityService);
        }

        // POST: IdentityServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(Guid id)
        {
            IdentityService identityService = db.IdentityServices.Find(id);
            db.IdentityServices.Remove(identityService);
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
