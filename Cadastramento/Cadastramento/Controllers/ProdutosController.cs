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
using Microsoft.AspNetCore.Authorization;

namespace Cadastramento.Controllers
{
    //PARA REDIRECIONAMENTO DE USUÁRIOS NÃO LOGADOS
    [Authorize]
    //CONTROLLER DA CLASSE PRODUTOS
    public class ProdutosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProdutosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            _context.Acessos.Add(
                new Acessos
                {
                    Email = User.Identity.Name,
                    Detalhamento = String.Concat("ACESSOU A LISTAGEM DE PRODUTOS! ", " | Acesso em: ", DateTime.Now.ToLongDateString(), " | Horário de Acesso: ", DateTime.Now.ToLongTimeString())
                });
            _context.SaveChanges();
            return View(await _context.Produtos.ToListAsync());
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtos = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produtos == null)
            {
                return NotFound();
            }

            _context.Acessos.Add(
                new Acessos
                {
                    Email = User.Identity.Name,
                    Detalhamento = String.Concat("ACESSOU A TELA DETALHAMENTO DE PRODUTOS. ",
                    " | Acesso em: ", DateTime.Now.ToLongDateString(), " | Horário de Acesso: ", DateTime.Now.ToLongTimeString())
                });
            _context.SaveChanges();

            return View(produtos);
        }

        // CRIAÇÃO DE PRODUTOS
        public IActionResult Create()
        {
            //ENVIO DE DADOS DE ACESSO DE CRIAÇÃO PARA O BANCO
            _context.Acessos.Add(
                new Acessos
                {
                    Email = User.Identity.Name,
                    Detalhamento = String.Concat("ACESSOU A TELA CRIAÇÃO DE PRODUTOS",
                    " | Acesso em: ", DateTime.Now.ToLongDateString(), " | Horário de Acesso: ", DateTime.Now.ToLongTimeString())
                });
            _context.SaveChanges();
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome_Produto,Preco_Produto")] Produtos produtos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produtos);
                await _context.SaveChangesAsync();
                //DADOS DE ENVIO DE INFORMAÇÕES.
                _context.Acessos.Add(
                new Acessos
                {
                    Email = User.Identity.Name,
                    Detalhamento = String.Concat("SALVOU O PRODUTO: ",
                    produtos.Nome_Produto,  " | Acesso em: ", DateTime.Now.ToLongDateString(), " | Horário de Acesso: ", DateTime.Now.ToLongTimeString())
                });
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(produtos);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtos = await _context.Produtos.FindAsync(id);
            if (produtos == null)
            {
                return NotFound();
            }

            _context.Acessos.Add(
                new Acessos
                {
                    Email = User.Identity.Name,
                    Detalhamento = String.Concat("ACESSOU A TELA EDIÇÃO DE PRODUTOS ",
                    " | Acesso em: ", DateTime.Now.ToLongDateString(), " | Horário de Acesso: ", DateTime.Now.ToLongTimeString())
                });
            _context.SaveChanges();
            return View(produtos);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome_Produto,Preco_Produto")] Produtos produtos)
        {
            if (id != produtos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produtos);
                    await _context.SaveChangesAsync();

                    _context.Acessos.Add(
                    new Acessos
                    {
                        Email = User.Identity.Name,
                        Detalhamento = String.Concat("ATUALIZOU O PRODUTO: ",
                        produtos.Nome_Produto, " | Acesso em: ", DateTime.Now.ToLongDateString(), " | Horário de Acesso: ", DateTime.Now.ToLongTimeString()),
                    });
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutosExists(produtos.Id))
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
            return View(produtos);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtos = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produtos == null)
            {
                return NotFound();
            }

            _context.Acessos.Add(
                    new Acessos
                    {
                        Email = User.Identity.Name,
                        Detalhamento = String.Concat("SOS: ENTROU NA TELA EXCLUSÃO DO PRODUTO: ",
                        produtos.Nome_Produto, " | Acesso em: ", DateTime.Now.ToLongDateString(), " | Horário de Acesso: ", DateTime.Now.ToLongTimeString()),
                    });
            _context.SaveChanges();
            return View(produtos);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produtos = await _context.Produtos.FindAsync(id);
            _context.Produtos.Remove(produtos);
            await _context.SaveChangesAsync();

            _context.Acessos.Add(
                    new Acessos
                    {
                        Email = User.Identity.Name,
                        Detalhamento = String.Concat("DELETOU O PRODUTO :( -> ",
                        produtos.Nome_Produto, " | Acesso em: ", DateTime.Now.ToLongDateString(), " | Horário de Acesso: ", DateTime.Now.ToLongTimeString()),
                    });
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        private bool ProdutosExists(int id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }
    }
}
