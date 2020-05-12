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
        TEntity Get(int userId, int id);
        TEntity Insert(TEntity entity);
        bool Update(int id, TEntity entity);
        bool Delete(int userId, int id);
    }
}
