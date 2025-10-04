namespace OrderingDomain.ValueObjects
{
    public record Payment
    {
        public string? CardName { get; } = default!;
        public string CardNumber { get; } = default!;
        public string Expiration { get; } = default!;
        public string CVV { get; } = default!;
        public int PaymentMethod { get; } = default!;

        protected Payment() { }

        private Payment(string cardName, string carNumber, string expiration, string cvv, int paymentMethod)
        {
            CardName = cardName;
            CardNumber = carNumber;
            Expiration = expiration;
            CVV = cvv;
            PaymentMethod = paymentMethod;
        }

        public static Payment Of(string cardName, string carNumber, string expiration, string cvv, int paymentMethod)
        {
           
            ArgumentException.ThrowIfNullOrEmpty(cardName);
            ArgumentException.ThrowIfNullOrEmpty(carNumber);
            ArgumentException.ThrowIfNullOrEmpty(cvv);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(cvv.Length,3);

            return new Payment(cardName, carNumber, expiration, cvv, paymentMethod);
        }

    }
}
