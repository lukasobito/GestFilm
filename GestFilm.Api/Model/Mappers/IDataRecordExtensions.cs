using GestFilm.Models.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace GestFilm.Api.Model.Mappers
{
    internal static class IDataRecordExtensions
    {
        internal static User ToUser(this IDataRecord dataRecord)
        {
            return new User()
            {
                Id = (int)dataRecord["Id"],
                LastName = (string)dataRecord["LastName"],
                FirstName = (string)dataRecord["FirstName"],
                Login = (string)dataRecord["Login"]
            };
        }

        internal static Group ToGroup(this IDataRecord dataRecord)
        {
            return new Group()
            {
                Id = (int)dataRecord["Id"],
                Name = (string)dataRecord["Name"]
            };
        }

        internal static Event ToEvent(this IDataRecord dataRecord)
        {
            return new Event()
            {
                Id = (int)dataRecord["Id"],
                Name = (string)dataRecord["Name"],
                Film = (string)dataRecord["Film"],
                DateEvent = (DateTime)dataRecord["Date"],
                IsDateValid = (bool)dataRecord["IsDateValid"],
                IsFilmValid = (bool)dataRecord["IsFilmValid"],
                GroupId = (int)dataRecord["GroupId"]
            };
        }
    }
}
