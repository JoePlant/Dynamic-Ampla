using System;
using Dynamic.Ampla.Binders;
using Dynamic.Ampla.Strategies;
using NUnit.Framework;

namespace Dynamic.Ampla.Tests.Strategies
{
    [TestFixture]
    public class FindByIdStrategyUnitTests : TestFixture
    {
        [Test]
        public void GetBinder()
        {
            FindByIdStrategy strategy = new FindByIdStrategy();
            var memberBinder = Binder.GetMemberBinder("Find", 1, "Id");
            IDynamicBinder dynamicBinder = strategy.GetBinder(memberBinder, new object[] {100});

            Assert.That(dynamicBinder, Is.Not.Null);
        }

        [Test]
        public void GetBinderWithOutId()
        {
            FindByIdStrategy strategy = new FindByIdStrategy();
            var memberBinder = Binder.GetMemberBinder("Find", 0);
            IDynamicBinder dynamicBinder = strategy.GetBinder(memberBinder, new object[] {});

            Assert.That(dynamicBinder, Is.Null);
        }

        [Test]
        public void GetBinderWithFindById()
        {
            FindByIdStrategy strategy = new FindByIdStrategy();
            var memberBinder = Binder.GetMemberBinder("FindById", 1);
            IDynamicBinder dynamicBinder = strategy.GetBinder(memberBinder, new object[] { 100 });

            Assert.That(dynamicBinder, Is.Not.Null);
        }

        [Test]
        public void GetBinderForWrongMethod()
        {
            FindByIdStrategy strategy = new FindByIdStrategy();
            var memberBinder = Binder.GetMemberBinder("Delete", 1, "Id");
            IDynamicBinder dynamicBinder = strategy.GetBinder(memberBinder, new object[] { 100 });

            Assert.That(dynamicBinder, Is.Null);
        }
    }
}