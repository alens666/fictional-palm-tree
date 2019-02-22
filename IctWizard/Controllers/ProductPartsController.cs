using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IctWizard.Context;
using IctWizard.Models;
using IctWizard.ViewModel;

namespace IctWizard.Controllers
{
    public class ProductPartsController : Controller
    {
        private readonly IctContext _context;

        public ProductPartsController(IctContext context)
        {
            _context = context;
        }

        // GET: ProductParts
        public async Task<IActionResult> Index()
        {
            var ictContext = _context.ProductParts.Include(p => p.Part).Include(p => p.Product);
            return View(await ictContext.ToListAsync());
        }

        // GET: ProductParts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productPart = await _context.ProductParts
                .Include(p => p.Part)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.PartId == id);
            if (productPart == null)
            {
                return NotFound();
            }

            return View(productPart);
        }

        // GET: ProductParts/Create
        public IActionResult Create()
        {
            ViewData["PartId"] = new SelectList(_context.Parts, "Id", "Description");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ProductName");
            return View();
        }

        // POST: ProductParts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddProductViewModel addProductView)
        {

            if (ModelState.IsValid)
            {
                _context.Add(addProductView.ProductPart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["PartId"] = new SelectList(_context.Parts, "Id", "Description",addProductView.ProductPart.PartId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ProductName", addProductView.ProductPart.ProductId);
            return View(addProductView);

        }
        // GET: ProductParts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productPart = await _context.ProductParts.FindAsync(id);
            if (productPart == null)
            {
                return NotFound();
            }
            ViewData["PartId"] = new SelectList(_context.Parts, "Id", "Description", productPart.PartId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ProductName", productPart.ProductId);
            return View(productPart);
        }

        // POST: ProductParts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,PartId,Quantity")] ProductPart productPart)
        {
            if (id != productPart.PartId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productPart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductPartExists(productPart.PartId))
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
            ViewData["PartId"] = new SelectList(_context.Parts, "Id", "Description", productPart.PartId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ProductName", productPart.ProductId);
            return View(productPart);
        }

        // GET: ProductParts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productPart = await _context.ProductParts
                .Include(p => p.Part)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.PartId == id);
            if (productPart == null)
            {
                return NotFound();
            }

            return View(productPart);
        }

        // POST: ProductParts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productPart = await _context.ProductParts.FindAsync(id);
            _context.ProductParts.Remove(productPart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductPartExists(int id)
        {
            return _context.ProductParts.Any(e => e.PartId == id);
        }
    }
}
