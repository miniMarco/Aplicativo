using System;
using System.ComponentModel.DataAnnotations;

namespace Modelo
{
    public class Usuario
    {
        public int? UsuarioId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Sobrenome { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [Required]
        public string SetorId { get; set; }

        public Setor Setor { get; set; }
        [Required]
        public string Sexo { get; set; }
        [Required]
        public DateTime Aniversario { get; set; }

        public string FotoMimeType { get; set; }
        public byte[] Foto { get; set; }

    }
}