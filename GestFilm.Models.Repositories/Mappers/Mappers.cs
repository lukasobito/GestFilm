using GestFilm.Models.Data;
using G = GestFilm.Models.Global;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestFilm.Models.Repositories.Mappers
{
    internal static class Mappers
    {
        internal static Group ToClient(this G.Group entity)
        {
            return new Group(entity.Id, entity.Name);
        }
    }
}
