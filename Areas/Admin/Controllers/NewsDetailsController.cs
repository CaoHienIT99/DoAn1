using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DA1.Data;
using DA1.Models.Domain;
using Microsoft.AspNetCore.Authorization;

namespace DA1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class NewsDetailsController : Controller
    {
        private readonly DataContext _context;

        public NewsDetailsController(DataContext context)
        {
            _context = context;
        }

        // GET: Admin/NewsDetails
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.NewsDetails.Include(n => n.News);
            return View(await dataContext.ToListAsync());
        }

        // GET: Admin/NewsDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsDetail = await _context.NewsDetails
                .Include(n => n.News)
                .FirstOrDefaultAsync(m => m.NewsID == id);
            if (newsDetail == null)
            {
                return NotFound();
            }

            return View(newsDetail);
        }

        // GET: Admin/NewsDetails/Create
        public IActionResult Create()
        {
            ViewData["NewsID"] = new SelectList(_context.News, "NewsID", "NewsID");
            return View();
        }

        // POST: Admin/NewsDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NewsDetailID,Content,Nameposted,CreateDate,NewsID")] NewsDetail newsDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newsDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NewsID"] = new SelectList(_context.News, "NewsID", "NewsID", newsDetail.NewsID);
            return View(newsDetail);
        }

        // GET: Admin/NewsDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsDetail = await _context.NewsDetails.FindAsync(id);
            if (newsDetail == null)
            {
                return NotFound();
            }
            ViewData["NewsID"] = new SelectList(_context.News, "NewsID", "NewsID", newsDetail.NewsID);
            return View(newsDetail);
        }

        // POST: Admin/NewsDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NewsDetailID,Content,Nameposted,CreateDate,NewsID")] NewsDetail newsDetail)
        {
            if (id != newsDetail.NewsDetailID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newsDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsDetailExists(newsDetail.NewsDetailID))
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
            ViewData["NewsID"] = new SelectList(_context.News, "NewsID", "NewsID", newsDetail.NewsID);
            return View(newsDetail);
        }

        // GET: Admin/NewsDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsDetail = await _context.NewsDetails
                .Include(n => n.News)
                .FirstOrDefaultAsync(m => m.NewsDetailID == id);
            if (newsDetail == null)
            {
                return NotFound();
            }

            return View(newsDetail);
        }

        // POST: Admin/NewsDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newsDetail = await _context.NewsDetails.FindAsync(id);
            _context.NewsDetails.Remove(newsDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsDetailExists(int id)
        {
            return _context.NewsDetails.Any(e => e.NewsDetailID == id);
        }
    }
}
