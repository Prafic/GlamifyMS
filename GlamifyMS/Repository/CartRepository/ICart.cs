using FinalProject.Models;

namespace FinalProject.Repository.CartRepository
{
    public interface ICart
    {
        Task<Cart> AddToCart(int productId, int userId);
        List<Cart> GetAllCartItems(int userId);
        void UpdateCartItemDB(int userId, ShoppingCartUpdate[] CartItemsUpdate);
        int GetToTalPrice(int userId);
        Task<Cart> RemoveItem(int productId, int userId);

        void UpdateItem(int productId, int userId, int quantity);

        void EmptyCart(int userId);

        int GetCount(int userId);

    }
}
