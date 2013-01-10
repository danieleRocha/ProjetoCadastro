using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Cadastro.Model
{
    public abstract class Pessoa
    {
        protected Pessoa()
        {
            telefones = new List<Telefone>();
        }

        public Guid ID { get; set; }
        public string Nome { get; set; }

        private List<Telefone> telefones;
        public List<Telefone> Telefones
        {
            get { return telefones; }
        }

        public bool InserirTelefone(int ddd, int numero)
        {
            Telefone novoTelefone = new Telefone(this.ID, ddd, numero);
            bool telefoneExisteNaLista = false;

            foreach (var telefone in telefones)
            {
                if (novoTelefone.IdTelefone != telefone.IdTelefone) continue;
                telefoneExisteNaLista = true;
                break;
            }

            if (telefoneExisteNaLista)
                return false;
            else
            {
                telefones.Add(novoTelefone);
                return true;
            }
        }

        public bool ExcluirTelefone(int ddd, int numero)
        {
            string idTelefone = ddd.ToString(CultureInfo.InvariantCulture) + numero.ToString(CultureInfo.InvariantCulture);

            foreach (var telefone in telefones)
            {
                if (telefone.IdTelefone == idTelefone)
                {
                    telefones.Remove(telefone);
                    return true;
                }
            }
            return false;
        }
    }
}