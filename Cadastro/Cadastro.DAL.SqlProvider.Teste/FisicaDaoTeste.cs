using System.Collections.Generic;
using Cadastro.DAL.SqlProvider;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Cadastro.Model;


namespace Cadastro.DAL.SqlProvider.Teste
{
    [TestClass()]
    public class FisicaDaoTeste
    {
        [TestMethod()]
        [DeploymentItem("Cadastro.DAL.SqlProvider.dll")]
        public void InsertFisicaTeste()
        {
            Fisica fisicaTeste = new Fisica
                       {
                           ID = Guid.NewGuid(),
                           Nome = "Daniele",
                           Idade = 28,
                           Sexo = "Feminino"
                       };

            IDAL<Fisica> dao = Factory.DaoFactory.GetFisicaDao();
            dao.Insert(fisicaTeste);

            Guid id = fisicaTeste.ID;
            Fisica fisica = dao.Get(id);

            Assert.AreEqual(id, fisica.ID);
        }

        [TestMethod()]
        [DeploymentItem("Cadastro.DAL.SqlProvider.dll")]
        public void GetFisicaTeste()
        {
            Fisica fisicaTeste = new Fisica
            {
                ID = Guid.NewGuid(),
                Nome = "Daniele",
                Idade = 28,
                Sexo = "Feminino"
            };

            IDAL<Fisica> dao = Factory.DaoFactory.GetFisicaDao();
            dao.Insert(fisicaTeste);
            
            Guid id = fisicaTeste.ID;
            Fisica fisica = dao.Get(id);

            Assert.AreEqual(id, fisica.ID);
        }

        [TestMethod()]
        [DeploymentItem("Cadastro.DAL.SqlProvider.dll")]
        public void GetAllFisicaTeste()
        {
            Fisica fisicaTeste = new Fisica
            {
                ID = Guid.NewGuid(),
                Nome = "Daniele",
                Idade = 28,
                Sexo = "Feminino"
            };

            Fisica fisicaTeste2 = new Fisica
            {
                ID = Guid.NewGuid(),
                Nome = "Dani",
                Idade = 25,
                Sexo = "Feminino"
            };

            IDAL<Fisica> dao = Factory.DaoFactory.GetFisicaDao();
            dao.Insert(fisicaTeste);
            dao.Insert(fisicaTeste2);
            
            List<Fisica> listaObtida = dao.GetAll();

            bool encontrouFisica = false;
            bool encontrouFisica2 = false;

            foreach (var fisica in listaObtida)
            {
                if(fisica.ID == fisicaTeste.ID)
                    encontrouFisica = true;
                if(fisica.ID == fisicaTeste2.ID)
                    encontrouFisica2 = true;
            }

            Assert.IsTrue(encontrouFisica);
            Assert.IsTrue(encontrouFisica2);
            
        }

        [TestMethod()]
        [DeploymentItem("Cadastro.DAL.SqlProvider.dll")]
        public void UpdateFisicaTeste()
        {
            Fisica fisicaTeste = new Fisica
            {
                ID = Guid.NewGuid(),
                Nome = "Daniele",
                Idade = 28,
                Sexo = "Feminino"
            };

            IDAL<Fisica> dao = Factory.DaoFactory.GetFisicaDao();
            dao.Insert(fisicaTeste);

            Guid id = fisicaTeste.ID;
            Fisica fisica = dao.Get(id);

            const int novaIdade = 29;
            const string novoNome = "Dani";

            fisica.Idade = novaIdade;
            fisica.Nome = novoNome;
            dao.Update(fisica);

            Fisica fisicaNova = dao.Get(id);

            Assert.AreEqual(fisicaNova.Idade, novaIdade);
            Assert.AreEqual(fisicaNova.Nome.Trim(), novoNome.Trim());
        }

        [TestMethod()]
        [DeploymentItem("Cadastro.DAL.SqlProvider.dll")]
        public void DeleteFisicaTeste()
        {
            Fisica fisicaTeste = new Fisica
            {
                ID = Guid.NewGuid(),
                Nome = "Daniele",
                Idade = 28,
                Sexo = "Feminino"
            };

            IDAL<Fisica> dao = Factory.DaoFactory.GetFisicaDao();
            dao.Insert(fisicaTeste);

            Guid id = fisicaTeste.ID;
            dao.Delete(fisicaTeste);

            Fisica fisica = dao.Get(id);

            Assert.IsNull(fisica);
        }
    }
}
