using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP1_PAW_089_C.Models;

namespace UCP1_PAW_089_C.Controllers
{
    public class PembelisController : Controller
    {
        private readonly UCP1_PAWContext _context;

        public PembelisController(UCP1_PAWContext context)
        {
            _context = context;
        }

        // GET: Pembelis
        public async Task<IActionResult> Index()
        {
            var uCP1_PAWContext = _context.Pembelis.Include(p => p.IdTransaksiNavigation);
            return View(await uCP1_PAWContext.ToListAsync());
        }

        // GET: Pembelis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pembeli = await _context.Pembelis
                .Include(p => p.IdTransaksiNavigation)
                .FirstOrDefaultAsync(m => m.IdPembeli == id);
            if (pembeli == null)
            {
                return NotFound();
            }

            return View(pembeli);
        }

        // GET: Pembelis/Create
        public IActionResult Create()
        {
            ViewData["IdTransaksi"] = new SelectList(_context.Transaksis, "IdTransaksi", "IdTransaksi");
            return View();
        }

        // POST: Pembelis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPembeli,NamaPembeli,NoHpPembeli,IdTransaksi")] Pembeli pembeli)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pembeli);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTransaksi"] = new SelectList(_context.Transaksis, "IdTransaksi", "IdTransaksi", pembeli.IdTransaksi);
            return View(pembeli);
        }

        // GET: Pembelis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pembeli = await _context.Pembelis.FindAsync(id);
            if (pembeli == null)
            {
                return NotFound();
            }
            ViewData["IdTransaksi"] = new SelectList(_context.Transaksis, "IdTransaksi", "IdTransaksi", pembeli.IdTransaksi);
            return View(pembeli);
        }

        // POST: Pembelis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPembeli,NamaPembeli,NoHpPembeli,IdTransaksi")] Pembeli pembeli)
        {
            if (id != pembeli.IdPembeli)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pembeli);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PembeliExists(pembeli.IdPembeli))
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
            ViewData["IdTransaksi"] = new SelectList(_context.Transaksis, "IdTransaksi", "IdTransaksi", pembeli.IdTransaksi);
            return View(pembeli);
        }

        // GET: Pembelis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pembeli = await _context.Pembelis
                .Include(p => p.IdTransaksiNavigation)
                .FirstOrDefaultAsync(m => m.IdPembeli == id);
            if (pembeli == null)
            {
                return NotFound();
            }

            return View(pembeli);
        }

        // POST: Pembelis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pembeli = await _context.Pembelis.FindAsync(id);
            _context.Pembelis.Remove(pembeli);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PembeliExists(int id)
        {
            return _context.Pembelis.Any(e => e.IdPembeli == id);
        }
    }
}
