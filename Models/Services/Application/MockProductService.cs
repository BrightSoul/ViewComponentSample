namespace ViewComponentSample.Models.Services.Application;

public class MockProductService : IProductService
{
    private List<ProductViewModel> products = new List<ProductViewModel>
    {
        new ProductViewModel { Id = "1", Name = "LCD TV", Category = "Electronics" },
        new ProductViewModel { Id = "2", Name = "LCD Monitor", Category = "Electronics" },
        new ProductViewModel { Id = "3", Name = "Laser toner black", Category = "Consumables" },
        new ProductViewModel { Id = "4", Name = "Laser toner color", Category = "Consumables" },
        new ProductViewModel { Id = "5", Name = "Baby monitor", Category = "Electronics" },
        new ProductViewModel { Id = "6", Name = "TV 4k", Category = "Electronics" },
        new ProductViewModel { Id = "4", Name = "Black pens, kit of 10", Category = "Consumables" }
    };

    public Task<IList<ProductViewModel>> GetProductsByCategoryAsync(string category, string? search = null)
    {
        var productQuery = products.Where(product => product.Category == category);
        if (!string.IsNullOrEmpty(search))
        {
            productQuery = productQuery.Where(product => product.Name.Contains(search, StringComparison.InvariantCultureIgnoreCase));
        }

        var results = productQuery.ToList();
        return Task.FromResult<IList<ProductViewModel>>(results);
    }
}
