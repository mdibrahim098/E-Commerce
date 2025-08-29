namespace DiscountGrpc.Services
{
    public class DiscountService(DiscountContext dbContext, ILogger<DiscountService> logger)
        : DiscountProtoService.DiscountProtoServiceBase
    {



        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request,
                                           ServerCallContext context)
        {
            var coupon = await dbContext.Coupons
                 .FirstOrDefaultAsync(x => x.ProductName == request.ProductName);

            if (coupon is null)
            {
                coupon = new Coupon { ProductName = "No product Available", Amount = 0, Description = "No Discount Desc" };
            }

            logger.LogInformation("Discount is retrieved for ProductName : {ProductName}, Amount : {Amount}", coupon.ProductName, coupon.Amount);

            var couponModel = coupon.Adapt<CouponModel>();
            return couponModel;


        }





        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request,
                                           ServerCallContext context)
        {
            var coupon = request.Coupon.Adapt<Coupon>();
            if (coupon is null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Coupon is null"));
            }

            var Check = await dbContext.Coupons.FirstOrDefaultAsync(x => x.ProductName == coupon.ProductName);
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

        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request,
                                           ServerCallContext context)
        {

            var coupon = request.Coupon.Adapt<Coupon>();
            if (coupon is null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Coupon is null"));
            }

            var Check = await dbContext.Coupons.FirstOrDefaultAsync(x => x.Id == coupon.Id);
            if (Check is null)
            {
                logger.LogInformation(" This ProductName is not found. ProductName : {ProductName}", coupon.ProductName);
                coupon = new Coupon { ProductName = "Not Found", Amount = 0, Description = "Not found" };

            }
            else
            {
                //dbContext.Coupons.Update(coupon);
                dbContext.Entry(Check).CurrentValues.SetValues(coupon);
                await dbContext.SaveChangesAsync();
                logger.LogInformation("Discount is successfully updated. ProductName : {ProductName}", coupon.ProductName);
            }

            var couponModel = coupon.Adapt<CouponModel>();
            return couponModel;


        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request,
                                                     ServerCallContext context)
        {

            var Check = await dbContext.
                Coupons.FirstOrDefaultAsync(x => x.ProductName == request.ProductName);

            if (Check is null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount with ProductName={request.ProductName} is not found."));
                ;
            }
            dbContext.Coupons.Remove(Check);
            await dbContext.SaveChangesAsync();
            logger.LogInformation("Discount is successfully deleted. ProductName : {ProductName}", request.ProductName);

            return new DeleteDiscountResponse
            {
                Success = true
            };

        }

    }
}
