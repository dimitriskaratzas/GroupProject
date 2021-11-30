﻿using DataAccess.Core.Entities;
using DataAccess.Core.Interfaces;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace GroupProject.Areas.Admin.Controllers
{
    [Authorize (Roles="Admin")]
    public class CasesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CasesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        // GET: Admin/Cases
        [Authorize]
        public ActionResult Index()
        {
            var cases = _unitOfWork.Cases.GetAll();
            return View(cases.ToList());
        }

        // GET: Admin/Cases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = _unitOfWork.Cases.GetById(id);
            if (@case == null)
            {
                return HttpNotFound();
            }
            return View(@case);
        }
        
        [Authorize]
        public ActionResult View(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = _unitOfWork.Cases.GetById(id);
            if (@case == null)
            {
                return HttpNotFound();
            }
            return View(@case);
        }

        //// GET: Admin/Cases/Create
        //public ActionResult Create()
        //{
        //    var cases = _unitOfWork.Cases.GetAll();
        //    //ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name");
        //    return View();
        //}

        //// POST: Admin/Cases/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,CompanyID,Model,Size,NumberOfFans,Thumbnail,Price")] Case @case)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.Cases.Create(@case);
        //        _unitOfWork.Complete();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name", @case.CompanyID);
        //    return View(@case);
        //}

        //// GET: Admin/Cases/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Case @case = db.Cases.Find(id);
        //    if (@case == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name", @case.CompanyID);
        //    return View(@case);
        //}

        //// POST: Admin/Cases/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,CompanyID,Model,Size,NumberOfFans,Thumbnail,Price")] Case @case)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(@case).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name", @case.CompanyID);
        //    return View(@case);
        //}

        //// GET: Admin/Cases/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Case @case = db.Cases.Find(id);
        //    if (@case == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(@case);
        //}

        //// POST: Admin/Cases/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Case @case = db.Cases.Find(id);
        //    db.Cases.Remove(@case);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}