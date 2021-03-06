﻿using System;

namespace Dynamic.Ampla.WebServices.Simple.Records.Filters
{
    public class LocationWithRecurseFilterMatcher : FilterMatcher
    {
        private readonly string location;

        public LocationWithRecurseFilterMatcher(string location)
        {
            this.location = location.EndsWith(" with recurse", StringComparison.InvariantCultureIgnoreCase)
                ? location.Replace(" with recurse", "")
                : location;
        }

        public override bool Matches(InMemoryRecord record)
        {
            return record.Location.StartsWith(location);
        }

        public override bool Matches(InMemoryAuditRecord auditRecord)
        {
            return auditRecord.Location.StartsWith(location);
        }
    }
}