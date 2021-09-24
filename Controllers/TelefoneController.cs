using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prova_Octo.Data;
using prova_Octo.Models;

namespace prova_Octo.Controllers
{
    public class TelefoneController : Controller
    {
        [HttpGet]
        public IActionResult Index(Telefone novoTelefone)
        {

            using (var data = new TelefoneData())
            {
                return View(data.Read(Convert.ToInt32(novoTelefone.IdTelefone)));
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<string> lista = new List<string>();

            lista.Add("Celular");
            lista.Add("Residencial");
            lista.Add("Comercial");
            ViewBag.Tipo = lista;

            
            return View();
        }

        [HttpPost]
        public IActionResult Create(IFormCollection telefone)
        {
            string idC = telefone["IdCliente"];
            string NumeroTelefone = telefone["NumeroTelefone"];
            string TipoTelefone = telefone["TipoTelefone"];

            var novoTelefone = new Telefone();
            novoTelefone.IdCliente = Convert.ToInt32(telefone["IdCliente"]);
            novoTelefone.NumeroTelefone = telefone["NumeroTelefone"];
            novoTelefone.TipoTelefone = telefone["TipoTelefone"];

            using (var data = new TelefoneData())
                data.Create(novoTelefone);

            return RedirectToAction("Index", novoTelefone);
        }

        [HttpPost]
        public IActionResult Read(IFormCollection telefone)
        {
            string idC = telefone["IdCliente"];
            string NumeroTelefone = telefone["NumeroTelefone"];
            string TipoTelefone = telefone["TipoTelefone"];

            var tel = new Telefone();

            tel.IdCliente = Convert.ToInt32(telefone["IdCliente"]);
            tel.NumeroTelefone = telefone["NumeroTelefone"];
            tel.TipoTelefone = telefone["TipoTelefone"];

            Telefone t = new Telefone();

            using (var data = new TelefoneData())
                t = data.Read(tel.IdTelefone);

            return View("Create");
        }

        public IActionResult Delete(int id)
        {
            using (var data = new TelefoneData())
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
            using (var data = new TelefoneData())
                return View(data.Read(id));
        }

        [HttpPost]
        public IActionResult Update(int id, Telefone telefone)
        {
            telefone.IdTelefone = id;

            if (!ModelState.IsValid)
                return View(telefone);

            using (var data = new TelefoneData())
                data.Update(telefone);

            return RedirectToAction("Index");
        }
    }
}