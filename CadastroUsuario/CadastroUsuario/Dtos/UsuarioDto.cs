using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuario.Dtos
{
    [Table("usuario")]
    public class UsuarioDto
    {
        [Key]
        public int idusuario { get; set; }
        public string nome { get; set; }
        public string endereco { get; set; }
        public string email { get; set; }
        public string telefonefixo { get; set; }
        public string celular { get; set; }
        public DateTime datanascimento { get; set; }
    }
}
