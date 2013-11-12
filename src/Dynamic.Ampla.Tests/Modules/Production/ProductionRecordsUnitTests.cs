using System;
using System.Collections.Generic;
using System.Linq;
using Dynamic.Ampla.WebServices.Simple.Records;
using NUnit.Framework;

namespace Dynamic.Ampla.Modules.Production
{
    [TestFixture]
    public class ProductionRecordsUnitTests : TestFixture
    {
        private const string location = "Enterprise.Site.Area.Production";

        [Test]
        public void NewRecord()
        {
            InMemoryRecord record = ProductionRecords.NewRecord();

            Assert.That(record.Location, Is.EqualTo(location));
            List<FieldValue> locationFields = record.Fields.Where(field => field.Name == "Location").ToList();
            Assert.That(locationFields.Count, Is.EqualTo(1));
        }

        [Test]
        public void CloneRecord()
        {
            InMemoryRecord record = ProductionRecords.NewRecord();
            InMemoryRecord clone = record.Clone();

            Assert.That(clone.Location, Is.EqualTo(location));
            List<FieldValue> locationFields = clone.Fields.Where(field => field.Name == "Location").ToList();
            Assert.That(locationFields.Count, Is.EqualTo(1));
        }

    }
}