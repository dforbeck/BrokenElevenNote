using System;
using System.Collections.Generic;
using ElevenNote.Models;
using ElevenNote.Services;

namespace ElevenNote.Web.Tests.Controllers
{
    public class FakeNoteService : INoteService
    {
        public int CreateNoteCallCount { get; private set; }
        public bool CreateNoteReturnValue { get; set; } = true;

        public bool CreateNote(NoteCreate model)
        {
            CreateNoteCallCount++;

            return CreateNoteReturnValue;
        }

        public IEnumerable<NoteListItem> GetNotes()
        {
            throw new NotImplementedException();
        }

        public NoteDetail GetNoteById(int noteId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteNote(int noteId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateNote(NoteEdit model)
        {
            throw new NotImplementedException();
        }
    }
}