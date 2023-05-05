namespace CQRSMediatRExample
{
    public class FakeDataStore
    {
        private static List<Product> _products;

        public FakeDataStore()
        {
            _products = new List<Product>()
            {
                new Product() { Id = 1, Name = "Test Product 1" },
                new Product() { Id = 2, Name = "Test Product 2" }
            };
        }

        public async Task AddProduct(Product product)
        {
            product.Id = _products.Count + 1;
            _products.Add(product);
        }

        public async Task<IEnumerable<Product>> GetAllProducts() => await Task.FromResult(_products);

        public async Task<Product?> GetProductById(int requestId) =>
            await Task.FromResult(_products.Where(x => x.Id == requestId)?.FirstOrDefault());
    }
}
