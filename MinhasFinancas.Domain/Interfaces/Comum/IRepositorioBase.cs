using System;
using System.Collections.Generic;
using System.Text;

namespace MinhasFinancas.Domain.Interfaces.Comum
{
    public interface IRepositorioBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int? id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
    }
}
