namespace Backend.Models;

public interface IApiCatalog
{
    Int64 Id { get; set; }
    string Name { get; set; }
    List<Api>? Apis { get; set; }
    List<ApiCatalog>? Children { get; set; }
    Int64? ParentId { get; set; }
}
