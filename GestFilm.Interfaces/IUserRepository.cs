using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestFilm.Interfaces
{
    public interface IUserRepository<TEntity>
    {
        IEnumerable<TEntity> Get(string search, int idGroup);
        IEnumerable<TEntity> Get(int idGroup);
        bool Insert(int idGroup, int idUser);
        bool Delete(int idGroup, int idUser);

    }
}
