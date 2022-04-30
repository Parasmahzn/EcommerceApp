namespace EcommerceApp.Client.Services.CartService
{
    public interface ICartService
    {
        event Action OnChange;
        Task AddToCart(CartItem cartItem);
        Task<List<CartItem>> GetCartItems();
        Task<List<CartProductDTOResponse>> GetCartProducts();
        Task RemoveProductFromFromCart(int producId, int productTypeId);
        Task UpdateQuantity(CartProductDTOResponse product);
    }
}
