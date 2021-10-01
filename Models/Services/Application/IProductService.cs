namespace ViewComponentSample.Models.Services.Application;

public interface IProductService
{
    Task<IList<ProductViewModel>> GetProductsByCategoryAsync(string category, string? search = null);
}
