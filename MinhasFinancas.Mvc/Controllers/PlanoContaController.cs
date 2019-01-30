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
    public class PlanoContaController : Controller
    {
        private readonly IPlanoContaRepositorio _planocontaRepositorio;
        IHttpContextAccessor HttpContextAccessor;

        public PlanoContaController(IPlanoContaRepositorio planocontaRepositorio, IHttpContextAccessor httpContextAccessor)
        {
            _planocontaRepositorio = planocontaRepositorio;
            HttpContextAccessor = httpContextAccessor;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            string usuarioId = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            int usuario_id = int.Parse(usuarioId);
            List<Plano_Conta> lista_planoContas = _planocontaRepositorio.ListarPlanoContasPorUsuario(usuario_id);

            return View(lista_planoContas);
        }

        [HttpGet]
        public IActionResult CriarPlanoConta()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CriarPlanoConta(Plano_Conta plano_conta)
        {
            if (ModelState.IsValid)
            {
                if (plano_conta != null)
                {
                    string usuarioId = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
                    plano_conta.Usuario_Id = int.Parse(usuarioId);
                    _planocontaRepositorio.Add(plano_conta);
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult ExcluirPlanoConta(int id)
        {
            Plano_Conta plano_conta = _planocontaRepositorio.GetById(id);
            if (plano_conta != null)
            {
                _planocontaRepositorio.Remove(plano_conta);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditarPlanoConta(int id)
        {
            Plano_Conta plano_conta = _planocontaRepositorio.GetById(id);
            return View(plano_conta);
        }

        [HttpPost]
        public IActionResult EditarPlanoConta(Plano_Conta objPlanoConta)
        {
            if (ModelState.IsValid)
            {
                if (objPlanoConta != null)
                {
                    string usuarioId = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
                    objPlanoConta.Usuario_Id = int.Parse(usuarioId);
                    _planocontaRepositorio.Update(objPlanoConta);
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

    }
}
