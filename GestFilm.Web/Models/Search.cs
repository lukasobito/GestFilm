using GestFilm.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestFilm.Web.Models
{
    public class Search
    {
        public string value { get; set; }
        public IEnumerable<User> users { get; set; }
    }
}
