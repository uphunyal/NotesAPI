using AutoMapper;
using Notes.Dtos;
using Notes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notes.Profiles
{

    //This maps the DTO to the Model
    public class NotesProfile : Profile
    {

        public NotesProfile()
        {
            //Source -> Target
            CreateMap<Note, NoteReadDto>();
            CreateMap<NoteCreateDto, Note>();
            CreateMap<NoteUpdateDto, Note>();
            CreateMap<Note, NoteUpdateDto>();
        }

    }
}
