using System.ComponentModel;
using System.IO.Pipes;
using Microsoft.VisualBasic;
using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository;

public class ApiRepository
{
    private readonly TempDbContext _db;

    public ApiRepository(TempDbContext db) => _db = db;

    public async Task<ApiCatalog> SaveCatalog(ApiCatalog catalog)
    {
        _db.ApiCatalogs.Add(catalog);
    
        await _db.SaveChangesAsync();

        return catalog;
    }

    public async Task<Api> SaveApi(Api api)
    {
        _db.Apis.Add(api);

        await _db.SaveChangesAsync();

        return api;
    }

    public async Task<List<ApiCatalog>> GetItemsUnderParentCatalog(Int64? id)
    {
        var item = await _db.ApiCatalogs
            .AsNoTracking()
            .Where(x => x.ParentId == id)
            .ToListAsync();

        return item;
    }

    public async Task<List<Api>> GetItemsUnderParentApi(Int64? id)
    {
        var item = await _db.Apis
            .AsNoTracking()
            .Where(x => x.ParentId == id)
            .ToListAsync();
    
        return item;
    }

    public async Task<ApiCatalog> CatalogById(Int64 Id)
    {
        var Catalog = await _db.ApiCatalogs.FindAsync(Id);

        if(Catalog == null)
            throw new ArgumentException("Id not found in database");

        return Catalog;
    }
}
