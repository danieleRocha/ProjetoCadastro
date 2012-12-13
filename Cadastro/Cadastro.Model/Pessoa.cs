using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cadastro.Model
{
    public abstract class Pessoa
    {
        protected Pessoa()
        {
            Telefones = new List<Telefone>();
        }

        public Guid ID { get; set; }
        public string Nome { get; set; }

        public List<Telefone> Telefones { get; set; }
    }
}