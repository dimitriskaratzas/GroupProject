﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccess.Core.Entities;
using DataAccess.Core.Interfaces;
using DataAccess.Persistence;

namespace GroupProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PSUsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PSUsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/PSUs
        public ActionResult Index()
        {
            var pSUs = _unitOfWork.Psus.GetAll();
            return View(pSUs.ToList());
        }

        // GET: Admin/PSUs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PSU psu = _unitOfWork.Psus.GetById(id);
            if (psu == null)
            {
                return HttpNotFound();
            }
            return View(psu);
        }

        // GET: Admin/PSUs/Create
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(_unitOfWork.Companies.GetAll(), "ID", "Name");
            return View();
        }

        // POST: Admin/PSUs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PSU psu)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Psus.Create(psu);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(_unitOfWork.Companies.GetAll(), "ID", "Name", psu.CompanyID);
            return View(psu);
        }

        // GET: Admin/PSUs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PSU psu = _unitOfWork.Psus.GetById(id);
            if (psu == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(_unitOfWork.Companies.GetAll(), "ID", "Name", psu.CompanyID);
            return View(psu);
        }

        // POST: Admin/PSUs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PSU psu)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Psus.Update(psu);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(_unitOfWork.Companies.GetAll(), "ID", "Name", psu.CompanyID);
            return View(psu);
        }

        // GET: Admin/PSUs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PSU psu = _unitOfWork.Psus.GetById(id);
            if (psu == null)
            {
                return HttpNotFound();
            }
            return View(psu);
        }

        // POST: Admin/PSUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PSU psu = _unitOfWork.Psus.GetById(id);
            _unitOfWork.Psus.Delete(id);
            _unitOfWork.Complete();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
