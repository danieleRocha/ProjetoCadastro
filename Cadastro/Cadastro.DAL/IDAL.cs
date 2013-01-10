using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cadastro.DAL
{
    public interface IDAL<T>
    {
        List<T> GetAll();

        T Get(Guid id);

        List<T> GetList(Guid id);

        void Insert(T entity);
        void Delete(T entity);
        void Delete(Guid id);
        void Update(T entity);
        void SaveAll();
    }
}