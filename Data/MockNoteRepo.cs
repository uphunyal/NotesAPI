using Notes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notes.Data
{
    public class MockNoteRepo : INotesRepo
    {
        public void CreateNote(Note note)
        {
            throw new NotImplementedException();
        }

        public void DeleteNote(Note note)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Note> GetAllNotes()
        {
            var Notes = new List<Note>
            {
                new Note { ID = 0, Title = "Example 1", Details = "This is example 1." },
                new Note { ID = 1, Title = "Example 2", Details = "This is example 2." },
                new Note { ID = 2, Title = "Example 3", Details = "This is example 3." },
                new Note { ID = 3, Title = "Example 4", Details = "This is example 4." },

        };
            return Notes;
        }

        public Note GetNoteByID(int id)
        {
            return new Note { ID = 0, Title = "Boil an Egg", Details = "Boil Watter"};
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateNote(Note note)
        {
            throw new NotImplementedException();
        }
    }
}
