using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.Domain.Entidades;
using MinhasFinancas.Domain.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MinhasFinancas.Mvc.Controllers
{
    public class ContaController : Controller
    {
        private readonly IContaRepositorio _contaRepositorio;
        IHttpContextAccessor HttpContextAccessor;

        public ContaController(IContaRepositorio contaRepositorio, IHttpContextAccessor httpContextAccessor)
        {
            _contaRepositorio = contaRepositorio;
            HttpContextAccessor = httpContextAccessor;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            Conta objConta = new Conta();
            //List<Conta> listaContas = _contaRepositorio.ListarContasPorUsuario(1);
            string usuarioId = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            int usuario_id = int.Parse(usuarioId);
            List<Conta> listaContas = _contaRepositorio.ListarContasPorUsuario(usuario_id);
            //ViewBag.ListaDeContas = listaContas;
            return View(listaContas);
        }

        [HttpGet]
        public IActionResult CriarConta()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CriarConta(Conta conta)
        {
            if (ModelState.IsValid)
            {
                if (conta != null)
                {
                    string usuarioId = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
                    conta.Usuario_Id = int.Parse(usuarioId);
                    _contaRepositorio.Add(conta);
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult ExcluirConta(int id)
        {
            Conta conta = _contaRepositorio.GetById(id);
            if(conta != null)
            {
                _contaRepositorio.Remove(conta);
            }
            return RedirectToAction("Index"); ;
        }

    }
}
