using System.Collections.Generic;

namespace Modelo
{
    public class Setor
    {
        public int SetorId { get; set; }
        public string Nome { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
    }
}
