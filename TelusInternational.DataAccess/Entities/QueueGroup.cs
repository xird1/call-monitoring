namespace TelusInternational.DataAccess.Entities
{
    public class QueueGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal SLA_Percent { get; set; }
        public decimal SLA_Time { get; set; }
        public MonitorData MonitorData { get; set; }
    }
}
