using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema.Login.Checkpoint.Repositorios;
using Sistema.Login.Checkpoint.Models;

namespace Sistema.Login.Checkpoint.Controllers
{
    public class UsuarioController
    {
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar (IFormCollection form) {            
            UsuarioModel usuario = new UsuarioModel(
                                            nome: form["nome"], 
                                            email: form["email"],
                                            senha: form["senha"],
                                            dataNascimento: DateTime.Parse (form["dataNascimento"])
                                        );

            UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
            usuarioRepositorio.Cadastrar(usuario);

            ViewBag.Mensagem = "Usuário Cadastrado";

            return RedirectToAction ("Index", "Transacao");
        }
    }
}