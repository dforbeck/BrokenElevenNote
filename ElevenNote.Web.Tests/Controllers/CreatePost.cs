using System.Linq;
using System.Web.Mvc;
using ElevenNote.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ElevenNote.Web.Tests.Controllers
{
    [TestClass]
    public class CreatePost : NoteControllerTestsBase
    {
        private NoteCreate _model;

        [TestInitialize]
        public override void Arrange()
        {
            base.Arrange();

            FakeNoteService.CreateNoteReturnValue = true;

            _model = new NoteCreate();
        }

        private ActionResult Act()
        {
            return Controller.Create(_model);
        }

        /// <summary>
        /// Given happy path, we call CreateNote
        /// </summary>
        [TestMethod]
        public void ShouldCallCreateNote_GivenHappyPath()
        {
            Act();

            Assert.AreEqual(1, FakeNoteService.CreateNoteCallCount);
        }

        /// <summary>
        /// Given happy path, we set SaveResult
        /// </summary>
        [TestMethod]
        public void ShouldSetSaveResult_GivenHappyPath()
        {
            Act();

            var saveResult = Controller.TempData["SaveResult"];
            Assert.AreEqual("Your note was created.", saveResult);
        }

        /// <summary>
        /// Given happy path, we redirect to Index
        /// </summary>
        [TestMethod]
        public void ShouldRedirectToIndex_GivenHappyPath()
        {
            var result = Act();

            AssertRedirectsTo(result, "Index");
        }

        private static void AssertRedirectsTo(ActionResult result, string action)
        {
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
            Assert.AreEqual(((RedirectToRouteResult)result).RouteValues["action"], action);
        }

        /// <summary>
        /// Given invalid model state, we return the same page
        /// </summary>
        [TestMethod]
        public void ShouldReturnSameView_GivenInvalidModelState()
        {
            Controller.ModelState.AddModelError("", "test error");

            var result = Act();

            AssertViewResultAndModel(result, _model);
        }

        private static void AssertViewResultAndModel(ActionResult result, object model)
        {
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.AreEqual(((ViewResult) result).Model, model);
        }

        /// <summary>
        /// Given CreateNote fails, we display an error
        /// </summary>
        [TestMethod]
        public void ShouldDisplayError_GivenCreateNoteFails()
        {
            FakeNoteService.CreateNoteReturnValue = false;

            Act();
            
            AssertModelStateHasError("Note could not be created");
        }

        private void AssertModelStateHasError(string expectedError)
        {
            var hasError = Controller
                .ModelState
                .Values
                .SelectMany(x => x.Errors)
                .Any(e => e.ErrorMessage == expectedError);
            Assert.IsTrue(hasError);
        }

        /// <summary>
        /// Given CreateNote fails, we return the same page
        /// </summary>
        [TestMethod]
        public void ShouldReturnSamePage_GivenCreateNoteFails()
        {
            FakeNoteService.CreateNoteReturnValue = false;

            var result = Act();

            AssertViewResultAndModel(result, _model);
        }
    }
}