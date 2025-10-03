namespace OrderingDomain.ValueObjects
{
    public record Payment
    {
        public string? CardName { get; } = default!;
        public string CarNumber { get; } = default!;
        public string Expiration { get; } = default!;
        public string CVV { get; } = default!;
        public int PaymentMethod { get; } = default!;

    }
}
