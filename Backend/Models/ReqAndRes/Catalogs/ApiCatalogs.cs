namespace Backend.Models;

public class ApiCatalog : IApiCatalog
{
    public Int64 Id { get; set; }
    public string Name { get; set; } = "";
    
    public List<Int64> ApisId { get; set; } = new();
    public List<Api> Apis { get; set; } = new();
    
    public List<Int64> ChildrenId { get; set; } = new();
    public List<ApiCatalog> Children { get; set; } = new();

    public Int64? ParentId { get; set; }
    public ApiCatalog? Parent { get; set; }
}
