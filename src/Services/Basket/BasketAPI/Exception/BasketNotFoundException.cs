namespace BasketAPI.Exception
{
    public  class BasketNotFoundException : NotFoundException
    {
        public BasketNotFoundException(string username) : base("Basket" ,username)
        {   

        }
    }
}
