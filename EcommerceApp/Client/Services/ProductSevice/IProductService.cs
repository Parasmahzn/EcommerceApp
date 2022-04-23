namespace EcommerceApp.Client.Services.ProductSevice
{
    public interface IProductService
    {
        event Action ProductsChanged;
        List<Product> Products { get; set; }
        string Message { get; set; }
        int currentPage { get; set; }
        int pageCount { get; set; }
        string lastSearchText { get; set; }
        Task GetProducts(string? CategoryUrl = null);
        Task<ServiceResponse<Product>> GetProduct(int productId);
        Task SearchProducts(string searchText,int page);
        Task<List<string>> GetProductSearchSuggestions(string searchText);
    }
}
