using HWA_ElasticSearch.Med.Commands.Requests;
using HWA_ElasticSearch.Med.Queries.Requests;
using HWA_ElasticSearch.Model;
using HWA_ElasticSearch.Service.Abstract;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nest.Specification.AsyncSearchApi;

namespace HWA_ElasticSearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ESController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMediator _mediator;

        public ESController(IProductService productService, IMediator mediator)
        {
            _productService = productService;
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int pageNumber = 1, int pageSize = 10)
        {
            var query = new GetAllProductQuery() { 
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return Ok(await _mediator.Send(query));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateProductIndexCommand product)
        {
            var result = await _mediator.Send(product);
            return Ok(result);
        }
    }
}
