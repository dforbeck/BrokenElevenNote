using System.Linq;
using System.Web.Mvc;
using ElevenNote.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ElevenNote.Web.Tests.Controllers.NoteControllerTests
{
    [TestClass]
    public class CreatePost : NoteControllerTestsBase
    {
        private NoteCreate _model;

        [TestInitialize]
        public override void Arrange()
        {
            base.Arrange();

            NoteService.CreateNoteReturnValue = true;
            _model = new NoteCreate();
        }

        private ActionResult Act()
        {
            return Controller.Create(_model);
        }

        [TestMethod]
        public void ShouldReturnRedirectToRouteResult()
        {
            var result = Act();

            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }

        [TestMethod]
        public void ShouldCallCreateNote()
        {
            Act();

            Assert.AreEqual(1, NoteService.CreateNoteCallCount);
        }

        [TestMethod]
        public void ShouldSetSaveResult()
        {
            Act();

            Assert.AreEqual("Your note was created.", Controller.TempData["SaveResult"]);
        }

        [TestMethod]
        public void ShouldRedirectToIndex()
        {
            var result = (RedirectToRouteResult)Act();

            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void ShouldReturnViewResultWithOriginalModel_GivenInvalidModelState()
        {
            Controller.ModelState.AddModelError("", "test error");

            var result = Act();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.AreEqual(_model, ((ViewResult)result).Model);
        }

        [TestMethod]
        public void ShouldSetErrorMessage_GivenCreateNoteFails()
        {
            NoteService.CreateNoteReturnValue = false;

            Act();

            Assert.IsTrue(Controller.ModelState.Values.Any(v => v.Errors.Any(e => e.ErrorMessage == "Note could not be created")));
        }

        [TestMethod]
        public void ShouldReturnViewResultWithOriginalModel_GivenCreateNoteFails()
        {
            NoteService.CreateNoteReturnValue = false;

            var result = Act();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.AreEqual(_model, ((ViewResult)result).Model);
        }
    }
}
