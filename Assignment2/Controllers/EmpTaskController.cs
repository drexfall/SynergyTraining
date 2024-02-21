using Assignment2.Data;
using Assignment2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.Controllers;

public class EmpTaskController(EmpTaskContext context) : Controller
    {
        // GET: EmpTaskController
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        // GET: EmpTaskController/List/5
        public async Task<IActionResult> List()
        {
           
            return View(await context.EmpTask.ToListAsync());
        }

        // GET: EmpTaskController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmpTaskController/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,Status,Employee")] EmpTask model)
        {
            if (ModelState.IsValid)
            {
                context.Add(model);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: EmpTaskController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empTask = await context.EmpTask.FindAsync(id);
            if (empTask == null)
            {
                return NotFound();
            }
            return View(empTask);
        }

        // POST: EmpTaskController/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Description,Status,Employee")] EmpTask model)
        {
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
                    if (!TaskExists(model.Id))
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
            return View(model);
        }
        

        // GET: EmpTaskController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empTask = await context.EmpTask
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empTask == null)
            {
                return NotFound();
            }

            return View(empTask);
        }

        // POST: EmpTaskController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empTask = await context.EmpTask.FindAsync(id);
            if (empTask != null)
            {
                context.EmpTask.Remove(empTask);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskExists(int id)
        {
            return context.EmpTask.Any(e => e.Id == id);
        }
    }
