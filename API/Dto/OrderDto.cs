namespace API.Dto
{
    public class OrderDto
    {
        public int BasketId { get; set; }
        public int DeliveryMethodId { get; set; }
        public AddressDto ShipToAddress { get; set; }
    }
}