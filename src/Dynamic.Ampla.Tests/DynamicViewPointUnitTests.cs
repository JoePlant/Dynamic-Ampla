using Dynamic.Ampla.AmplaData2008;
using Dynamic.Ampla.Tests;
using Dynamic.Ampla.WebServices.Simple.AmplaData2008;
using Microsoft.CSharp.RuntimeBinder;
using NUnit.Framework;

namespace Dynamic.Ampla
{
    [TestFixture]
    public class DynamicViewPointUnitTests : TestFixture
    {
        private const string location = "Enterprise.Site.Area.Production";
        private const string module = "Production";

        protected override void OnFixtureSetUp()
        {
            base.OnFixtureSetUp();
            DataWebServiceFactory.Factory = () => new SimpleDataWebServiceClient(module, location);
        }

        protected override void OnFixtureTearDown()
        {
            DataWebServiceFactory.Factory = null;
            base.OnFixtureTearDown();
        }

        [Test]
        public void FindNamedArgument()
        {
            DynamicViewPoint viewPoint = new DynamicViewPoint(location, module);

            dynamic point = viewPoint;
            dynamic result = point.Find(Id: 100);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(100));
        }

        [Test]
        public void FindById()
        {
            DynamicViewPoint viewPoint = new DynamicViewPoint(location, module);

            dynamic point = viewPoint;
            dynamic result = point.FindById(100);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(100));
        }

        [Test]
        public void Find()
        {
            DynamicViewPoint viewPoint = new DynamicViewPoint(location, module);

            dynamic point = viewPoint;
            dynamic result = point.Find(100);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(100));
        }

        [Test]
        public void FindWithSetId()
        {
            DynamicViewPoint viewPoint = new DynamicViewPoint(location, module);

            dynamic point = viewPoint;

            Assert.Throws<RuntimeBinderException>(()=>point.Find(SetId: 100));
        }

        [Test]
        public void FindByWithNamedAndPositional()
        {
            DynamicViewPoint viewPoint = new DynamicViewPoint(location, module);

            dynamic point = viewPoint;

            Assert.Throws<RuntimeBinderException>(() => point.Find(100, Id: 200));
        }

    }
}