namespace FinalProject.Repository.OrderRepository
{
    public interface IOrder
    {
        int GetTotalAmount(int userId);

        int GetNetAmount(int userId);
        void BuyNow(int userId);
    }
}
