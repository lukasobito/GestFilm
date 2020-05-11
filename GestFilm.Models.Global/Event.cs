using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestFilm.Models.Global
{
    public class Event
    {
        public int Id { get; set; }
        public string Film { get; set; }
        public DateTime DateEvent { get; set; }
        public Boolean IsFilmValid { get; set; }
        public Boolean IsDateValid { get; set; }
    }
}
