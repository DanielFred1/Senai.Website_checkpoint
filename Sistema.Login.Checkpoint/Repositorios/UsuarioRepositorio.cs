using System;
using System.Collections.Generic;
using System.IO;
using Sistema.Login.Checkpoint.Models;
using Sistema.Login.Checkpoint.Interfaces;


namespace Sistema.Login.Checkpoint.Repositorios
{
    public class UsuarioRepositorio : InterfaceUsuario
    {
        public UsuarioModel BuscarId(int id)
        {
            string[] linhas = System.IO.File.ReadAllLines("Usuario.csv");

            foreach (var item in linhas)
            {
                string[] dados = item.Split(';');

                if (id.ToString() == dados[0])
                {
                    UsuarioModel usuario = new UsuarioModel(
                            id: int.Parse (dados[0]),
                            nome: dados[1],
                            email: dados[2],
                            senha: dados[3],
                            dataNascimento: DateTime.Parse (dados[4])
                        );
                    return usuario;
                }
            }
            return null;
        }

        public UsuarioModel Cadastrar(UsuarioModel usuario)
        {
            if (File.Exists("Usuario.csv"))
            {
                usuario.Id = File.ReadAllLines("Usuario.csv").Length + 1;
            } else
            {
                usuario.Id = 1;
            }

            using (StreamWriter sw = new StreamWriter("Usuario.csv", true))
            {
                sw.WriteLine($"{usuario.Id};{usuario.Nome};{usuario.Email};{usuario.Senha};{usuario.DataNascimento}");
            }

            return usuario;
        }

        public UsuarioModel Login(string email, string senha)
        {
            using (StreamReader sr = new StreamReader ("usuarios.csv"))
            {
                while (!sr.EndOfStream)
                {
                    var linha = sr.ReadLine ();

                    if (string.IsNullOrEmpty(linha))
                    {
                        continue;
                    }

                    string[] dados = linha.Split (";");

                    if (dados[2] == email && dados[3] == senha)
                    {
                        UsuarioModel usuario = new UsuarioModel(
                            id: int.Parse (dados[0]),
                            nome: dados[1],
                            email: dados[2],
                            senha: dados[3],
                            dataNascimento: DateTime.Parse (dados[4])
                        );

                        return usuario;
                    }
                }
            }
            return null;
        }
    }
}