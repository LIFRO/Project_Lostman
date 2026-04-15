using System.ComponentModel;
using System.IO.Pipes;
using Microsoft.VisualBasic;
using Backend.Data;
using Backend.Models;

namespace Backend.Repository;

public class ApiRepository
{
    private readonly TempDbContext _db;

    public ApiRepository(TempDbContext db) => _db = db;

    public async Task<Api> SaveApi(Api api)
    {
        _db.Apis.Add(api);

        await _db.SaveChangesAsync();

        return api;
    }
}
