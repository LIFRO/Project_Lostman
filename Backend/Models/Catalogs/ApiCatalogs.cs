namespace Backend.Models;

public class ApiCatalog : IApiCatalog
{
    public Int64 Id { get; set; }
    public string Name { get; set; } = "";
    public List<Api>? Apis { get; set; }
    public List<ApiCatalog>? Children { get; set; }
    public Int64? ParentId { get; set; }
}
