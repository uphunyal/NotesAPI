using Notes.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Notes.Data
{
    public class SqlNoteRepo : INotesRepo
    {
        private readonly NotesContext _context;

        public SqlNoteRepo(NotesContext context)
        {
            _context = context;

        }

        public void CreateNote(Note note)
        {
            if(note == null)
            {
                throw new ArgumentNullException(nameof(note));
            }

            _context.Add(note);
        }

        public void DeleteNote(Note note)
        {
            if (note == null)
            {
                throw new ArgumentNullException(nameof(note));
            }
            _context.Notes.Remove(note);
        }

        public IEnumerable<Note> GetAllNotes()
        {
            return _context.Notes.ToList();
        }

        public Note GetNoteByID(int id)
        {
            return _context.Notes.FirstOrDefault(c => c.ID == id);
        }

        public bool SaveChanges()
        {
           return (_context.SaveChanges() >=0);
        }

        public void UpdateNote(Note cmd)
        {
            //Not implemented
        }
    }
}
