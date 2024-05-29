using HWA_ElasticSearch.Med.Queries.Responses;
using MediatR;

namespace HWA_ElasticSearch.Med.Queries.Requests
{
    public class GetAllProductQuery : IRequest<List<ProductGetAllViewModel>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

    }
}
