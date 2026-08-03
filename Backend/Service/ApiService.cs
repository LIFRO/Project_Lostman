using Backend.Repository;
using Backend.Models;
using System.Text.Json;

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

        Console.WriteLine("Service Layer Get Items Under Folder " + Catalogs + " " + apis);

        (List<ApiCatalog>, List<Api>) items = (Catalogs, apis);

        return items;
    }

    public async Task<(List<ApiCatalog> catalogs, List<Api> apis)> FetchItems()
    {
        var (catalogs, apis)  = await _repo.FetchItems();

        (List<ApiCatalog>, List<Api>) items = (catalogs, apis);

        return items; 
    }

    public async Task AddItemUnderFolder(ExplorerItemRequest request)
    {
        Console.WriteLine("Service Layer" + JsonSerializer.Serialize(request));
        if(request.Api != null)
        {
            foreach (Api item in request.Api)
            {
                await _repo.AddToFolder(item, request.Id);
                Console.WriteLine(item);
            }
        }
        if(request.Catalogs != null)
        {
            foreach(ApiCatalog item in request.Catalogs)
            {
                await _repo.AddToFolder(item, request.Id);
                Console.WriteLine(item);
            }
        }
    }
}
