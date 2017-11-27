using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElevenNote.Web.Tests
{
    public static class MyAssert
    {
        public static void ObjectFailsValidation(object o)
        {
            var results = new List<ValidationResult>();

            Validator.TryValidateObject(o, new ValidationContext(o), results, true /* validate all properties */);
            Assert.AreNotEqual(0, results.Count);
        }
    }
}
