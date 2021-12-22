#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cadastramento.Data;
using Cadastramento.Models;

namespace Cadastramento.Controllers
{
    public class AcessosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AcessosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Acessos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Acessos.ToListAsync());
        }
    }
}
