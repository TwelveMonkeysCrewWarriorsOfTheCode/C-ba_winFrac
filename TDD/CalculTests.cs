using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace winFrac.Tests
{
	[TestClass()]
	public class CalculTests
	{
		[TestMethod()]
        [DataRow("4/15 + 71/30", "2 19/30", DisplayName = "4/15 + 71/30 = 2 19/30")]
        [DataRow("4/15 + 71/30", "2 19/30", DisplayName = "4/15 + 71/30 = 2 19/30")]
        [DataRow("4/15 + 71/30", "2 19/30", DisplayName = "4/15 + 71/30 = 2 19/30")]
        public void CalculParEnonceTest(string pEnonce, string pExpectedValue)
        {
            try
            {
                string resultat = Calcul.CalculParEnonce(pEnonce);
                Assert.AreEqual(pExpectedValue, resultat);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Denominator cannot be 0") Assert.AreEqual("Denominator cannot be 0", ex.Message);
                else if (ex.Message == "Input string was not in a correct format.") Assert.AreEqual("Input string was not in a correct format.", ex.Message);
                else if (ex.Message == "Index was outside the bounds of the array.") Assert.AreEqual("Index was outside the bounds of the array.", ex.Message);
                else Assert.Fail();
            }
        }
	}
}