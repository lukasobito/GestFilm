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

        internal static Event ToClient(this G.Event entity)
        {
            return new Event(entity.Id, entity.Name, entity.Film, entity.DateEvent, entity.GroupId, entity.IsDateValid, entity.IsFilmValid);
        }

        internal static User ToClient(this G.User entity)
        {
            return new User(entity.Id, entity.LastName, entity.FirstName, entity.Login);
        }
    }
}
