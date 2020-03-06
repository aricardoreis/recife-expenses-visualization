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
            using var service = new ExpenseService();
            var result = await service.GetGroupedByMonth();

            Assert.IsNotNull(result);

            // 12 months a year
            Assert.That(result.Count() == 12);
            Assert.IsNotNull(result.FirstOrDefault());
            Assert.That(!string.IsNullOrEmpty(result.FirstOrDefault().Name));
            Assert.That(result.FirstOrDefault().Value > 0M);
        }

        [Test]
        public async Task GetGroupedByCategory()
        {
            using var service = new ExpenseService();
            var result = await service.GetGroupedByCategory();

            // TODO: Add additional checks
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task GetGroupedBySource()
        {
            using var service = new ExpenseService();
            var result = await service.GetGroupedBySource();

            // TODO: Add additional checks
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task GetAll()
        {
            using var service = new ExpenseService();
            var result = await service.GetAll();

            // TODO: Add additional checks
            Assert.IsNotNull(result);
        }
    }
}