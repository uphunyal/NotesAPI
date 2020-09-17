using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Notes.Dtos
{
    public class NoteCreateDto
    {


        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(1000)]
        [Required]
        public string Details { get; set; }

    }
}
 