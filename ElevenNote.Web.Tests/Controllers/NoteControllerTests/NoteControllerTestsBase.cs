using System;
using ElevenNote.Services;
using ElevenNote.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ElevenNote.Web.Tests.Controllers.NoteControllerTests
{
    [TestClass]
    public abstract class NoteControllerTestsBase
    {
        protected NoteController Controller;

        protected FakeNoteService FakeNoteService;

        [TestInitialize]
        public virtual void Arrange()
        {
            FakeNoteService = new FakeNoteService();

            Controller = new NoteController(
                new Lazy<INoteService>(() => FakeNoteService));
        }
    }
}
