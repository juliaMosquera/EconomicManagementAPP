using EconomicManagementAPP.Validations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;


namespace EconomicManagementAPP.Test
{
    [TestClass]
    public class NumberValidateTest
    {
        [TestMethod]
        public void NumberValidateLower_ReturnError()
        {
            var numberValidate = new NumberValidate();
            decimal data = -1;

            var context = new ValidationContext(new { Name = data });

            var testResult = numberValidate.GetValidationResult(data, context);
            Assert.AreEqual("The field is positive.", testResult?.ErrorMessage);
        }

        [TestMethod]
        public void NumberValidationLower_ReturnError()
        {
            var numberValidate = new NumberValidate();
            string data = "a";

            var context = new ValidationContext(new { Name = data });

            var testResult = numberValidate.GetValidationResult(data, context);
            Assert.AreEqual("The field is numeric type.", testResult?.ErrorMessage);
        }
    }
}
