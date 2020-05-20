using GestFilm.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestFilm.Forms
{
    public class InfoGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Event> events { get; set; }
    }
}
