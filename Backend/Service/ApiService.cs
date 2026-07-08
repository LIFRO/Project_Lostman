using Backend.Repository;
using Backend.Models;

namespace Backend.Service;

public class ApiService
{

    private readonly ApiRepository _repo;

    public ApiService(ApiRepository repo) => _repo = repo;

    public async Task<ApiCatalog> CreateCatalog(ApiCatalog req)
    {
        if (string.IsNullOrWhiteSpace(req.Name)){
            throw new ArgumentException("name is required");
        };

        if (req.ParentId.HasValue)
        {
            var parentExists = await _repo.CatalogById(req.ParentId.Value);
        }

        var Catalog = new ApiCatalog
        {
            Name = req.Name,
            ParentId = req.ParentId
        };

        Catalog = await _repo.SaveCatalog(Catalog);
    
        return Catalog;
    }

    public async Task<Api> CreateApi(Api req)
    {
        if (string.IsNullOrWhiteSpace(req.Name)){
            throw new ArgumentException("name is required");
        };
        
        var api = new Api
        {
            Name = req.Name,
            ParentId = req.ParentId,
        };
        
        api = await _repo.SaveApi(api);

        return api;
    }

    public async Task<(List<ApiCatalog> catalogs, List<Api> apis)> GetItemsUnderParent(long? id)
    {
        List<ApiCatalog> Catalogs = await _repo.GetItemsUnderParentCatalog(id);
        List<Api> apis = await _repo.GetItemsUnderParentApi(id);

        (List<ApiCatalog>, List<Api>) items = (Catalogs, apis);

        return items;
    }

    public async Task<(List<ApiCatalog> catalogs, List<Api> apis) FetchItems()
    {
        (List<ApiCatalog>, List<Api>) items = (Catalog, apis);

        return item; 
    }
}
