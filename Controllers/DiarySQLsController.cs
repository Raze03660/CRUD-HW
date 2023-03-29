using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using WebHW.Models;

namespace WebHW.Controllers
{
    public class DiarySQLsController : Controller
    {
        private DiaryDatabaseEntities db = new DiaryDatabaseEntities();

        // GET: DiarySQLs
        public ActionResult Index()
        {

            return View(db.DiarySQLs.ToList());
        }

        // GET: DiarySQLs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiarySQL diarySQL = db.DiarySQLs.Find(id);
            if (diarySQL == null)
            {
                return HttpNotFound();
            }
            return View(diarySQL);
        }

        // GET: DiarySQLs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DiarySQLs/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,User,Title,Content,Time,Image")] DiarySQL diarySQL)
        {
            if (ModelState.IsValid)
            {
                diarySQL.Time = DateTime.Now;
                db.DiarySQLs.Add(diarySQL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(diarySQL);
        }

        // GET: DiarySQLs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiarySQL diarySQL = db.DiarySQLs.Find(id);
            if (diarySQL == null)
            {
                return HttpNotFound();
            }
            return View(diarySQL);
        }

        // POST: DiarySQLs/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,User,Title,Content,Time,Image")] DiarySQL diarySQL)
        {
            if (ModelState.IsValid)
            {
                diarySQL.Time = DateTime.Now;
                db.Entry(diarySQL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(diarySQL);
        }

        // GET: DiarySQLs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiarySQL diarySQL = db.DiarySQLs.Find(id);
            if (diarySQL == null)
            {
                return HttpNotFound();
            }
            return View(diarySQL);
        }

        // POST: DiarySQLs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DiarySQL diarySQL = db.DiarySQLs.Find(id);
            db.DiarySQLs.Remove(diarySQL);
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
