using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Cadastro.Model;

namespace Cadastro.DAL.SqlProvider
{
    public class TelefoneDao : BaseDao<Telefone>
    {
        protected override string ObterComandoSelect()
        {
            return "SELECT * FROM TELEFONE";
        }

        protected override string ObterComandoSelect(Guid id)
        {
            return "SELECT * FROM TELEFONE WHERE ID = '" + id + "'";
        }

        protected override string ObterComandoUpdate(Telefone entidade)
        {
            string propriedades = "DDD = " + entidade.DDD + "," +
                "Numero = " + entidade.Numero;
            return "UPDATE TELEFONE SET " + propriedades + " WHERE ID = '" + entidade.IdPessoa + "'";
        }

        protected override string ObterComandoDelete(Telefone entidade)
        {
            return "DELETE FROM TELEFONE WHERE ID = '" + entidade.IdPessoa + "'";
        }

        protected override string ObterComandoDelete(Guid id)
        {
            return "DELETE FROM TELEFONE WHERE ID = '" + id + "'";
        }

        protected override string ObterComandoInsert(Telefone entidade)
        {
            return String.Format("INSERT INTO TELEFONE (ID, DDD, NUMERO) VALUES ('{0}', {1}, {2})",
               entidade.IdPessoa, entidade.DDD, entidade.Numero);
        }

        protected override Telefone HidratarEntidade(SqlDataReader reader)
        {
            Telefone telefone = new Telefone(IdPessoa: Guid.Parse(reader[0].ToString()), DDD: int.Parse(reader[1].ToString()), Numero: int.Parse(reader[2].ToString()));
               
            return telefone;
        }

        
    }
}
