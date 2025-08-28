namespace DiscountGrpc.Services
{
    public class DiscountService (DiscountContext dbContext, ILogger<DiscountService> logger)
        : DiscountProtoService.DiscountProtoServiceBase
    {
       public override async Task<CouponModel> GetDiscount(GetDiscountRequest request,
                                          ServerCallContext context)
        {    
           var coupon = await  dbContext.Coupons
                .FirstOrDefaultAsync(x => x.ProductName == request.ProductName);

            if(coupon is null)
            {
                coupon = new Coupon { ProductName = "No Discount", Amount = 0, Description = "No Discount Desc" };
            }

            logger.LogInformation("Discount is retrieved for ProductName : {ProductName}, Amount : {Amount}", coupon.ProductName, coupon.Amount);
           
            var couponModel = coupon.Adapt<CouponModel>();
            return couponModel;


        }

        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request,
                                           ServerCallContext context)
        {
            var coupon = request.Coupon.Adapt<Coupon>();
            if(coupon is null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Coupon is null"));
            }

            var Check = await dbContext.Coupons .FirstOrDefaultAsync(x => x.ProductName == coupon.ProductName);
            if (Check is not null)
            {
                logger.LogInformation(" This ProductName is Already has coupon. ProductName : {ProductName}", coupon.ProductName);
                coupon = new Coupon { ProductName = "Already Exist", Amount = Check.Amount, Description = "Discount already added" };
            }
            else
            {
                dbContext.Coupons.Add(coupon);
                await dbContext.SaveChangesAsync();
                logger.LogInformation("Discount is successfully created. ProductName : {ProductName}", coupon.ProductName);
            }
                          
             var couponModel = coupon.Adapt<CouponModel>();
             return couponModel;
        }

        public override Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request,
                                           ServerCallContext context)
        {
            return base.UpdateDiscount(request, context);
        }

        public override Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request,
                                                     ServerCallContext context)
        {
            return base.DeleteDiscount(request, context);
        }


    }
}
