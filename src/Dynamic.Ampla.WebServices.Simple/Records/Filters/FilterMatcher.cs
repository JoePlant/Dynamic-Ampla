namespace Dynamic.Ampla.WebServices.Simple.Records.Filters
{
    public abstract class FilterMatcher
    {
        public abstract bool Matches(InMemoryRecord record);

        public abstract bool Matches(InMemoryAuditRecord auditRecord);
    }
}