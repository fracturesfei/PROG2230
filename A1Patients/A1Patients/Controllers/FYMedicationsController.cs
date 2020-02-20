﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using A1Patients.Models;
using Microsoft.AspNetCore.Http;

namespace A1Patients.Controllers
{
    public class FYMedicationsController : Controller
    {
        private readonly PatientsContext _context;

        public FYMedicationsController(PatientsContext context)
        {
            _context = context;
        }

        // GET: FYMedications
        public async Task<IActionResult> Index(string id,string medname) //get id and name where parsed by medtype
        {
            if (id == null) //check if url include id
            {
                if (Request.Cookies["MedId"] != null) //check if cookie saved
                {
                    int medId2 = Convert.ToInt32(Request.Cookies["MedId"]); //take cookie
                    string medname2 = Request.Cookies["Medname"]; 
                    var patientsContext = _context.Medication // take value from database
                .Include(m => m.ConcentrationCodeNavigation)
                .Include(m => m.DispensingCodeNavigation)
                .Include(m => m.MedicationType)
                .Where(m => m.MedicationTypeId == medId2)
                .OrderBy(m => m.Name).ThenBy(m => m.Concentration);

                    ViewBag.medname = medname2;//send name as index
                    return View(await patientsContext.ToListAsync());

                }
                TempData["message"] = "we cannot find the medicines you want"; //show error
                return RedirectToRoute(new { Controller = "A1MedicationTypes",Action = "Index"}); //return to index
            }
            else
            {
                int medId = 0;
                Int32.TryParse(id, out medId);
                Response.Cookies.Append("MedId", id, new CookieOptions { Expires = DateTime.Today.AddDays(2) }); //make cookie as id
                Response.Cookies.Append("MedName", medname, new CookieOptions { Expires = DateTime.Today.AddDays(2) });// make cookie as name
                var patientsContext = _context.Medication
                    .Include(m => m.ConcentrationCodeNavigation)
                    .Include(m => m.DispensingCodeNavigation)
                    .Include(m => m.MedicationType)
                    .Where(m => m.MedicationTypeId == medId)
                    .OrderBy(m => m.Name).ThenBy(m => m.Concentration);
                ViewBag.medname = medname;//send name as index
                return View(await patientsContext.ToListAsync());
            }
        }

        // GET: FYMedications/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medication = await _context.Medication
                .Include(m => m.ConcentrationCodeNavigation)
                .Include(m => m.DispensingCodeNavigation)
                .Include(m => m.MedicationType)
                .FirstOrDefaultAsync(m => m.Din == id);
            if (medication == null)
            {
                return NotFound();
            }
            string medname = Convert.ToString(Request.Cookies["Medname"]);
            ViewBag.medname = medname;
            return View(medication);
        }

        // GET: FYMedications/Create
        public IActionResult Create()
        {
            int medId = Convert.ToInt32(Request.Cookies["MedId"]); //take cookie
            ViewData["ConcentrationCode"] = new SelectList(_context.ConcentrationUnit, "ConcentrationCode", "ConcentrationCode").OrderBy(a => a.Text).ToList();
            ViewData["DispensingCode"] = new SelectList(_context.DispensingUnit, "DispensingCode", "DispensingCode").OrderBy(a=>a.Text).ToList();
            ViewData["MedicationTypeId"] = new SelectList(_context.MedicationType, "MedicationTypeId", "Name",medId);
            string medname = Convert.ToString(Request.Cookies["Medname"]);
            ViewBag.medname = medname;
            return View();
        }

        // POST: FYMedications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Din,Name,Image,MedicationTypeId,DispensingCode,Concentration,ConcentrationCode")] Medication medication)
        {
            int medId = Convert.ToInt32(Request.Cookies["MedId"]); //take cookie
            string medname = Convert.ToString(Request.Cookies["Medname"]);
            ViewBag.medname = medname;
            MedicationType med = new MedicationType { MedicationTypeId = medId, Name = medname };
            var generalContext = _context.Medication //check value input
                .Include(m => m.ConcentrationCodeNavigation)
                .Include(m => m.ConcentrationCodeNavigation)
                .Include(m => m.MedicationType);
            var duplicateTest = generalContext.Where(m => m.Name == medication.Name) //check if duplicate
                .Where(m => m.Concentration == medication.Concentration)
                .Where(m => m.ConcentrationCode == medication.ConcentrationCode);
            if (duplicateTest.Any())
            {
                TempData["message"] = "this medication is alread exist"; //show error
                return View(medication); 
            }

            else
            {
                if (ModelState.IsValid) //if not then create the value
                {
                    _context.Add(medication);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["ConcentrationCode"] = new SelectList(_context.ConcentrationUnit, "ConcentrationCode", "ConcentrationCode", medication.ConcentrationCode);
                ViewData["DispensingCode"] = new SelectList(_context.DispensingUnit, "DispensingCode", "DispensingCode", medication.DispensingCode);
                ViewData["MedicationTypeId"] = new SelectList(_context.MedicationType, "MedicationTypeId", "Name", medication.MedicationTypeId);
                return View(medication);
            }
        }

        // GET: FYMedications/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medication = await _context.Medication.FindAsync(id);
            if (medication == null)
            {
                return NotFound();
            }
            ViewData["ConcentrationCode"] = new SelectList(_context.ConcentrationUnit, "ConcentrationCode", "ConcentrationCode", medication.ConcentrationCode).OrderBy(a => a.Text).ToList();
            ViewData["DispensingCode"] = new SelectList(_context.DispensingUnit, "DispensingCode", "DispensingCode", medication.DispensingCode).OrderBy(a => a.Text).ToList();
            ViewData["MedicationTypeId"] = new SelectList(_context.MedicationType, "MedicationTypeId", "Name", medication.MedicationTypeId);
            string medname = Convert.ToString(Request.Cookies["Medname"]);
            ViewBag.medname = medname;
            return View(medication);
        }

        // POST: FYMedications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Din,Name,Image,MedicationTypeId,DispensingCode,Concentration,ConcentrationCode")] Medication medication)
        {
            if (id != medication.Din)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicationExists(medication.Din))
                    {
                        return View(medication);
                       // return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return View(medication);
                 //return RedirectToAction(nameof(Index));
            }
            ViewData["ConcentrationCode"] = new SelectList(_context.ConcentrationUnit, "ConcentrationCode", "ConcentrationCode", medication.ConcentrationCode);
            ViewData["DispensingCode"] = new SelectList(_context.DispensingUnit, "DispensingCode", "DispensingCode", medication.DispensingCode);
            ViewData["MedicationTypeId"] = new SelectList(_context.MedicationType, "MedicationTypeId", "Name", medication.MedicationTypeId);
            return View(medication);
        }

        // GET: FYMedications/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medication = await _context.Medication
                .Include(m => m.ConcentrationCodeNavigation)
                .Include(m => m.DispensingCodeNavigation)
                .Include(m => m.MedicationType)
                .FirstOrDefaultAsync(m => m.Din == id);
            if (medication == null)
            {
                return NotFound();
            }
            string medname = Convert.ToString(Request.Cookies["Medname"]);
            ViewBag.medname = medname;
            return View(medication);
        }

        // POST: FYMedications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var medication = await _context.Medication.FindAsync(id);
            _context.Medication.Remove(medication);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicationExists(string id)
        {
            return _context.Medication.Any(e => e.Din == id);
        }
    }
}
