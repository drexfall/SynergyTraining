using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment2.Data;
using Assignment2.Models;

namespace Assignment2.Controllers
{
    public class EmployeeController(EmployeeContext context) : Controller
    {
        // GET: EmployeeController
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        // GET: EmployeeController/List/5
        public async Task<IActionResult> List()
        {
           var role = TempData["role"];
            if (role == null || role.ToString() != "HR")
            {
                TempData["error"] = "You must login as HR first";
                return RedirectToAction("Login", "Home");
            }
            TempData["role"] = role;
            return View(await context.Employee.ToListAsync());
                
            
        }

        // GET: EmployeeController/Create
        public IActionResult Create()
        {
            var role = TempData["role"];
            if (role == null || role.ToString() != "HR")
            {
                TempData["error"] = "You must login as HR first";
                return RedirectToAction("Login", "Home");
            }
            TempData["role"] = role;
            return View();
        }

        // POST: EmployeeController/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Department,Position,Email,Phone,Address,City,State,Zip")] Employee model)
        {
            
            if (ModelState.IsValid)
            {
                context.Add(model);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(model);
        }

        // GET: EmployeeController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var role = TempData["role"];
            if (role == null || role.ToString() != "HR")
            {
                TempData["error"] = "You must login as HR first";
                return RedirectToAction("Login", "Home");
            }
            if (id == null)
            {
                return NotFound();
            }

            var employee = await context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            TempData["role"] = role;
            return View(employee);
        }

        // POST: EmployeeController/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Department,Position,Email,Phone,Address,City,State,Zip")] Employee model)
        {
            var role = TempData["role"];
            if (role == null || role.ToString() != "HR")
            {
                TempData["error"] = "You must login as HR first";
                return RedirectToAction("Login", "Home");
            }
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(model);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            TempData["role"] = role;
            return View(model);
        }
        

        // GET: EmployeeController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var role = TempData["role"];
            if (role == null || role.ToString() != "HR")
            {
                TempData["error"] = "You must login as HR first";
                return RedirectToAction("Login", "Home");
            }
            if (id == null)
            {
                return NotFound();
            }

            var employee = await context.Employee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            TempData["role"] = role;
            return View(employee);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var role = TempData["role"];
            if (role == null || role.ToString() != "HR")
            {
                TempData["error"] = "You must login as HR first";
                return RedirectToAction("Login", "Home");
            }
            var employee = await context.Employee.FindAsync(id);
            if (employee != null)
            {
                context.Employee.Remove(employee);
            }

            await context.SaveChangesAsync();
            TempData["role"] = role;
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return context.Employee.Any(e => e.Id == id);
        }
    }
}
