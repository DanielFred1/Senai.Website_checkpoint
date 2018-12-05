using System.Collections.Generic;
using Sistema.Login.Checkpoint.Models;

namespace Sistema.Login.Checkpoint.Interfaces
{
    /// <summary>
    /// Interface do Usuário, define métodos 
    /// que são herdados por outras classes
    /// </summary>
    public class InterfaceUsuario
    {
        UsuarioModel Cadastrar(UsuarioModel usuario);

         UsuarioModel Login(string email, string senha);

         UsuarioModel BuscarId(int id);
    }
}