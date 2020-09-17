using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Notes.Dtos
{
    public class NoteReadDto
    {

      
        public int ID { get; set; }
     
        public string Title { get; set; }
      
        public string Details { get; set; }


    }
}
