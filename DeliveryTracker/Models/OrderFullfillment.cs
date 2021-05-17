namespace DeliveryTracker.Models
{
    public class OrderFullfillment
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int DeliveredBy { get; set; }
        public int DeliveredTo { get; set; }
        public DeliveryStatus Status { get; set; }
        public string Description { get; set; }
        public OrderFullfillment()
        {

        }
    }


    public enum DeliveryStatus
    {
        OrderCompleted,
        Shipped,
        InTransit,
        Delivered,
        Returned
    }
}
