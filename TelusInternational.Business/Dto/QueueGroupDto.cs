namespace TelusInternational.Business.Dto
{
    public class QueueGroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal SLA_Percent { get; set; }
        public decimal SLA_Time { get; set; }
        public MonitorDataDto MonitorData { get; set; }
    }
}
