public class ProductRepository : IProductRepository
{
    private List<Product> _products = new List<Product>
    {
        new Product { Id = 1, Name = "Laptop", Price = 1200, Description = "Gaming Laptop" },
        new Product { Id = 2, Name = "Smartphone", Price = 800, Description = "Latest Model" }
    };

    // Implement the GetAll method
    public IEnumerable<Product> GetAll()
    {
        return _products;
    }

    // Implement the GetById method
    public Product GetById(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    // Implement the Add method
    public void Add(Product product)
    {
        product.Id = _products.Max(p => p.Id) + 1;
        _products.Add(product);
    }

    // Implement the Update method
    public void Update(Product product)
    {
        var existingProduct = GetById(product.Id);
        if (existingProduct != null)
        {
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Description = product.Description;
        }
    }

    // Implement the Delete method
    public void Delete(int id)
    {
        var product = GetById(id);
        if (product != null)
        {
            _products.Remove(product);
        }
    }
}
