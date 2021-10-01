using Microsoft.AspNetCore.Mvc;
using ViewComponentSample.Models;
using ViewComponentSample.Models.Services.Application;

namespace ViewComponentSample.ViewComponents
{
    public class ProductListViewComponent : ViewComponent
    {
        private readonly IProductService productService;

        public ProductListViewComponent(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string category)
        {
            // Model binding non supportato nei view component
            // https://github.com/dotnet/aspnetcore/issues/13701#issuecomment-528459419
            string searchFieldName = $"Search.{category}";
            string? search = Request.Query[searchFieldName].FirstOrDefault();
            IList<ProductViewModel> results = await productService.GetProductsByCategoryAsync(category, search);
            ProductListViewModel viewModel = new ProductListViewModel
            {
                Category = category,
                Results = results,
                Search = search,
                SearchFieldName = searchFieldName
            };

            return View(viewModel);
        }
    }
}