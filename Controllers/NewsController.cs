using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DA1.Data;
using DA1.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DA1.Controllers
{
    public class NewsController : Controller
    {
        private readonly DataContext _context;
        IMapper mapper;
        public NewsController(DataContext context, IMapper mapper)
        {

            _context = context;
            this.mapper = mapper;
        }
        public IActionResult News(int? begin)
        {
            int e = 0;
            if (begin == null)
            {
                e = begin.GetValueOrDefault() * 9;
            }
            //List<News> news1 = _context.News.ToList();
            List<News> news1 = _context.News.Skip(e).Take(9).ToList();
            ViewBag.count = _context.News.Count() / 6;

            return View(news1);
        }
        public async Task<IActionResult> NewsDetail(int? id)
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


    }
}
