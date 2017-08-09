﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modelo
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Setor { get; set; }
        public char Sexo { get; set; }
        public byte[] Foto { get; set; }
        public DateTime Aniversario { get; set; }
        
    }
}