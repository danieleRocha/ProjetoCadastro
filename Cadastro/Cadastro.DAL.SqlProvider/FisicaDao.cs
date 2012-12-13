using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Cadastro.Model;

namespace Cadastro.DAL.SqlProvider
{
    public class FisicaDao : BaseDao<Fisica>
    {
        protected override string ObterComandoSelect()
        {
            return "SELECT * FROM FISICA";
        }

        protected override string ObterComandoSelect(Guid id)
        {
            return "SELECT * FROM FISICA WHERE ID = '" + id + "'";
        }

        protected override string ObterComandoUpdate(Fisica entidade)
        {
            string propriedades = "Nome = '" + entidade.Nome + "'" + "," +
                "Idade = " + entidade.Idade + "," +
                "Sexo = '" + entidade.Sexo + "'";
            return "UPDATE FISICA SET " + propriedades + " WHERE ID = '" + entidade.ID + "'";
        }

        protected override string ObterComandoDelete(Fisica entidade)
        {
            return "DELETE FROM FISICA WHERE ID = '" + entidade.ID + "'";
        }

        protected override string ObterComandoInsert(Fisica entidade)
        {
            return String.Format("INSERT INTO FISICA (ID, NOME, IDADE, SEXO) VALUES ('{0}', '{1}', {2}, '{3}')",
                entidade.ID, entidade.Nome, entidade.Idade, entidade.Sexo);
        }

        protected override Fisica HidratarEntidade(SqlDataReader reader)
        {
            Fisica fisica = new Fisica
                {
                    ID = Guid.Parse(reader[0].ToString()),
                    Nome = reader[1].ToString(),
                    Idade = int.Parse(reader[2].ToString()),
                    Sexo = reader[3].ToString()
                };
            //fisica.Telefones = ???

            return fisica;
        }

    }
}
