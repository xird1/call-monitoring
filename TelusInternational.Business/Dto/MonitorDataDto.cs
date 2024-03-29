namespace TelusInternational.Business.Dto
{
    public class MonitorDataDto
    {
        public int Id { get; set; }
        public decimal TalkTime { get; set; }
        public decimal AfterCallWorkTime { get; set; }
        public int Handled { get; set; }
        public int Offered { get; set; }
        public int HandledWithinSL { get; set; }

        public int QueueGroupId { get; set; }
    }
}
