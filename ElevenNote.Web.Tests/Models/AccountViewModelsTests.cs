using ElevenNote.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ElevenNote.Web.Tests.Models
{
    [TestClass]
    public class AccountViewModelsTests
    {
        [TestMethod]
        public void UsernameRequiredByModelToRegister()
        {
            var model = new RegisterViewModel
            {
                Email = null,
                ConfirmPassword = "LetMeIn1234!",
                Password = "LetMeIn1234!"
            };

            MyAssert.ObjectFailsValidation(model);
        }
    }
}