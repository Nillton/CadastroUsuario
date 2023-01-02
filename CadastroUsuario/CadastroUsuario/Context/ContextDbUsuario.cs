using CadastroUsuario.Dtos;
using CadastroUsuario.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CadastroUsuario.Context
{
    public class ContextDbUsuario : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = @"Server=localhost;DataBase=cadastro;Uid=root;Pwd=root";
            optionsBuilder.UseMySql(connection, ServerVersion.AutoDetect(connection));
        }
        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<UsuarioDto> UsuarioDto { get; set; }
    }
}
