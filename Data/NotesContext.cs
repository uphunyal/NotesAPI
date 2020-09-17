using Notes.Models;
using Microsoft.EntityFrameworkCore;


namespace Notes.Data
{
    public class NotesContext: DbContext
    {

        public NotesContext(DbContextOptions<NotesContext> opt): base(opt)
        {

        }
        public DbSet<Note> Notes { get; set; }
    }
}
