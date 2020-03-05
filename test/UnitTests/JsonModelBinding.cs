using Core.Response;
using Newtonsoft.Json;
using NUnit.Framework;
using System.IO;
using System.Linq;

namespace UnitTests
{
    public class JsonModelBinding
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckResponseMessageDeserialization()
        {
            string responseMessageAsText = File.ReadAllText(TestContext.CurrentContext.TestDirectory + "\\TestData\\result.json");
            Assert.IsNotEmpty(responseMessageAsText);

            var responseMessageAsObject = JsonConvert.DeserializeObject<ExpenseSearchResponseData>(responseMessageAsText);
            
            Assert.IsNotNull(responseMessageAsObject);
            Assert.IsNotNull(responseMessageAsObject.Result);
            Assert.Greater(responseMessageAsObject.Result.Records.Count, 0);
            Assert.IsNotNull(responseMessageAsObject.Result.Records.FirstOrDefault());
            Assert.AreNotEqual(responseMessageAsObject.Result.Records.FirstOrDefault().Value, 0M);
            Assert.AreNotEqual(responseMessageAsObject.Result.Records.FirstOrDefault().Name, string.Empty);
        }
    }
}