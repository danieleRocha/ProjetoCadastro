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
        private IDAL<Fisica> fisicaDao;
        private IDAL<Telefone> telefoneDao;

        public FisicaRepositorio()
        {
            fisicaDao = DaoFactory.GetFisicaDao();
            telefoneDao = DaoFactory.GetTelefoneDao();
        }

        public void Inserir(Fisica pessoa)
        {
            fisicaDao.Insert(pessoa);

            foreach (var telefone in pessoa.Telefones)
            {
                telefoneDao.Insert(telefone);
            }
        }

        public void Editar(Fisica pessoa)
        {
            fisicaDao.Update(pessoa);
            telefoneDao.Delete(pessoa.ID);

            foreach (var telefone in pessoa.Telefones)
            {
                telefoneDao.Insert(telefone);
            }
        }

        public void Excluir(Fisica pessoa)
        {
            fisicaDao.Delete(pessoa);
            telefoneDao.Delete(pessoa.ID);
        }

        public Fisica Obter(Guid id)
        {
            Fisica fisica = fisicaDao.Get(id);

            List<Telefone> telefones = telefoneDao.GetList(id);

            foreach (var telefone in telefones)
            {
                fisica.InserirTelefone(telefone.DDD, telefone.Numero);
            }

            return fisica;
        }

        public List<Fisica> ObterTodos()
        {
            List<Fisica> fisicas = fisicaDao.GetAll();

            foreach (var fisica in fisicas)
            {
                List<Telefone> telefones = telefoneDao.GetList(fisica.ID);

                foreach (var telefone in telefones)
                {
                    fisica.InserirTelefone(telefone.DDD, telefone.Numero);
                }
            }

            return fisicas;
        }
    }
}
