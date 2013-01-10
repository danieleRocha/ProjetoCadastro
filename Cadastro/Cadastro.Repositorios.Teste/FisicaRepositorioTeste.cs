using System.Collections.Generic;
using Cadastro.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Cadastro.Model;

namespace Cadastro.Repositorios.Teste
{
    [TestClass()]
    public class FisicaRepositorioTeste
    {
        [TestMethod()]
        public void InserirTeste()
        {
            FisicaRepositorio repositorioFisica = new FisicaRepositorio();
            Fisica fisicaTeste = new Fisica
            {
                ID = Guid.NewGuid(),
                Nome = "Daniele",
                Idade = 28,
                Sexo = "Feminino",
            };
            fisicaTeste.InserirTelefone(21, 23235675);
            fisicaTeste.InserirTelefone(11, 12349090);

            repositorioFisica.Inserir(fisicaTeste);

            Fisica fisicaObtida = repositorioFisica.Obter(fisicaTeste.ID);

            Assert.AreEqual(fisicaTeste.ID, fisicaObtida.ID);

            Assert.AreEqual(fisicaTeste.Telefones.Count, fisicaObtida.Telefones.Count);

            for (int i = 0; i < fisicaTeste.Telefones.Count; i++)
            {
                Assert.AreEqual(fisicaTeste.Telefones[i].IdPessoa, fisicaObtida.Telefones[i].IdPessoa);
                Assert.AreEqual(fisicaTeste.Telefones[i].IdTelefone, fisicaObtida.Telefones[i].IdTelefone);
            }
        }

        [TestMethod()]
        public void EditarTeste()
        {
            FisicaRepositorio repositorioFisica = new FisicaRepositorio();
            Fisica fisicaTeste = new Fisica
            {
                ID = Guid.NewGuid(),
                Nome = "Daniele",
                Idade = 28,
                Sexo = "Feminino",
            };
            fisicaTeste.InserirTelefone(21, 23235676);
            fisicaTeste.InserirTelefone(11, 12349090);

            repositorioFisica.Inserir(fisicaTeste);

            //Mudanças
            fisicaTeste.Idade = 29;
            fisicaTeste.ExcluirTelefone(11, 12349090);

            repositorioFisica.Editar(fisicaTeste);

            Fisica fisicaObtida = repositorioFisica.Obter(fisicaTeste.ID);

            Assert.AreEqual(fisicaTeste.ID, fisicaObtida.ID);
            Assert.AreEqual(fisicaTeste.Idade, fisicaObtida.Idade);
            Assert.AreEqual(fisicaTeste.Telefones.Count, fisicaObtida.Telefones.Count);

            for (int i = 0; i < fisicaTeste.Telefones.Count; i++)
            {
                Assert.AreEqual(fisicaTeste.Telefones[i].IdPessoa, fisicaObtida.Telefones[i].IdPessoa);
                Assert.AreEqual(fisicaTeste.Telefones[i].IdTelefone, fisicaObtida.Telefones[i].IdTelefone);
            }
        }

        [TestMethod()]
        public void ExcluirTeste()
        {
            FisicaRepositorio repositorioFisica = new FisicaRepositorio();
            Fisica fisicaTeste = new Fisica
            {
                ID = Guid.NewGuid(),
                Nome = "Daniele",
                Idade = 28,
                Sexo = "Feminino",
            };
            fisicaTeste.InserirTelefone(21, 23235675);
            fisicaTeste.InserirTelefone(11, 12349090);

            repositorioFisica.Inserir(fisicaTeste);

            repositorioFisica.Excluir(fisicaTeste);

            Fisica fisicaObtida = repositorioFisica.Obter(fisicaTeste.ID);

            Assert.IsNull(fisicaObtida);

            //Remove telefones e insere novamente a pessoa para testar exclusão anterior na tabela de telefone.
            fisicaTeste.ExcluirTelefone(21, 23235675);
            fisicaTeste.ExcluirTelefone(11, 12349090);

            repositorioFisica.Inserir(fisicaTeste);

            Fisica fisicaObtida2 = repositorioFisica.Obter(fisicaTeste.ID);

            Assert.AreEqual(fisicaObtida2.Telefones.Count, 0);
        }

        [TestMethod()]
        public void ObterTeste()
        {
            FisicaRepositorio repositorioFisica = new FisicaRepositorio();
            Fisica fisicaTeste = new Fisica
            {
                ID = Guid.NewGuid(),
                Nome = "Daniele",
                Idade = 28,
                Sexo = "Feminino",
            };
            fisicaTeste.InserirTelefone(21, 23235675);
            fisicaTeste.InserirTelefone(11, 12349090);

            repositorioFisica.Inserir(fisicaTeste);

            Fisica fisicaObtida = repositorioFisica.Obter(fisicaTeste.ID);

            Assert.AreEqual(fisicaTeste.ID, fisicaObtida.ID);
            Assert.AreEqual(fisicaTeste.Nome.Trim(), fisicaObtida.Nome.Trim());
            Assert.AreEqual(fisicaTeste.Idade, fisicaObtida.Idade);
            Assert.AreEqual(fisicaTeste.Sexo.Trim(), fisicaObtida.Sexo.Trim());

            Assert.AreEqual(fisicaTeste.Telefones.Count, fisicaObtida.Telefones.Count);

            for (int i = 0; i < fisicaTeste.Telefones.Count; i++)
            {
                Assert.AreEqual(fisicaTeste.Telefones[i].IdPessoa, fisicaObtida.Telefones[i].IdPessoa);
                Assert.AreEqual(fisicaTeste.Telefones[i].DDD, fisicaObtida.Telefones[i].DDD);
                Assert.AreEqual(fisicaTeste.Telefones[i].Numero, fisicaObtida.Telefones[i].Numero);
            }
        }

        [TestMethod()]
        public void ObterTodosTeste()
        {
            FisicaRepositorio repositorioFisica = new FisicaRepositorio();
            Fisica fisicaTeste = new Fisica
            {
                ID = Guid.NewGuid(),
                Nome = "Daniele",
                Idade = 28,
                Sexo = "Feminino",
            };
            fisicaTeste.InserirTelefone(21, 23235675);
            fisicaTeste.InserirTelefone(11, 12349090);

            Fisica fisicaTeste2 = new Fisica
            {
                ID = Guid.NewGuid(),
                Nome = "Daniel",
                Idade = 30,
                Sexo = "Masculino",
            };
            fisicaTeste2.InserirTelefone(13, 12219037);
            fisicaTeste2.InserirTelefone(65, 33230967);
            List<Fisica> listaEsperada = new List<Fisica> { fisicaTeste, fisicaTeste2 };

            List<Fisica> fisicasExistentesNoBanco = repositorioFisica.ObterTodos();

            foreach (var fisica in fisicasExistentesNoBanco)
            {
                repositorioFisica.Excluir(fisica);
            }

            repositorioFisica.Inserir(fisicaTeste);
            repositorioFisica.Inserir(fisicaTeste2);

            List<Fisica> fisicas = repositorioFisica.ObterTodos();

            Assert.AreEqual(fisicas.Count, listaEsperada.Count);

            bool retornouPrimeiraPessoa = false;
            bool retornouSegundaPessoa = false;

            foreach (var fisica in fisicas)
            {
                if (fisica.ID == fisicaTeste.ID)
                    retornouPrimeiraPessoa = true;
                else if (fisica.ID == fisicaTeste2.ID)
                    retornouSegundaPessoa = true;
            }

            Assert.IsTrue(retornouPrimeiraPessoa);
            Assert.IsTrue(retornouSegundaPessoa);

        }
    }
}
