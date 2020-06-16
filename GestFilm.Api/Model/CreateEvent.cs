using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestFilm.Api.Model
{
    public class CreateEvent
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Film { get; set; }
        [Required]
        public DateTime DateEvent { get; set; }
        [Required]
        public int GroupId { get; set; }
    }
}
