namespace EcommerceApp.Client.Services.ProductSevice
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }
        public List<Product> Products { get; set; } = new List<Product>();
        public string Message { get; set; } = "Loading products...";

        public int currentPage { get; set; } = 1;
        public int pageCount { get; set; } = 0;
        public string lastSearchText { get; set; } = string.Empty;

        public event Action ProductsChanged;

        public async Task<ServiceResponse<Product>> GetProduct(int productId)
        {

            var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{productId}");
            if (result != null && result.Data != null)
                return result;
            else
                return new ServiceResponse<Product>()
                {
                    Success = false,
                    Message = "Sorry Product Not Found"
                };
        }

        public async Task GetProducts(string? categoryUrl = null)
        {
            var result = categoryUrl == null ?
                await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product/featured") :
                await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/category/{categoryUrl}");

            if (result != null && result.Data != null)
                Products = result.Data;

            currentPage = 1;
            pageCount = 0;
            if (Products.Count == 0)
            {
                Message = "No products found.";
            }
            ProductsChanged.Invoke();
        }

        public async Task<List<string>> GetProductSearchSuggestions(string searchText)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<string>>>($"api/product/searchsuggestions/{searchText}");
            return result.Data;
        }

        public async Task SearchProducts(string searchText, int page)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<ProductSearchDTO>>($"api/product/search/{searchText}/{page}");
            if (result != null && result.Data != null)
            {
                Products = result.Data.Products;
                currentPage = result.Data.CurrentPage;
                pageCount = result.Data.Pages;
            }

            if (Products.Count == 0)
                Message = "No products found.";
            ProductsChanged?.Invoke();

        }
    }
}
