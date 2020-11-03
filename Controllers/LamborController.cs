using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DA1.Data;
using DA1.Models;
using DA1.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DA1.Controllers
{
    public class LamborController : Controller
    {
        private readonly DataContext _context;
        IMapper mapper;
        public LamborController(DataContext context, IMapper mapper)
        {

            _context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult News()
        {
            return View();
        }
        public IActionResult NewsDetail()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Cartnull()
        {
            return View();
        }
    }
}