namespace TelusInternational.DataAccess.Entities
{
    public class MonitorData
    {
        public int Id { get; set; }
        public decimal TalkTime { get; set; }
        public decimal AfterCallWorkTime { get; set; }
        public int Handled { get; set; }
        public int Offered { get; set; }
        public int HandledWithinSL { get; set; }

        public int QueueGroupId { get; set; }
        public QueueGroup QueueGroup { get; set; }

    }
}
