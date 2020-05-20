using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestFilm.Interfaces
{
    public interface IGroupRepository<TEntity>
    {
        IEnumerable<TEntity> Get(int userId);
        TEntity GetOne(int id);
        TEntity Insert(TEntity entity, int userId);
        bool Update(int id, TEntity entity);
        bool Delete(int id);
    }
}
