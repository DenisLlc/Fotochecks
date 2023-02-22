using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IngresoPersonal.Models;
using IngresoPersonal.Permissions;

using PagedList.Mvc;
using PagedList;

namespace IngresoPersonal.Controllers
{
    [Authorize]
    [PermissionsRolAttibute(Models.RolesInd.Admin, Models.RolesInd.User)]    
    public class FotocheckTestsController : Controller
    {
        private ASISTENCIA_TISUREntities db = new ASISTENCIA_TISUREntities();

        // GET: FotocheckTests
        public ActionResult Index(string search, int? i)
        {
            List<FotocheckTest> listemp = db.FotocheckTest.ToList();
            return View( db.FotocheckTest.Where(x => x.DNI.StartsWith(search) || search == null ).ToList().ToPagedList(i ?? 1,5));
        }

        // GET: FotocheckTests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FotocheckTest fotocheckTest = db.FotocheckTest.Find(id);
            if (fotocheckTest == null)
            {
                return HttpNotFound();
            }
            return View(fotocheckTest);
        }

        // GET: FotocheckTests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FotocheckTests/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cod_Per,Cod_Tarjeta,Cod_Trabajador,Nombres,Apellidos,Domicilio,DNI,Activo,Fotos,Cod_Tarjeta2,cod_Fotocheck,GrupoSanguineo,alergias,Cargo,id")] FotocheckTest fotocheckTest)
        {
            if (ModelState.IsValid)
            {
                db.FotocheckTest.Add(fotocheckTest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fotocheckTest);
        }

        // GET: FotocheckTests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FotocheckTest fotocheckTest = db.FotocheckTest.Find(id);
            if (fotocheckTest == null)
            {
                return HttpNotFound();
            }
            return View(fotocheckTest);
        }

        // POST: FotocheckTests/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cod_Per,Cod_Tarjeta,Cod_Trabajador,Nombres,Apellidos,Domicilio,DNI,Activo,Fotos,Cod_Tarjeta2,cod_Fotocheck,GrupoSanguineo,alergias,Cargo,id")] FotocheckTest fotocheckTest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fotocheckTest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fotocheckTest);
        }

        // GET: FotocheckTests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FotocheckTest fotocheckTest = db.FotocheckTest.Find(id);
            if (fotocheckTest == null)
            {
                return HttpNotFound();
            }
            return View(fotocheckTest);
        }

        // POST: FotocheckTests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FotocheckTest fotocheckTest = db.FotocheckTest.Find(id);
            db.FotocheckTest.Remove(fotocheckTest);
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
