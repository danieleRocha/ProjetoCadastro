using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;

namespace Cadastro.DAL.SqlProvider
{
    public abstract class BaseDao<T> : IDAL<T>
    {
        private static string localDaBase = Directory.GetParent(Assembly.GetExecutingAssembly().Location).Parent.Parent.Parent.FullName +@"\BaseDeTeste.mdf";
        private static string ConnectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=" + localDaBase + ";Integrated Security=True;Connect Timeout=30;User Instance=True";
       
        public List<T> GetAll()
        {
            List<T> entidades = new List<T>();

            ExecutarReader(ObterComandoSelect(), reader =>
           {
               while (reader.Read())
               {
                   entidades.Add(HidratarEntidade(reader));
               }
           });

            return entidades;
        }

        public T Get(Guid id)
        {
            T entidade = default(T);

            ExecutarReader(ObterComandoSelect(id), reader =>
            {
                while (reader.Read())
                {
                    entidade = HidratarEntidade(reader);
                }
            });

            return entidade;
        }

        public List<T> GetList(Guid id)
        {
            List<T> entidades = new List<T>();

            ExecutarReader(ObterComandoSelect(id), reader =>
            {
                while (reader.Read())
                {
                    entidades.Add(HidratarEntidade(reader));
                }
            });

            return entidades;
        }

        public void Insert(T entidade)
        {
            ExecutarProcesso(ObterComandoInsert(entidade), command =>
            {
                command.ExecuteNonQuery();
            });
        }

        public void Delete(Guid id)
        {
            ExecutarProcesso(ObterComandoDelete(id), command =>
            {
                command.ExecuteNonQuery();
            });
        }

        public void Update(T entidade)
        {
            ExecutarProcesso(ObterComandoUpdate(entidade), command =>
            {
                command.ExecuteNonQuery();
            });
        }

        public void Delete(T entidade)
        {
            ExecutarProcesso(ObterComandoDelete(entidade), command =>
            {
                command.ExecuteNonQuery();
            });
        }

        public void SaveAll()
        {

        }

        private void ExecutarProcesso(string nomeDoComando, Action<SqlCommand> action)
        {
            using (SqlConnection connection = GetConnection())
            using (SqlCommand command = GetCommand(connection, nomeDoComando))
            {
                connection.Open();
                action(command);
                connection.Close();
            }
        }

        private void ExecutarReader(string nomeDoComando, Action<SqlDataReader> action)
        {
            ExecutarProcesso(nomeDoComando, command =>
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    action(reader);
                }
            });

        }

        private static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        private static SqlCommand GetCommand(SqlConnection connection, string command)
        {
            return new SqlCommand(command, connection);
        }

        protected abstract string ObterComandoSelect();

        protected abstract string ObterComandoSelect(Guid id);

        protected abstract string ObterComandoUpdate(T entidade);

        protected abstract string ObterComandoDelete(T entidade);

        protected abstract string ObterComandoDelete(Guid id);

        protected abstract string ObterComandoInsert(T entidade);

        protected abstract T HidratarEntidade(SqlDataReader reader);



    }
}
