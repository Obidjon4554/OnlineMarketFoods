namespace OnlineMarketFoods.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public virtual CustomerDto Customer { get; set; }
        public virtual ProductDto Product { get; set; }
    }
}
