using GestFilm.Models.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ApiGestFilm.Models.Mappers
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
    }
}