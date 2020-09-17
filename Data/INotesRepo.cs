using Notes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notes.Data
{
    public interface INotesRepo
    {
        bool SaveChanges();
        IEnumerable<Note> GetAllNotes();

        Note GetNoteByID(int id);

        void CreateNote(Note note);
        void UpdateNote(Note note);
        void DeleteNote(Note note);
    }
}
