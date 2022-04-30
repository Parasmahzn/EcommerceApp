namespace EcommerceApp.Server.Services.CartService
{
    public interface ICartService
    {
        Task<ServiceResponse<List<CartProductDTOResponse>>> GetCartProducts(List<CartItem> cartItems);
    }
}
