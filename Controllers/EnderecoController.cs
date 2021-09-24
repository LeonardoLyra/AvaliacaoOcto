using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prova_Octo.Data;
using prova_Octo.Models;

namespace prova_Octo.Controllers
{
    public class EnderecoController : Controller
    {
        [HttpGet]
        public IActionResult Index(Endereco novoEndereco)
        {

            using (var data = new EnderecoData())
            {
                return View(data.Read(Convert.ToInt32(novoEndereco.IdEndereco)));
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<string> lista = new List<string>();

            lista.Add("Cobrança");
            lista.Add("Comercial");
            lista.Add("Correspondência");
            lista.Add("Entrega");
            lista.Add("Residencial");
            
            ViewBag.Tipo = lista;

            return View();
        }

        [HttpPost]
        public IActionResult Create(IFormCollection endereco)
        {
            string idC = endereco["IdCliente"];
            string Logradouro = endereco["Logradouro"];
            string TipoEndereco = endereco["TipoEndereco"];

            var novoEndereco = new Endereco();
            novoEndereco.IdCliente = Convert.ToInt32(endereco["IdCliente"]);
            novoEndereco.Logradouro = endereco["Logradouro"];
            novoEndereco.TipoEndereco = endereco["TipoEndereco"];

            using (var data = new EnderecoData())
                data.Create(novoEndereco);

            return RedirectToAction("Index", novoEndereco);
        }

        [HttpPost]
        public IActionResult Read(IFormCollection endereco)
        {
            string idC = endereco["IdCliente"];
            string Logradouro = endereco["Logradouro"];
            string TipoEndereco = endereco["TipoEndereco"];

            var end = new Endereco();

            end.IdCliente = Convert.ToInt32(endereco["IdCliente"]);
            end.Logradouro = endereco["Logradouro"];
            end.TipoEndereco = endereco["TipoEndereco"];

            Endereco e = new Endereco();

            using (var data = new EnderecoData())
                e = data.Read(end.IdEndereco);

            return View("Create");
        }

        public IActionResult Delete(int id)
        {
            using (var data = new EnderecoData())
            {
                bool exclusao = data.Delete(id);

                if (exclusao == true)
                {
                    TempData["exclusaoSucesso"] = "A Exclusão foi realizada com sucesso!";
                }
                else
                {
                    TempData["exclusaoErro"] = "A Exclusão falhou!";
                }
            }

            Console.WriteLine(TempData["exclusao"]);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            using (var data = new EnderecoData())
                return View(data.Read(id));
        }

        [HttpPost]
        public IActionResult Update(int id, Endereco endereco)
        {
            endereco.IdEndereco = id;

            if (!ModelState.IsValid)
                return View(endereco);

            using (var data = new EnderecoData())
                data.Update(endereco);

            return RedirectToAction("Index");
        }
    }
}