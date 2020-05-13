using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiGestFilm.Models
{
    public class CreateGroup
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}