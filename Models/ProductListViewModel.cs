namespace ViewComponentSample.Models;

public class ProductListViewModel
{
    public IList<ProductViewModel> Results { get; set; } = new List<ProductViewModel>();
    public string Category { get; set; } = string.Empty;
    public string? Search { get; set; }
    public string SearchFieldName { get; set; } = string.Empty;
}
