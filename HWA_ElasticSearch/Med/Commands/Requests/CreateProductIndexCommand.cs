using HWA_ElasticSearch.Med.Commands.Responses;
using MediatR;

namespace HWA_ElasticSearch.Med.Commands.Requests
{
    public class CreateProductIndexCommand : IRequest<ProductCreateViewModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
