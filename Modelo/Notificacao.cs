using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Notificacao
    {
        [Key]
        public int? NotificacaoId { get; set; }
        public string Nome { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public bool Aniversario { get; set; }
    }
}
