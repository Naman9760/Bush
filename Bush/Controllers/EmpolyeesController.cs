using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bush.Models;

namespace Bush.Controllers
{
    public class EmpolyeesController : Controller
    {  
       public ApplicationDbContex db = new ApplicationDbContex();
 
        public ActionResult Index()
        {
            return View(db.empolyees.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empolyee empolyee = db.empolyees.Find(id);
            if (empolyee == null)
            {
                return HttpNotFound();
            }
            return View(empolyee);
        }

          public ActionResult Create()
        {
           
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,age,salary,gender,Maneger,Department,Role")] Empolyee empolyee)
        {
            List<Empolyee> emp = db.empolyees.ToList();

            ViewBag.Emp1 = new SelectList(emp, "name", "name");

            if (ModelState.IsValid)
            {
             
                    db.empolyees.Add(empolyee);
                    db.SaveChanges();
                    return RedirectToAction("Index");
            }

            return View(empolyee);
        }


        public ActionResult Edit(int? id)
        {
            List<Empolyee> emp = db.empolyees.ToList();
            ViewBag.Emp1 = new SelectList(emp, "name", "name");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empolyee empolyee = db.empolyees.Find(id);
            if (empolyee == null)
            {
                return HttpNotFound();
            }
            return View(empolyee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public ActionResult Edit([Bind(Include = "id,name,age,salary,gender,Maneger,Department,Role")] Empolyee empolyee)
        {
           
            if (ModelState.IsValid)
            {
                
                db.Entry(empolyee).State = EntityState.Modified;
                var manager = db.empolyees.Where(e => e.name == empolyee.Maneger).FirstOrDefault();
                if (manager.Maneger == empolyee.name)
                {
                    throw new Exception("Circular manager found");
                }
                else
                {
                    if (empolyee.name != empolyee.Maneger)
                    {

                        db.SaveChanges();
                        return RedirectToAction("Index");

                    }
                    else
                    {
                        return HttpNotFound("Emplyee name and Manger name is same ");
                    }
                }
            }
            return View(empolyee);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empolyee empolyee = db.empolyees.Find(id);
            if (empolyee == null)
            {
                return HttpNotFound();
            }
            return View(empolyee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empolyee empolyee = db.empolyees.Find(id);
            db.empolyees.Remove(empolyee); 
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
