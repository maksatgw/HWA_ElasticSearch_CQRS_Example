using HWA_ElasticSearch.Model;
using HWA_ElasticSearch.Service.Abstract;
using Nest;

namespace HWA_ElasticSearch.Service.Concrete
{
    public class ProductService : IProductService
    {
        //ElasticClient DI
        private readonly ElasticClient _elasticClient;
        public ProductService(ElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }
        public async Task<string> CreateDocAsync(Product document)
        {
            //Bir Index create ediyoruz.
            var response = await _elasticClient.IndexDocumentAsync(document);
            //Eğer response isValid değil ise bir failed mesajı döndürüyoruz.
            return response.IsValid ? "Document Created Success" : "Failed";
        }

        public async Task<IEnumerable<Product>> GetAllDocsAsync(int pageNumber, int pageSize)
        {
            int from = (pageNumber - 1) * pageSize;
            //Paginasyon ile verileri alıyoruz.
            var response = await _elasticClient.SearchAsync<Product>(x => x.Size(pageSize).From(pageNumber).MatchAll());
            return response.Documents;
        }
    }
}
