using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prova_Octo.Data;
using prova_Octo.Models;

namespace prova_Octo.Controllers
{
    
    public class ClienteController : Controller
    {
        
        [HttpGet]
        public IActionResult Index()
        {

            using (var data = new ClienteData())
            {
                return View(data.Read());
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<string> lista = new List<string>();

            lista.Add("PF");
            lista.Add("PJ");

            ViewBag.Tipo = lista;

            ViewBag.TipoC = "PF";

            return View();
        }

        [HttpPost]
        public IActionResult Create(IFormCollection cliente)
        {
            string nome = cliente["Nome"];
            string tipo = cliente["TipoCliente"];
            string cpf_cnpj = cliente["CPF_CNPJ"];

            if (nome.Length < 6)
            {
                ViewBag.Mensagem = "Nome deve conter 6 ou mais carecteres";
            }

            var novoCliente = new Cliente();
            novoCliente.Nome = cliente["nome"];
            novoCliente.TipoCliente = cliente["TipoCliente"];
            novoCliente.CPF_CNPJ = cliente["CPF_CNPJ"];

            using (var data = new ClienteData())
                data.Create(novoCliente);

            return RedirectToAction("Index", novoCliente);
        }

        [HttpPost]
        public IActionResult Read(IFormCollection cliente)
        {
            string nome = cliente["Nome"];
            string tipo = cliente["TipoCliente"];
            string cpf_cnpj = cliente["CPF_CNPJ"];

            if (!nome.Equals(" "))
            {
                var cli = new Cliente();

                cli.Nome = cliente["Nome"];
                cli.TipoCliente = cliente["TipoCliente"];
                cli.CPF_CNPJ = cliente["CPF_CNPJ"];

                Cliente c = new Cliente();

                using (var data = new ClienteData())
                    c = data.Read(Convert.ToInt32(cli.IdCliente));

            }

            return View("Create");
        }

        public IActionResult Delete(int id)
        {
            using (var data = new ClienteData())
            {
                bool exclusao = data.Delete(id);

                if (exclusao == true)
                {
                    TempData["exclusaoSucesso"] = "A Exclusão foi realizada com sucesso";
                }
                else
                {
                    TempData["exclusaoErro"] = "A Exclusão falhou, pode haver algum telefone ou endereco atrelado ao ID deste cliente";
                }
            }

            Console.WriteLine(TempData["exclusao"]);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            using (var data = new ClienteData())
                return View(data.Read(id));
        }

        [HttpPost]
        public IActionResult Update(int id, Cliente cliente)
        {
            cliente.IdCliente = id;

            if (!ModelState.IsValid)
                return View(cliente);

            using (var data = new ClienteData())
                data.Update(cliente);

            return RedirectToAction("Index");
        }
    }
}