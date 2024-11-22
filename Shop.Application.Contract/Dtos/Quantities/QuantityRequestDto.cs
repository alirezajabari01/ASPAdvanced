namespace Shop.Application.Contract.Dtos.Quantities
{
    public record QuantityRequestDto
    {
        public int UserId { get; set; }
        public string Product { get; set; } = null!;

        public string Venture { get; set; } = null!;
    }
}
