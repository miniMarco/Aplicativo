using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Evento
    {
        [Key]
        public int EventoId { get; set; }

        [Required]
        public string Nome { get; set; }
        
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        public string Descricao { get; set; }
    }
}
