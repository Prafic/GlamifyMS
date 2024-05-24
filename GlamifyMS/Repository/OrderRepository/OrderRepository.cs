using FinalProject.Models;
using FinalProject.Repository.CartRepository;

namespace FinalProject.Repository.OrderRepository
{
    public class OrderRepository:IOrder
    {

        private readonly FinalDbContext context;
        private readonly ICart cart;

        public OrderRepository(FinalDbContext context, ICart cart)
        {
            this.context = context;
            this.cart = cart;
        }
        public int GetNetAmount(int userId)
        {
            return context.Orders.FirstOrDefault(t=>t.UserId==userId).NetAmount;

        }
        public void BuyNow(int userId)
        {
            var order = new Order
            {
                UserId = userId,
                TotalAmount = GetTotalAmount(userId),
                ShippingCharge = 175,
                NetAmount = GetTotalAmount(userId)+175

            };
            context.Orders.Add(order);
            context.SaveChanges();
        }

      
        public int GetTotalAmount(int userId)
        {
            return cart.GetToTalPrice(userId);
        }
       

    }
}
