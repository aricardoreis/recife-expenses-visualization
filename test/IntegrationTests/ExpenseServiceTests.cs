using Core.Services;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Linq;

namespace IntegrationTests
{
    public class ExpenseServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetGroupedByMonth()
        {
            ExpenseService service = new ExpenseService();
            var result = await service.GetGroupedByMonth();

            // 12 months a year
            Assert.IsNotNull(result);
            Assert.That(result.Count() == 12);
            Assert.That(!string.IsNullOrEmpty(result.FirstOrDefault().Name));
            Assert.That(result.FirstOrDefault().Value > 0M);
        }
    }
}