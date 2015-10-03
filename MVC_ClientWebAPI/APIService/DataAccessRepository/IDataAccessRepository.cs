using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIService.DataAccessRepository
{
    /// <summary>
    /// DataAccessRepository interface
    /// </summary>
    /// <typeparam name="TEntity">This is the class type, represents the entity class used during Read/Write operations.</typeparam>
    /// <typeparam name="TPrimaryKey">This is an input parameter used during Reading of specific record and deleting it.</typeparam>
    public interface IDataAccessRepository<TEntity, in TPrimaryKey> where TEntity : class
    {
        IEnumerable<TEntity> Get();
        TEntity Get(TPrimaryKey id);
        void Post(TEntity entity);
        void Put(TPrimaryKey id, TEntity entity);
        void Delete(TPrimaryKey id);
    }
}
