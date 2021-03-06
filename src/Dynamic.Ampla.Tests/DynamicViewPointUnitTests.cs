﻿using Dynamic.Ampla.AmplaData2008;
using Dynamic.Ampla.Modules.Production;
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

        private int id;

        protected override void OnSetUp()
        {
            base.OnSetUp();
            SimpleDataWebServiceClient client = new SimpleDataWebServiceClient(module, location)
                {
                    GetViewFunc = ProductionViews.StandardView
                };

            id = client.AddExistingRecord(ProductionRecords.NewRecord());
            DataWebServiceFactory.Factory = () => client;
        }

        protected override void OnTearDown()
        {
            base.OnTearDown();
            DataWebServiceFactory.Factory = null;
        }

        [Test]
        public void FindNamedArgument()
        {
            DynamicViewPoint viewPoint = new DynamicViewPoint(location, module);

            dynamic point = viewPoint;
            dynamic result = point.Find(Id: id);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(id));
            Assert.That(result.Location, Is.EqualTo(location));
        }

        [Test]
        public void FindById()
        {
            DynamicViewPoint viewPoint = new DynamicViewPoint(location, module);

            dynamic point = viewPoint;
            dynamic result = point.FindById(id);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(id));
            Assert.That(result.Location, Is.EqualTo(location));
        }

        [Test]
        public void Find()
        {
            DynamicViewPoint viewPoint = new DynamicViewPoint(location, module);

            dynamic point = viewPoint;
            dynamic result = point.Find(id);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(id));
            Assert.That(result.Location, Is.EqualTo(location));
        }

        [Test]
        public void FindWithSetId()
        {
            DynamicViewPoint viewPoint = new DynamicViewPoint(location, module);

            dynamic point = viewPoint;

            Assert.Throws<RuntimeBinderException>(()=>point.Find(SetId: id));
        }

        [Test]
        public void FindByWithNamedAndPositional()
        {
            DynamicViewPoint viewPoint = new DynamicViewPoint(location, module);

            dynamic point = viewPoint;

            Assert.Throws<RuntimeBinderException>(() => point.Find(id, Id: 200));
        }
    }
}