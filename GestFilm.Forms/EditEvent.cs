using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestFilm.Forms
{
    public class EditEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Film { get; set; }
        public DateTime DateEvent { get; set; }
        public bool IsFilmValid { get; set; }
        public bool IsDateValid { get; set; }
        public int GroupId { get; set; }
    }
}
