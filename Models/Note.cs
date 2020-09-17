using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Notes.Models
{
    public class Note
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(1000)]
        [Required]
        public string Details { get; set; }

    }
}
