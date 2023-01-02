using CadastroUsuario.Context;
using CadastroUsuario.Dtos;
using CadastroUsuario.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CadastroUsuario.Services
{
    public class UsuarioService
    {
        UsuarioModel usuarioModel = new UsuarioModel();
        ContextDbUsuario context = new ContextDbUsuario();        

        public bool CadastraUsuario(UsuarioModel usuario)
        {
            context.Usuario.Add(usuario);
            context.SaveChanges();
            return true;
        }

        public UsuarioDto PesquisaUsuario(int? idUsuario)
        {            
            UsuarioDto result = context.UsuarioDto.Find(idUsuario);
            return result;
        }

        public bool DeleteUsuario(int idUsuario)
        {
            UsuarioDto usuario = context.UsuarioDto.Find(idUsuario);
            if (usuario == null)
            {
                return false;
            }
            else
            {
                context.Remove(usuario);
                context.SaveChanges();
                return true;
            }
        }

        public bool UpdateUsuario(UsuarioModel usuario) 
        {
            context.Update(usuario);
            context.SaveChanges();
            return true;
        }
    }
}
