using HWA_ElasticSearch.Med.Queries.Requests;
using HWA_ElasticSearch.Med.Queries.Responses;
using HWA_ElasticSearch.Model;
using HWA_ElasticSearch.Service.Abstract;
using MediatR;

namespace HWA_ElasticSearch.Med.Handlers.QueryHandlers
{
    public class ProductGetAllQueryHandler : IRequestHandler<GetAllProductQuery, List<ProductGetAllViewModel>>
    {
        private readonly IProductService _productService;

        public ProductGetAllQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<List<ProductGetAllViewModel>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var response = await _productService.GetAllDocsAsync(request.PageNumber, request.PageSize);

            var viewModel = response.Select(x => new ProductGetAllViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return viewModel;
        }
    }
}
