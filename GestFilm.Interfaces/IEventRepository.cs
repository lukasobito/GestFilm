using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestFilm.Interfaces
{
    public interface IEventRepository<TEntity>
    {
        IEnumerable<TEntity> GetByUserId(int userId);
        IEnumerable<TEntity> GetByGroupId(int groupId);
        TEntity GetOne(int id);
        TEntity Insert(TEntity entity);
        bool Update(int id, TEntity entity);
        bool Delete(int id);
    }
}
