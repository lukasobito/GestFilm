using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestFilm.Api.Model
{
    public class CreateGroup
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
