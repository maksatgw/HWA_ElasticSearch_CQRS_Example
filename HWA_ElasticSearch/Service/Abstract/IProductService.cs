using HWA_ElasticSearch.Model;

namespace HWA_ElasticSearch.Service.Abstract
{
    public interface IProductService 
    {
        //Kullanacağımız metot imzalarını tanımlıyoruz.
        Task<string> CreateDocAsync(Product document);
        Task<IEnumerable<Product>> GetAllDocsAsync(int pageNumber, int pageSize);
    }
}
