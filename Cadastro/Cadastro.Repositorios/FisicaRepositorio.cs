using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cadastro.DAL;
using Cadastro.Factory;
using Cadastro.Model;

namespace Cadastro.Repositorios
{
    public class FisicaRepositorio
    {
        private List<Fisica> pessoasFisicas = new List<Fisica>();
        private IDAL<Fisica> dao = DaoFactory.GetFisicaDao();

        public void Salvar(Fisica pessoa)
        {
            pessoasFisicas.Add(pessoa);
        }

        public void Excluir(Fisica pessoa)
        {
            pessoasFisicas.Remove(pessoa);
        }

        public Pessoa Buscar(Guid id)
        {
            return pessoasFisicas.FirstOrDefault(p => p.ID == id);
        }
    }
}
