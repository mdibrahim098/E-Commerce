namespace BuildingBlocksMessaging.Events
{
    public record BasketCheckoutEvent : IntegrationEvent
    {
        public String UserName { get; init; } = default!;
        public Guid CustomerId { get; init; } = default!;
        public decimal TotalPrice { get; init; } = default!;

        // shipping and billing address

        public String FirstName { get; init; } = default!;
        public String LastName { get; init; } = default!;
        public String EmailAddress { get; init; } = default!;
        public String AddressLine { get; init; } = default!;
        public String Country { get; init; } = default!;
        public String State { get; init; } = default!;
        public String ZipCode { get; init; } = default!;

        // Payment

        public String CardName { get; init; } = default!;
        public String CardNumber { get; init; } = default!;
        public String Expiration { get; init; } = default!;
        public String CVV { get; init; } = default!;
        public String PaymentMethod { get; init; } = default!;



    }

}
