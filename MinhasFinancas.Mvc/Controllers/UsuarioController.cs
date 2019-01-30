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
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(int? Id)
        {
            if (Id != null)
            {
                if (Id == 0)
                {
                    HttpContext.Session.SetString("IdUsuarioLogado", string.Empty);
                    HttpContext.Session.SetString("NomeUsuarioLogado", string.Empty);
                }
            }


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Usuario usuario)
        {
            int retorno = _usuarioRepositorio.VerificarUsuario(usuario.Email, usuario.Senha);

            if (retorno == 0) // INSUCESSO
            {
                TempData["MensagemLoginInvalido"] = "Dados de login inválidos!";
                return View();
            }
            else //SUCESSO
            {
                Usuario usuarioLogado = _usuarioRepositorio.PegarUsuarioPorEmail(usuario.Email);
                HttpContext.Session.SetString("NomeUsuarioLogado", usuarioLogado.Nome);
                HttpContext.Session.SetString("IdUsuarioLogado", usuarioLogado.Id.ToString());
                return RedirectToAction("Menu","Home");
            }

        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registrar(Usuario usuario)
        {
            if(ModelState.IsValid)
            {
                _usuarioRepositorio.AdicionarUsuario(usuario);
                return RedirectToAction("Login");
            }
            
            return View();
        }

        public IActionResult Sucesso()
        {
            return View();
        }


    }
}
