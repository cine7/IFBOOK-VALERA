using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IFBOOK_VALERA.Data;
using IFBOOK_VALERA.Models;
using Microsoft.AspNetCore.Authorization;

namespace IFBOOK_VALERA.Controllers
{
    public class PublicacaoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PublicacaoController(ApplicationDbContext context)
        {
            _context = context;    
        }
        [Authorize]
        // GET: Publicacao
        public async Task<IActionResult> Index()
        {
            return View(await _context.Publicacoes.ToListAsync());
        }
        [Authorize]
        // GET: Publicacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicacao = await _context.Publicacoes.SingleOrDefaultAsync(m => m.Id == id);
            if (publicacao == null)
            {
                return NotFound();
            }

            return View(publicacao);
        }
        [Authorize]
        // GET: Publicacao/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        // POST: Publicacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataPublicacao,Descricao")] Publicacao publicacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publicacao);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(publicacao);
        }
        [Authorize]
        // GET: Publicacao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicacao = await _context.Publicacoes.SingleOrDefaultAsync(m => m.Id == id);
            if (publicacao == null)
            {
                return NotFound();
            }
            return View(publicacao);
        }
        [Authorize]
        // POST: Publicacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataPublicacao,Descricao")] Publicacao publicacao)
        {
            if (id != publicacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publicacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublicacaoExists(publicacao.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(publicacao);
        }
        [Authorize]
        // GET: Publicacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicacao = await _context.Publicacoes.SingleOrDefaultAsync(m => m.Id == id);
            if (publicacao == null)
            {
                return NotFound();
            }

            return View(publicacao);
        }
        [Authorize]
        // POST: Publicacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publicacao = await _context.Publicacoes.SingleOrDefaultAsync(m => m.Id == id);
            _context.Publicacoes.Remove(publicacao);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PublicacaoExists(int id)
        {
            return _context.Publicacoes.Any(e => e.Id == id);
        }
    }
}
