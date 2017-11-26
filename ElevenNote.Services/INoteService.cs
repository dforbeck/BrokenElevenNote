using System.Collections.Generic;
using ElevenNote.Models;

namespace ElevenNote.Services
{
    public interface INoteService
    {
        bool CreateNote(NoteCreate model);
        IEnumerable<NoteListItem> GetNotes();
        NoteDetail GetNoteById(int noteId);
        bool UpdateNote(NoteEdit model);
        bool DeleteNote (int noteId);
    }
}