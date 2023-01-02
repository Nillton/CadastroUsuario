using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuario.Models
{
    public class UsuarioModel
    {
        [Key]
        public int? IdUsuario { get; set; }
        public string? Nome { get; set; }
        public string? Endereco { get; set; }
        public string? Email { get; set; }
        public string? TeleFoneFixo { get; set; }
        public string? Celular { get; set; }
        public string? DataNascimento { get; set; }
    }
}
