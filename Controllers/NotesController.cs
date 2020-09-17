using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Notes.Data;
using Notes.Dtos;
using Notes.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Notes.Controllers
{
    //api//notes
    [Route("api/notes")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotesRepo _repository;
        private readonly IMapper _mapper;

        public NotesController (INotesRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //Get api/notes
        [HttpGet]
        public ActionResult<IEnumerable<NoteReadDto>> GetAllNotes()
        {
            var notes = _repository.GetAllNotes();
            return Ok(_mapper.Map<IEnumerable<NoteReadDto>>(notes)); 
        }

        //Get api/notes/{id}
        [HttpGet("{id}", Name = "GetNoteById")]
        public ActionResult<NoteReadDto> GetNoteById(int id)
        {
            var note = _repository.GetNoteByID(id);
            if (note != null)
            {
                return Ok(_mapper.Map<NoteReadDto>(note));

            }
            return NotFound();
            

        }

        //POST api/notes
        [HttpPost]
        public ActionResult<NoteReadDto> CreateNote(NoteCreateDto noteCreateDto)
        {
            var noteModel = _mapper.Map<Note>(noteCreateDto);
            _repository.CreateNote(noteModel);
            _repository.SaveChanges();

            var noteReadDto = _mapper.Map<NoteReadDto>(noteModel);

            return CreatedAtRoute(nameof(GetNoteById), new { Id = noteReadDto.ID }, noteReadDto);

            

        }

        //PUT api/notes/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateNote(int id, NoteUpdateDto noteUpdateDto)
        {
            var noteModelFromRepo = _repository.GetNoteByID(id);
            if (noteModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(noteUpdateDto, noteModelFromRepo);
            _repository.UpdateNote(noteModelFromRepo);
            _repository.SaveChanges();
            return NoContent();

        }

        //PATCH api/notes/{id}
        [HttpPatch("{id}")]

        public ActionResult PartialNoteUpdate(int id, JsonPatchDocument<NoteUpdateDto> patchDocument)
        {
            var noteModelFromRepo = _repository.GetNoteByID(id);
            if (noteModelFromRepo == null)
            {
                return NotFound();

            }

            var noteToPatch = _mapper.Map<NoteUpdateDto>(noteModelFromRepo);
            patchDocument.ApplyTo(noteToPatch, ModelState);
            if (!TryValidateModel(noteToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(noteToPatch, noteModelFromRepo);
            _repository.UpdateNote(noteModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        //DELETE api/notes/{id}
        [HttpDelete("{id}")]
        public ActionResult  DeleteNote(int id)
        {
            var noteFromModelRepo = _repository.GetNoteByID(id);
            if(noteFromModelRepo== null)
            {
                return NotFound();
            }
            _repository.DeleteNote(noteFromModelRepo);
            _repository.SaveChanges();
            return NoContent();
        }
        
    }
}
