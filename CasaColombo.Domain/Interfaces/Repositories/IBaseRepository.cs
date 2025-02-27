using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity, TKey> where TEntity : class
    {

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        List<TEntity> GetAll();
        TEntity GetById(TKey id);


        void Adds(TEntity entity);
        void Updates(TEntity entity);
        void Deletes(TEntity entity);
        List<TEntity> GetAlls();
        TEntity GetByIds(TKey id);

    }
}
