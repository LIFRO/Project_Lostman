using Backend.Repository;
using Backend.Models;

namespace Backend.Service;

public class ApiService
{

    private readonly ApiRepository _repo;

    public ApiService(ApiRepository repo) => _repo = repo;

    public async Task<Api> CreateApi(Api req)
    {
        if (string.IsNullOrWhiteSpace(req.Name))
        {
            throw new ArgumentException("name is required");
        };
        
        var api = new Api
        {
            UserId = req.UserId,
            Name = req.Name,
            ParentId = req.ParentId,
        };

        api = await _repo.SaveApi(req);

        return api;
    }
}
