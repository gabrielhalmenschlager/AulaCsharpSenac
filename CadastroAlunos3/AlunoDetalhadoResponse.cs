﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroAlunos3
{
    public class AlunoDetalhadoResponse
    {
        public string Nome { get; set; }

        public int Idade { get; set; }
        
        public string Cpf { get; set; }
        
        public Guid Matricula { get; set; }
    }
}
