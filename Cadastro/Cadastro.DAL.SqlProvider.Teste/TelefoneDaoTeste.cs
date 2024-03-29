﻿using System.Collections.Generic;
using Cadastro.DAL.SqlProvider;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Cadastro.Model;


namespace Cadastro.DAL.SqlProvider.Teste
{
    [TestClass()]
    public class TelefoneDaoTeste
    {
        [TestMethod()]
        [DeploymentItem("Cadastro.DAL.SqlProvider.dll")]
        public void InsertTelefoneTeste()
        {
            Telefone telefoneTeste = new Telefone(IdPessoa: Guid.NewGuid(), DDD: 21, Numero: 21213344);

            IDAL<Telefone> dao = Factory.DaoFactory.GetTelefoneDao();
            dao.Insert(telefoneTeste);

            Guid id = telefoneTeste.IdPessoa;
            Telefone telefone = dao.Get(id);

            Assert.AreEqual(id, telefone.IdPessoa);
        }

        [TestMethod()]
        [DeploymentItem("Cadastro.DAL.SqlProvider.dll")]
        public void GetTelefoneTeste()
        {
            Telefone telefoneTeste = new Telefone(IdPessoa : Guid.NewGuid(),DDD : 21,Numero : 21213344);

            IDAL<Telefone> dao = Factory.DaoFactory.GetTelefoneDao();
            dao.Insert(telefoneTeste);

            Guid id = telefoneTeste.IdPessoa;
            Telefone telefone = dao.Get(id);

            Assert.AreEqual(id, telefone.IdPessoa);
        }

        [TestMethod()]
        [DeploymentItem("Cadastro.DAL.SqlProvider.dll")]
        public void GetAllTelefoneTeste()
        {
            Telefone telefoneTeste = new Telefone(IdPessoa : Guid.NewGuid(),DDD: 21,Numero: 21213344);

            Telefone telefoneTeste2 = new Telefone(IdPessoa : Guid.NewGuid(),DDD : 51,Numero : 51513344);

            IDAL<Telefone> dao = Factory.DaoFactory.GetTelefoneDao();
            dao.Insert(telefoneTeste);
            dao.Insert(telefoneTeste2);

            List<Telefone> listaObtida = dao.GetAll();

            bool encontrouTelefone = false;
            bool encontrouTelefone2 = false;

            foreach (var fisica in listaObtida)
            {
                if (fisica.IdPessoa == telefoneTeste.IdPessoa)
                    encontrouTelefone = true;
                if (fisica.IdPessoa == telefoneTeste2.IdPessoa)
                    encontrouTelefone2 = true;
            }

            Assert.IsTrue(encontrouTelefone);
            Assert.IsTrue(encontrouTelefone2);

        }

        [TestMethod()]
        [DeploymentItem("Cadastro.DAL.SqlProvider.dll")]
        public void UpdateTelefoneTeste()
        {
            Telefone telefoneTeste = new Telefone(IdPessoa : Guid.NewGuid(),DDD : 21,Numero : 21213344);

            IDAL<Telefone> dao = Factory.DaoFactory.GetTelefoneDao();
            dao.Insert(telefoneTeste);

            Guid id = telefoneTeste.IdPessoa;
            Telefone telefone = dao.Get(id);

            const int novoDdd = 29;
            const int novoNumero = 34356768;

            telefone.DDD = novoDdd;
            telefone.Numero = novoNumero;
            dao.Update(telefone);

            Telefone telefoneNovo = dao.Get(id);

            Assert.AreEqual(telefoneNovo.DDD, novoDdd);
            Assert.AreEqual(telefoneNovo.Numero, novoNumero);
        }

        [TestMethod()]
        [DeploymentItem("Cadastro.DAL.SqlProvider.dll")]
        public void DeleteTelefoneTeste()
        {
            Telefone telefoneTeste = new Telefone(IdPessoa: Guid.NewGuid(), DDD: 21, Numero: 21213344);

            IDAL<Telefone> dao = Factory.DaoFactory.GetTelefoneDao();
            dao.Insert(telefoneTeste);

            Guid id = telefoneTeste.IdPessoa;

            dao.Delete(telefoneTeste);

            Telefone telefone = dao.Get(id);

            Assert.IsNull(telefone);
        }
    }
}
