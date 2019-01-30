using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.Domain.Entidades;
using MinhasFinancas.Domain.Interfaces;
using MinhasFinancas.Mvc.Models.Transacao;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MinhasFinancas.Mvc.Controllers
{
    public class TransacaoController : Controller
    {
        private readonly ITransacaoRepositorio _transacaoRepositorio;
        private readonly IContaRepositorio _contaRepositorio;
        private readonly IPlanoContaRepositorio _planocontaRepositorio;
        IHttpContextAccessor HttpContextAccessor;

        public TransacaoController(ITransacaoRepositorio transacaoRepositorio, IHttpContextAccessor httpContextAccessor, IContaRepositorio contaRepositorio, IPlanoContaRepositorio planoContaRepositorio)
        {
            _transacaoRepositorio = transacaoRepositorio;
            _contaRepositorio = contaRepositorio;
            _planocontaRepositorio = planoContaRepositorio;
            HttpContextAccessor = httpContextAccessor;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<TransacaoModel> listaTransacoes = new List<TransacaoModel>();
            string usuarioId = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            int usuario_id = int.Parse(usuarioId);

            List<Transacao> listatransacoesPorusuario = _transacaoRepositorio.ListarTransacoesPorUsuario(usuario_id);

            foreach(Transacao transacao in listatransacoesPorusuario)
            {
                TransacaoModel objTransacao = new TransacaoModel();
                objTransacao.Id = transacao.Id;
                objTransacao.Data = transacao.Data;
                objTransacao.Tipo = transacao.Tipo;
                objTransacao.Valor = transacao.Valor;
                objTransacao.Descricao = transacao.Descricao;
                objTransacao.NomeConta = _contaRepositorio.GetById(transacao.Conta_Id).Nome;
                objTransacao.DescricaoPlanoConta = _planocontaRepositorio.GetById(transacao.Plano_Contas_Id).Descricao;

                listaTransacoes.Add(objTransacao);
            }

            return View(listaTransacoes);
        }

        [HttpGet]
        public IActionResult EditarTransacao(int id)
        {
            Transacao transacao = _transacaoRepositorio.GetById(id);
            List<string> listaDeContas = _contaRepositorio.ListarNomeContasPorUsuario(transacao.Usuario_Id);
            List<string> listaDePlanoContas = _planocontaRepositorio.ListarNomePlanoContasPorUsuario(transacao.Usuario_Id);

            ViewBag.ListaContas = listaDeContas;
            ViewBag.ListaPlanoContas = listaDePlanoContas;

            TransacaoModel objTransacao = new TransacaoModel();
            objTransacao.Id = id;
            objTransacao.Data = transacao.Data;
            objTransacao.Tipo = transacao.Tipo;
            objTransacao.Valor = transacao.Valor;
            objTransacao.Descricao = transacao.Descricao;
            objTransacao.NomeConta = _contaRepositorio.GetById(transacao.Conta_Id).Nome;
            objTransacao.DescricaoPlanoConta = _planocontaRepositorio.GetById(transacao.Plano_Contas_Id).Descricao;

            return View(objTransacao);
        }

        [HttpPost]
        public IActionResult EditarTransacao(TransacaoModel objTransacao)
        {
            string usuarioId = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            int usuario_id = int.Parse(usuarioId);
            
            if (ModelState.IsValid)
            {
                if (objTransacao != null)
                {
                    Transacao transacao = _transacaoRepositorio.GetById(objTransacao.Id);

                    transacao.Data = Convert.ToDateTime(objTransacao.Data);
                    transacao.Tipo = objTransacao.Tipo;
                    transacao.Valor = Convert.ToDecimal(objTransacao.Valor);
                    transacao.Descricao = objTransacao.Descricao;
                    transacao.Conta_Id = _contaRepositorio.PegarIdContaPorNome(usuario_id, objTransacao.NomeConta);
                    transacao.Plano_Contas_Id = _planocontaRepositorio.PegarIdPlanoContaPorNome(usuario_id, objTransacao.DescricaoPlanoConta);
                    transacao.Usuario_Id = usuario_id;

                    _transacaoRepositorio.Update(transacao);

                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        public IActionResult CriarTransacao()
        {
            string usuarioId = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            int usuario_id = int.Parse(usuarioId);

            List<string> listaDeContas = _contaRepositorio.ListarNomeContasPorUsuario(usuario_id);
            List<string> listaDePlanoContas = _planocontaRepositorio.ListarNomePlanoContasPorUsuario(usuario_id);

            ViewBag.ListaContas = listaDeContas;
            ViewBag.ListaPlanoContas = listaDePlanoContas;

            return View();
        }

        [HttpPost]
        public IActionResult CriarTransacao(TransacaoModel objTransacao)
        {
            string usuarioId = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            int usuario_id = int.Parse(usuarioId);

            if (ModelState.IsValid)
            {
                if (objTransacao != null)
                {
                    Transacao transacao = new Transacao();
                    
                    transacao.Data = Convert.ToDateTime(objTransacao.Data);
                    transacao.Tipo = objTransacao.Tipo;
                    transacao.Valor = Convert.ToDecimal(objTransacao.Valor);
                    transacao.Descricao = objTransacao.Descricao;
                    transacao.Conta_Id = _contaRepositorio.PegarIdContaPorNome(usuario_id, objTransacao.NomeConta);
                    transacao.Plano_Contas_Id = _planocontaRepositorio.PegarIdPlanoContaPorNome(usuario_id, objTransacao.DescricaoPlanoConta);
                    transacao.Usuario_Id = usuario_id;

                    _transacaoRepositorio.Add(transacao);

                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        [HttpGet]
        [HttpPost]
        public IActionResult Extrato(TransacaoModel objTransacao)
        {
            decimal Saldo = 0;

            string usuarioId = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            int usuario_id = int.Parse(usuarioId);

            List<string> listaDeContas = _contaRepositorio.ListarNomeContasPorUsuario(usuario_id);
            List<string> listaDePlanoContas = _planocontaRepositorio.ListarNomePlanoContasPorUsuario(usuario_id);

            ViewBag.ListaContas = listaDeContas;
            ViewBag.ListaPlanoContas = listaDePlanoContas;

            List<Transacao> listaTransacoes = new List<Transacao>();
            List<TransacaoModel> lista = new List<TransacaoModel>();

            try
            {
                int contaId = _contaRepositorio.PegarIdContaPorNome(usuario_id, objTransacao.NomeConta);
                int planoContaId = _planocontaRepositorio.PegarIdPlanoContaPorNome(usuario_id, objTransacao.DescricaoPlanoConta);
                listaTransacoes = _transacaoRepositorio.FiltrarTransacoes(objTransacao.Data, objTransacao.Tipo, contaId, planoContaId);

                foreach(Transacao transacao in listaTransacoes)
                {
                    TransacaoModel trm = new TransacaoModel();
                    decimal parcela = 0;
                    trm.Id = transacao.Id;
                    trm.Data = transacao.Data;
                    trm.Tipo = transacao.Tipo;
                    trm.Valor = transacao.Valor;
                    trm.Descricao = transacao.Descricao;
                    trm.NomeConta = _contaRepositorio.PegarNomeContaPorId(usuario_id, transacao.Conta_Id);
                    trm.DescricaoPlanoConta = _planocontaRepositorio.PegarNomePlanoContaPorId(usuario_id, planoContaId);
                    parcela = trm.Valor;
                    lista.Add(trm);
                    Saldo = Saldo + parcela;
                }
            }
            catch { }

            ViewBag.ListaTransacao = lista;
            ViewBag.Saldo = Saldo;

            return View();
        }


        public IActionResult Dashboard()
        {
            ViewBag.Valores = "10,20,30,40,50";
            ViewBag.Rotulos = "10,20,30,40,50";
            ViewBag.Cores = "'#2F4F2F','#5C3317','#6B238E','#FFFF00','#C0D9D9'";

            return View();
        }

        public IActionResult Ajuda()
        {
            return View();
        }

    }
}
