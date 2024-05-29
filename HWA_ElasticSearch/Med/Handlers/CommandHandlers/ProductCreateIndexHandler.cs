using HWA_ElasticSearch.Med.Commands.Requests;
using HWA_ElasticSearch.Med.Commands.Responses;
using HWA_ElasticSearch.Model;
using HWA_ElasticSearch.Service.Abstract;
using MediatR;

namespace HWA_ElasticSearch.Med.Handlers.CommandHandlers
{
    public class ProductCreateIndexHandler : IRequestHandler<CreateProductIndexCommand, ProductCreateViewModel>
    {
        private readonly IProductService _productService;

        public ProductCreateIndexHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ProductCreateViewModel> Handle(CreateProductIndexCommand request, CancellationToken cancellationToken)
        {
            var data = new Product
            {
                Id = request.Id,
                Name = request.Name,
                Quantity = request.Quantity,
            };
            var response = await _productService.CreateDocAsync(data);

            var viewModel = new ProductCreateViewModel
            {
                Name = request.Name,
                Message = response,
                IsSuccess = true,
            };

            return viewModel;
        }
    }
}
