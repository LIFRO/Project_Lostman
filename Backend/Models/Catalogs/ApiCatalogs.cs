namespace Backend.Models;

public class ApiCatalog : IApiCatalog
{
    public int Id { get; set; }
    public string User { get; set; } = "";
    public string Name { get; set; } = "";
    public List<Api> Apis { get; set; } = new();
    public List<ApiCatalog> Children { get; set; } = new();
    public List<ApiCatalog> Parent { get; set; } = new();
}
