using Babylon.Blazor.Chemical;

using Microsoft.AspNetCore.Html;

using NUnit.Framework;

namespace Babylon.Blazor.Test
{
    public class UtilsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConvertToFormulaTest1()
        {
            HtmlString result = Utils.ConvertToFormula("H2O");
            Assert.AreEqual("H<sub>2</sub>O",result.Value);
        }
    }
}