namespace EcommerceApp.Client.Services.ProductSevice
{
    public interface IProductService
    {
        event Action ProductsChanged;

        List<Product> Products { get; set; }
        Task GetProducts(string? CategoryUrl = null);
        Task<ServiceResponse<Product>> GetProduct(int productId);
    }
}
