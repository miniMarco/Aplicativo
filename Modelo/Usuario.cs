using System;
using System.ComponentModel.DataAnnotations;

namespace Modelo
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Senha { get; set; }
        public Setor Setor { get; set; }
        public char Sexo { get; set; }
        public byte[] Foto { get; set; }
        public DateTime Aniversario { get; set; }
        
    }
}